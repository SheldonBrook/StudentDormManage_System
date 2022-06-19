using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormManage.DataMethod
{
    class ComplainQuery
    {
        DormManageDataEntities dbEntity = new DormManageDataEntities();

        public IQueryable<complain_dorm> queryDormByKey(string area, int build, int room)
        {
            var query = from t in dbEntity.complain_dorm
                        where t.area == area && t.build == build && t.room == room
                        select t;
            return query;
        }

        public List<complain_dorm> queryDormAll()
        {
            var query = from t in dbEntity.complain_dorm
                        select t;
            return query.ToList();
        }
        public IQueryable<complain_admin> queryAdminByKey(string area, int build, string admin)
        {
            var query = from t in dbEntity.complain_admin
                        where t.area == area && t.build == build && t.admin == admin
                        select t;
            return query;
        }

        public List<complain_admin> queryAdminAll()
        {
            var query = from t in dbEntity.complain_admin
                        select t;
            return query.ToList();
        }
    }
}
