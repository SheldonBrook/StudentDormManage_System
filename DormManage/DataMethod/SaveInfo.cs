using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormManage.DataMethod
{
    class SaveInfo
    {
        private static string id;

        public SaveInfo()
        {
            id = "";
        }

        public static string getId()
        {
            return id;
        }
        public static void setId(String numb)
        {
            id = numb;
        }
    }
}
