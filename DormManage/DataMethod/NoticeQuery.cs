using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormManage.DataMethod
{
    class NoticeQuery
    {
        DormManageDataEntities dbEntity = new DormManageDataEntities();

        public List<notice> query()
        {
            var query = from t in dbEntity.notice
                        orderby t.date descending
                        select t;
            return query.ToList();
        }
    }
}
