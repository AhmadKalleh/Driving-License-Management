using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Project
{
    public class Match
    {
        public static bool AreObjectsEqual<T>(T obj1, T obj2)
        {
            if (obj1 == null || obj2 == null)
                return false;

            var type = typeof(T);

            foreach (var prop in type.GetProperties())
            {
                var val1 = prop.GetValue(obj1);
                var val2 = prop.GetValue(obj2);

                // التعامل مع null
                if (val1 == null && val2 == null)
                    continue;

                if (val1 == null || val2 == null)
                    return false;

                // إذا كانت القيمة نصية، تجاهل حالة الأحرف والفراغات
                if (val1 is string s1 && val2 is string s2)
                {
                    if (!string.Equals(s1?.Trim(), s2?.Trim(), StringComparison.OrdinalIgnoreCase))
                        return false;
                }
                else
                {
                    if (!val1.Equals(val2))
                        return false;
                }
            }

            return true;
        }
    }
}
