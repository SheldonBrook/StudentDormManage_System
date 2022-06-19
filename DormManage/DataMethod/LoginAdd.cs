using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormManage.DataMethod
{
    class LoginAdd
    {
        DormManageDataEntities dbEntities = new DormManageDataEntities();

        public bool addLogin_student(string studentnumber)
        {
            bool result = false;
            login_student ls = new login_student
            {
                studentnumber = studentnumber,
                password = "123456"
            };
            dbEntities.login_student.Add(ls);  //插入
            int i = dbEntities.SaveChanges(); //保存
            if (i > 0)
            {
                result = true;
            }
            return result;
        }
    }
}
