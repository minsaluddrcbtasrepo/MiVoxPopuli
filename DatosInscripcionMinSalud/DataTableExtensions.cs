using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace DatosInscripcionMinSalud
{
    public static class DataTableExtensions
    {
        public static List<T> ToList<T>(this DataTable dataTable) where T : new()
        {
            var list = new List<T>();
            if (dataTable == null) return null;

            foreach (DataRow row in dataTable.Rows)
            {
                T obj = new T();
                foreach (DataColumn column in dataTable.Columns)
                {
                    PropertyInfo property = typeof(T).GetProperty(column.ColumnName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                    if (property != null && row[column] != DBNull.Value)
                    {
                        property.SetValue(obj, Convert.ChangeType(row[column], property.PropertyType), null);
                    }
                }
                list.Add(obj);
            }

            return list;
        }
    }
}
