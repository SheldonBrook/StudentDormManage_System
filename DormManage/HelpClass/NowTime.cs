using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormManage.HelpClass
{
    class NowTime
    {
        public static string getNowTime()
        {
            string str = "";
            string hour = $"{DateTime.Now:HH}";
            int h = int.Parse(hour);
            if (h >= 12)
            {
                h -= 12;
                str = "下午 " + h.ToString() + ":" + $"{DateTime.Now:mm:ss}";
            }
            else
            {
                str = "上午 " + $"{DateTime.Now:HH:mm:ss}";
            }
            return str;
        }
    }
}
