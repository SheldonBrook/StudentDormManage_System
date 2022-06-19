using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DormManage.DataMethod
{
    static class DormlistOperation
    {
        static DormManageDataEntities dbEntities = new DormManageDataEntities();
        public static bool addDorm(string area,int build,int room,string dormtype,int peoplenumber, string dormheader)
        {
            bool result = false;
            DormQuery dq = new DormQuery();
            if(dq.queryByKey(area, build, room).Count() > 0)
            {
                MessageBox.Show("宿舍已存在");
            }
            else
            {
                dorm d = new dorm
                {
                    area = area,
                    build = build,
                    room = room,
                    dormtype = dormtype,
                    peoplenumber = peoplenumber,
                    dormheader = dormheader
                };
                dbEntities.dorm.Add(d);  //插入
                dbEntities.SaveChanges(); //保存
                result = true;
            }
            return result;
        }
        public static bool renewDorm(string area, int build, int room,string dormtype, int peoplenumber, string dormheader)
        {
            bool result = false;

            var d = dbEntities.dorm.FirstOrDefault((t) => t.area == area && t.build == build && t.room == room);
            d.dormtype = dormtype;
            d.peoplenumber = peoplenumber;
            d.dormheader = dormheader;
            int i = dbEntities.SaveChanges();
            if(i > 0)
            {
                result = true;
            }
            return result;
        }
        public static bool delDorm(string area, int build, int room)
        {
            bool result = false;
            var d = dbEntities.dorm.FirstOrDefault((t) => t.area == area && t.build == build && t.room == room);
            dbEntities.dorm.Remove(d);
            int i = dbEntities.SaveChanges();
            if(i > 0)
            {
                result = true;
            }
            return result;
        }
    }
}
