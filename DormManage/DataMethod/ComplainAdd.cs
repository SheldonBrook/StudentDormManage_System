using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DormManage.DataMethod
{
    class ComplainAdd
    {
        DormManageDataEntities dbEntities = new DormManageDataEntities();

        public bool addComplain_dorm(string area,int build, int room,string description)
        {
            bool result = false;
            DormQuery dq = new DormQuery();
            if (dq.queryByKey(area, build, room).Count() > 0)
            {
                complain_dorm cd = new complain_dorm
                {
                    area = area,
                    build = build,
                    room = room,
                    description = description
                };
                dbEntities.complain_dorm.Add(cd);  //插入
                dbEntities.SaveChanges(); //保存
                result = true;
            }
            else
            {
                MessageBox.Show("未查询到此宿舍");
            }

            return result;
        }

        public bool addComplain_admin(string area, int build, string admin, string description)
        {
            bool result = false;
            AdminQuery aq = new AdminQuery();
            if (aq.queryByKey(area, build, admin).Count() > 0)
            {
                complain_admin ca = new complain_admin
                {
                    area = area,
                    build = build,
                    admin = admin,
                    description = description
                };
                dbEntities.complain_admin.Add(ca);  //插入
                dbEntities.SaveChanges(); //保存
                result = true;
            }
            else
            {
                MessageBox.Show("未查询到此管理员");
            }

            return result;
        }
    }
}
