using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormManage.DataMethod
{
    class StudentQuery
    {
        DormManageDataEntities dbEntity = new DormManageDataEntities();

        public IQueryable<student> queryByStudentnumber(string studentnumber)
        {
            var query = from t in dbEntity.student
                        where t.studentnumber == studentnumber
                        select t;
            return query;
        }

        public IQueryable<student> queryByNumAndNam(string studentnumber,string studentname)
        {
            var query = from t in dbEntity.student
                        where t.studentnumber == studentnumber && t.studentname == studentname
                        select t;
            return query;
        }

        public List<student> queryAll()
        {
            var query = from t in dbEntity.student
                        select t;
            return query.ToList();
        }
    }
}
