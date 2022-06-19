using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormManage.DataMethod
{
    class AdminQuery
    {
        DormManageDataEntities dbEntity = new DormManageDataEntities();

        public IQueryable<admin> queryByKey(string area, int build, string name)
        {
            var query = from t in dbEntity.admin
                        where t.area == area && t.build == build && t.adminname == name
                        select t;
            return query;
        }
        public IQueryable<admin> queryByAdminnumber(string adminnumber)
        {
            var query = from t in dbEntity.admin
                        where t.adminnumber == adminnumber
                        select t;
            return query;
        }
    }
}
