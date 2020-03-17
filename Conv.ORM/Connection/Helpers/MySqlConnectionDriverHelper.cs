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
                foreach(PropertyInfo property in type.GetProperties())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        if (property.Name == reader.GetName(i))
                        {
                            if (reader.GetValue(i).GetType() == property.PropertyType)
                            {
                                property.SetValue(teste, reader.GetValue(i));
                                break;
                            }
                            else
                            {
                                #if DEBUG
                                Console.WriteLine(property.Name + "in query return if wrong type");
                                #endif
                            }
                        }
                    }
                }
            }

            return (Entity)teste;
            
        }
    }
}
