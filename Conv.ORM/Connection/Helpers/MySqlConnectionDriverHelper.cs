using ConvORM.Repository;
using MySql.Data.MySqlClient;
using System;
using System.Reflection;

namespace ConvORM.Connection.Helpers
{
    internal class MySqlConnectionDriverHelper
    {
        public Entity ConvertReaderToEntity(MySqlDataReader reader, Type type)
        {
            object teste = Activator.CreateInstance(type);

            while(reader.Read())
            {
                foreach(FieldInfo field in type.GetFields())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        if (field.Name == reader.GetName(i))
                        {
                            if (reader.GetValue(i).GetType() == field.FieldType)
                            {
                                field.SetValue(teste, reader.GetValue(i));
                                break;
                            }
                            else if (CompatibilityFormat(reader.GetValue(i), field.FieldType, out object convertedValue))
                            {
                                field.SetValue(teste, convertedValue);
                            }
                            else
                            {
                                #if DEBUG
                                Console.WriteLine(field.Name + " in query return if wrong type. Type returned in query result: " + reader.GetValue(i).GetType().ToString() + " Type of entity field: " + field.FieldType.ToString());
                                #endif
                            }
                        }
                    }
                }
            }

            return (Entity)teste;
            
        }

        private bool CompatibilityFormat(object valueFromReader, Type typeOfEntityField, out object convertedValue)
        {
            convertedValue = null;
            if (valueFromReader.GetType().Name == "SByte")
            {
                if (typeOfEntityField.Name ==  "Boolean")
                {
                    convertedValue = ((sbyte)valueFromReader) == 1;                    
                }
            }

            return convertedValue != null;
        }
    }
}
