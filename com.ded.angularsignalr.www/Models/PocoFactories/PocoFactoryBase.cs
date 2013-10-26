using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace com.ded.angularsignalr.www.Models.PocoFactories
{
    public class PocoFactoryBase
    {
        protected internal static object GetPopulatedPoco(object source, Type targetType)
        {
            object target = Activator.CreateInstance(targetType);
            // User Reflection to populate the userPoco.
            PropertyInfo[] properties = target.GetType().GetProperties();
            foreach (PropertyInfo property in properties)
            {
                try
                {
                    /// Check to see if the Entity Object passed in is equal to null.  
                    /// If it is, there is no reason to continue with this property.
                    if (source != null)
                    {
                        PopulatePropertyValue(source, target, property);
                    }
                }
                catch (Exception ex)
                {
                }
                
            }
            return target;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <param name="property"></param>
        /// <remarks>
        ///     We need to see if this works with lists of Child objects.  
        ///     Currently, I don't have an object type to test it with.
        /// </remarks>
        private static void PopulatePropertyValue(object source, object target, PropertyInfo property)
        {
            /// Take the entity object and look up the property value in the entity object.
            /// If the value of the property in the entity object is null, there is reason to continue
            /// since we are using that entity object to populate the poco object property which is already null.
            PropertyInfo entityProperty = source.GetType().GetProperty(property.Name);
            if (entityProperty != null)
            {
                object propertyValue = entityProperty.GetValue(source, null);
                //if (Type.GetTypeCode(property.PropertyType) == TypeCode.Object)
                if (property.PropertyType.Name.ToLower().Contains("poco"))
                {
                    /// If the object type has POCO in it, then we know that we want to recursively load the poco objects.
                    /// So we will call the root method again which is the GetPopulatedPoco method.
                    object newValue = GetPopulatedPoco(propertyValue, property.PropertyType);
                    property.SetValue(target, newValue);
                }
                else
                {
                    /// If the property is a primitive type (string, int, long, double, etc).  Then we will simply load the value.
                    property.SetValue(target, propertyValue);
                }
            }
        }
    }
}