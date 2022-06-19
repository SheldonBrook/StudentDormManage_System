using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormManage.DataMethod
{
    class PasswordChange
    {
        DormManageDataEntities dbEntities = new DormManageDataEntities();

        public bool password_student(string studentnumber,string newpassword)
        {
            bool result = false;

            var s = dbEntities.login_student.FirstOrDefault((t) => t.studentnumber == studentnumber);
            s.password = newpassword;
            int i = dbEntities.SaveChanges();
            if(i > 0)
            {
                result = true;
            }
            return result;
        }

        public bool password_admin(string adminnumber, string newpassword)
        {
            bool result = false;

            var a = dbEntities.login_admin.FirstOrDefault((t) => t.adminnumber == adminnumber);
            a.password = newpassword;
            int i = dbEntities.SaveChanges();
            if (i > 0)
            {
                result = true;
            }
            return result;
        }
    }
}
