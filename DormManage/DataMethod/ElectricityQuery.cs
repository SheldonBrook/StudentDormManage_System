using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormManage.DataMethod
{
    class ElectricityQuery
    {
        DormManageDataEntities dbEntity = new DormManageDataEntities();
        public IQueryable<electricity> queryByKey(string area, int build, int room)
        {
            var query = from t in dbEntity.electricity
                        where t.area == area && t.build == build && t.room == room
                        select t;
            return query;
        }
        public List<electricity> queryAll()
        {
            var query = from t in dbEntity.electricity
                        select t;
            return query.ToList();
        }
    }
}
