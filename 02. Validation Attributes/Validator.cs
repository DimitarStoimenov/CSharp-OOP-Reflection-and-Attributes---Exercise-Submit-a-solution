using CommandPattern;
using System;
using System.Linq;
using System.Reflection;

namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(Object obj)
        {

            PropertyInfo[] properties = obj.GetType().GetProperties();

            foreach (var prop in properties)
            {
                var atrributes = prop.GetCustomAttributes().Where(t => t.GetType().IsSubclassOf(typeof(MyValidationAttribute))).Cast<MyValidationAttribute>().ToArray();

                foreach (var item in atrributes)
                {
                    bool IsValid = item.IsValid(prop.GetValue(obj));

                    if (!IsValid)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}