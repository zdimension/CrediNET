using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrediNET
{
    public static class Extensions
    {
        public static string Sanitize(this string str)
        {
            return str.Replace("'", "''");
        }

        public static void AddOrUpdate(this Dictionary<string, decimal> dic, string key, decimal value)
        {
            if (dic.ContainsKey(key))
            {
                dic[key] = value;
            }
            else
            {
                dic.Add(key, value);
            }
        }
    }
}
