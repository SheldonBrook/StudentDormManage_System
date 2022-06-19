using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DormManage.DataMethod
{
    class ElectricityAdd
    {
        DormManageDataEntities dbEntity = new DormManageDataEntities();

        public bool addByKey(string area, int build, int room, float electricitymoney)
        {
            bool result = false;
            ElectricityQuery eq = new ElectricityQuery();
            if (eq.queryByKey(area, build, room).Count() > 0)
            {
                var e = dbEntity.electricity.FirstOrDefault((t) => t.area == area && t.build == build && t.room == room);
                e.money = electricitymoney + e.money;
                int i = dbEntity.SaveChanges();
                result = true;
            }
            else
            {
                MessageBox.Show("未查询到该宿舍用电信息");
            }

            return result;
        }
    }
}
