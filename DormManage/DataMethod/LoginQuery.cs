using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormManage.DataMethod
{
    class LoginQuery
    {
        static DormManageDataEntities dbEntity = new DormManageDataEntities();

        public static bool loginQuery_student(string studentnumber,string password)
        {
            bool result = false;
            var query = from t in dbEntity.login_student
                        where t.studentnumber == studentnumber && t.password == password
                        select t;
            if (query.Count() > 0)
            {
                result = true;
            }
            return result;
        }
        public static bool loginQuery_studentByKey(string studentnumber)
        {
            bool result = false;
            var query = from t in dbEntity.login_student
                        where t.studentnumber == studentnumber
                        select t;
            if (query.Count() > 0)
            {
                result = true;
            }
            return result;
        }
        public static bool loginQuery_admin(string adminnumber, string password)
        {
            bool result = false;
            var query = from t in dbEntity.login_admin
                        where t.adminnumber == adminnumber && t.password == password
                        select t;
            if (query.Count() > 0)
            {
                result = true;
            }
            return result;
        }

    }
}
