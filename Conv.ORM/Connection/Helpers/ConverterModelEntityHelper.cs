﻿using ConvORM.Connection.Classes;
using ConvORM.Connection.Enums;
using ConvORM.Repository;
using ConvORM.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace ConvORM.Connection.Helpers
{
    class ConverterModelEntityHelper
    {
        Entity entity;
        Type type;
        internal ConverterModelEntityHelper(Entity _entity)
        {
            entity = _entity;
            type = entity.GetType();
        }

        internal string GetTableName()
        {
            Attribute[] attributes = Attribute.GetCustomAttributes(type);

            foreach(Attribute atrribute in attributes)
            {
                if (atrribute is EntitiesAttributes)
                {
                    EntitiesAttributes entitiesAttributes = (EntitiesAttributes)atrribute;
                    return entitiesAttributes.TableName;
                }
            }

            return type.Name.Replace("Entity", "");
        }

        internal string GetConnectionName()
        {
            Attribute[] attributes = Attribute.GetCustomAttributes(type);

            foreach (Attribute atrribute in attributes)
            {
                if (atrribute is EntitiesAttributes)
                {
                    EntitiesAttributes entitiesAttributes = (EntitiesAttributes)atrribute;
                    return entitiesAttributes.ConnectionName;
                }
            }

            return "";
        }

        internal List<ColumnModelEntity> GetColumnsModelEntity()
        {
            List<ColumnModelEntity> ListColumnModelEntity = new List<ColumnModelEntity>();
            FieldInfo[] fields = type.GetFields();

            foreach(FieldInfo field in fields)
            {
                object[] attributes = field.GetCustomAttributes(true);
                foreach(object attribute in attributes)
                {
                    if (attribute is EntitiesColumnAttributes)
                    {
                        EntitiesColumnAttributes entitiesColumnAttributes = (EntitiesColumnAttributes)attribute;
                        ColumnModelEntity columnModelEntity = new ColumnModelEntity();

                        columnModelEntity.ColumnName = entitiesColumnAttributes.Name == null ? field.Name : entitiesColumnAttributes.Name;
                        columnModelEntity.Value = field.GetValue(entity);
                        columnModelEntity.DataType = entitiesColumnAttributes.DataType == EDataType.None ? ConvertSystemTypeToDataType(field.FieldType) : entitiesColumnAttributes.DataType;
                        columnModelEntity.MaxSize = entitiesColumnAttributes.MaxSize;
                        columnModelEntity.Primary = entitiesColumnAttributes.Primary;
                        columnModelEntity.AutoGenerated = entitiesColumnAttributes.AutoGenerated;
                        columnModelEntity.Nullable = entitiesColumnAttributes.Nullable;
                        columnModelEntity.Relation = GetRelationColumnModelEntity(entitiesColumnAttributes.Relation);

                        ListColumnModelEntity.Add(columnModelEntity);
                    }
                }
            }

            return ListColumnModelEntity;

        }

        private RelationColumnModelEntity GetRelationColumnModelEntity(EntitiesColumnRelationAttributes entitiesColumnRelationAttributes)
        {
            if (entitiesColumnRelationAttributes != null)
            {
                RelationColumnModelEntity relationColumnModelEntity = new RelationColumnModelEntity();
                relationColumnModelEntity.TableRelationName = entitiesColumnRelationAttributes.TableRelationName;
                relationColumnModelEntity.ColumnRelationName = entitiesColumnRelationAttributes.ColumnRelationName;
                return relationColumnModelEntity;
            }
            else
                return null;
        }

        private EDataType ConvertSystemTypeToDataType(Type systemType)
        {
            switch (systemType.Name)
            {
                case "bool":
                    return EDataType.Boolean;
                case "decimal":
                    return EDataType.Decimal;
                case "double":
                    return EDataType.Boolean;
                case "float":
                    return EDataType.Float;
                case "int":
                    return EDataType.Integer;
                case "long":
                    return EDataType.Bigint;
                case "string":
                    return EDataType.Varchar;               
                default:
                    return EDataType.None;
            }
        }
    }
}
