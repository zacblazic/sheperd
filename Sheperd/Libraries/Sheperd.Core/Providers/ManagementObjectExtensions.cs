using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace Sheperd.Core.Providers
{
    public static class ManagementObjectExtensions
    {
        public static T GetPropertyValueOrDefault<T>(this ManagementObject managementObject, string propertyName, T defaultValue)
        {
            object p = managementObject.GetPropertyValue(propertyName);
            T t = (p != null ? (T)Convert.ChangeType(p, typeof(T)) : defaultValue);

            return t;
        }
    }
}
