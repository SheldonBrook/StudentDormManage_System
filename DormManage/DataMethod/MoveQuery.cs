using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormManage.DataMethod
{
    class MoveQuery
    {
        DormManageDataEntities dbEntity = new DormManageDataEntities();

        public IQueryable<change> queryByKey(string studentnumber)
        {
            var query = from t in dbEntity.change
                        where t.studentnumber == studentnumber
                        select t;
            return query;
        }

        public List<change> queryAll()
        {
            var query = from t in dbEntity.change
                        select t;
            return query.ToList();
        }
    }
}
