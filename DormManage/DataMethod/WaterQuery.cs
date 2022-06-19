using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormManage.DataMethod
{
    class WaterQuery
    {
        DormManageDataEntities dbEntity = new DormManageDataEntities();

        public IQueryable<water> queryByKey(string area, int build, int room)
        {
            var query = from t in dbEntity.water
                        where t.area == area && t.build == build && t.room == room
                        select t;
            return query;
        }

        public List<water> queryAll()
        {
            var query = from t in dbEntity.water
                        select t;
            return query.ToList();
        }
    }
}
