using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DormManage.DataMethod
{
    class WaterAdd
    {
        DormManageDataEntities dbEntity = new DormManageDataEntities();

        public bool addByKey(string area,int build,int room,float watermoney)
        {
            bool result = false;
            WaterQuery wq = new WaterQuery();
            if(wq.queryByKey(area, build, room).Count() > 0)
            {
                //water w = wq.queryByKey(area, build, room).FirstOrDefault();
                var w = dbEntity.water.FirstOrDefault((t) => t.area == area && t.build == build && t.room == room);
                w.money = watermoney + w.money;
                dbEntity.SaveChanges();
                result = true;
            }
            else
            {
                MessageBox.Show("未查询到该宿舍用水信息");
            }

            return result;
        }
    }
}
