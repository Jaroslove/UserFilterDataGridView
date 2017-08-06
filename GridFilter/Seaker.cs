using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridFilter
{
    static class Seaker
    {
        private static Dictionary<int, string> list = new Dictionary<int, string>();
        public static void Set(int key, string value)
        {
            list[key] = value;
        }
        public static Dictionary<int, string> Get()
        {
            return list;
        }
    }
}
