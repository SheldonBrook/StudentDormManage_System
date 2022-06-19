using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormManage.DataMethod
{
    class RepairQuery
    {
        DormManageDataEntities dbEntity = new DormManageDataEntities();

        public IQueryable<repair> queryByKey(string area, int build, int room)
        {
            var query = from t in dbEntity.repair
                        where t.area == area && t.build == build && t.room == room
                        select t;
            return query;
        }

        public List<repair> queryAll()
        {
            var query = from t in dbEntity.repair
                        select t;
            return query.ToList();
        }

        public IQueryable<repair> queryRepeat(string area, int build, int room,string type)
        {
            var query = from t in dbEntity.repair
                        where t.area == area && t.build == build && t.room == room && t.type == type
                        select t;
            return query;
        }
    }
}
