using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormManage.DataMethod
{
    class DormQuery
    {
        DormManageDataEntities dbEntity = new DormManageDataEntities();

        public IQueryable<dorm> queryByKey(string area,int build,int room)
        {
            var query = from t in dbEntity.dorm
                        where t.area == area && t.build == build && t.room == room
                        select t;
            return query;
        }

        public List<dorm> queryAll()
        {
            var query = from t in dbEntity.dorm
                        select t;
            return query.ToList();
        }
    }
}
