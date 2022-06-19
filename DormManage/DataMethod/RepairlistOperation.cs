using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormManage.DataMethod
{
    static class RepairlistOperation
    {
        static DormManageDataEntities dbEntities = new DormManageDataEntities();
        public static bool delRepair(string area, int build, int room, string type)
        {
            bool result = false;
            var r = dbEntities.repair.FirstOrDefault((t) => t.area == area && t.build == build && t.room == room && t.type == type);
            dbEntities.repair.Remove(r);
            int i = dbEntities.SaveChanges();
            if (i > 0)
            {
                result = true;
            }
            return result;
        }
    }
}
