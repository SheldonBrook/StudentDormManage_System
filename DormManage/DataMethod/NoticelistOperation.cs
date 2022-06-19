using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormManage.DataMethod
{
    static class NoticelistOperation
    {
        static DormManageDataEntities dbEntities = new DormManageDataEntities();
        public static bool addNotice(string content, DateTime date)
        {
            bool result = false;
            notice n = new notice
            {
                content = content,
                date = date
            };
            dbEntities.notice.Add(n);  //插入
            dbEntities.SaveChanges(); //保存
            result = true;
            return result;
        }
        public static bool delNotice(int id)
        {
            bool result = false;
            var n = dbEntities.notice.FirstOrDefault((t) => t.id == id);
            dbEntities.notice.Remove(n);
            int i = dbEntities.SaveChanges();
            if (i > 0)
            {
                result = true;
            }
            return result;
        }
    }
}
