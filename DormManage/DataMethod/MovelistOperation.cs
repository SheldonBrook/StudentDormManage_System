using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormManage.DataMethod
{
    static class MovelistOperation
    {
        static DormManageDataEntities dbEntities = new DormManageDataEntities();
        public static bool delMove(string studentnumber)
        {
            bool result = false;
            var d = dbEntities.change.FirstOrDefault((t) => t.studentnumber == studentnumber);
            dbEntities.change.Remove(d);
            int i = dbEntities.SaveChanges();
            if (i > 0)
            {
                result = true;
            }
            return result;
        }
    }
}
