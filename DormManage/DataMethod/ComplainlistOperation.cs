using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormManage.DataMethod
{
    class ComplainlistOperation
    {
        static DormManageDataEntities dbEntities = new DormManageDataEntities();
        public static bool delComplainDorm(int id)
        {
            bool result = false;
            var d = dbEntities.complain_dorm.FirstOrDefault((t) => t.id == id);
            dbEntities.complain_dorm.Remove(d);
            int i = dbEntities.SaveChanges();
            if (i > 0)
            {
                result = true;
            }
            return result;
        }
        public static bool delComplainAdmin(int id)
        {
            bool result = false;
            var d = dbEntities.complain_admin.FirstOrDefault((t) => t.id == id);
            dbEntities.complain_admin.Remove(d);
            int i = dbEntities.SaveChanges();
            if (i > 0)
            {
                result = true;
            }
            return result;
        }
    }
}
