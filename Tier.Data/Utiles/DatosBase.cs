using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Data.Utiles
{
    public static class DatosBase
    {

        public static object ConvertValueToType(object value, Type targetType)
        {
            if (value != DBNull.Value && value != null && value.ToString() != "")
            {
                Type valueType = value.GetType();
                if (targetType == valueType || targetType.IsAssignableFrom(valueType))
                    return value;
                else
                {
                    //First, evalue if the target type is a nullable type
                    Type targetTypeTemp = targetType;
                    if (targetTypeTemp.IsNullable())
                    {
                        if (value.ToString().Trim().Length == 0)
                            return null;
                        targetTypeTemp = Nullable.GetUnderlyingType(targetType);
                        if (targetTypeTemp == valueType || targetTypeTemp.IsAssignableFrom(valueType))
                            return value;
                    }
                    if (targetTypeTemp.IsEnum)
                        return Enum.Parse(targetTypeTemp, value.ToString(), true);
                    else
                    {
                        try { return Convert.ChangeType(value, targetTypeTemp); }
                        catch { return Convert.ChangeType(value, targetTypeTemp, CultureInfo.InvariantCulture); }
                    }
                }
            }
            else
                return null;
        }

        public static bool IsNullable(this Type t)
        {
            return t.Name.ToLower() == "nullable`1";
        }
    }
}
