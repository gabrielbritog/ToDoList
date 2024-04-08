using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Am4ToDo.Service.Global
{
    public class Functions
    {
        public static void PersistData<T>(T item, T itemDb)
        {
            var itemType = item.GetType();
            var properties = itemType.GetProperties();

            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(item);

                var itemDbProperty = itemDb.GetType().GetProperty(propertyName);

                if (itemDbProperty != null && propertyValue != null)
                {
                    var itemDbValue = itemDbProperty.GetValue(itemDb);

                    if (!propertyValue.Equals(itemDbValue))
                    {
                        itemDbProperty.SetValue(itemDb, propertyValue);
                    }
                }

            }

        }
     }
}
