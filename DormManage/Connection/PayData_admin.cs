using DormManage.DataMethod;
using DormManage.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormManage.Connection
{
    class PayData_admin
    {
        WaterQuery wq = new WaterQuery();
        ElectricityQuery eq = new ElectricityQuery();
        
        public List<PayInterface_admin> getData()
        {
            List<PayInterface_admin> result = new List<PayInterface_admin>();

            List<water> w = wq.queryAll();
            for (int i = 0; i < w.Count; i++)
            {
                water w1 = w[i];
                electricity e1 = eq.queryByKey(w1.area, w1.build, w1.room).FirstOrDefault();
                float.TryParse(w1.money.ToString(), out float watermoney);
                float.TryParse(e1.money.ToString(), out float electricitymoney);
                PayInterface_admin pa = new PayInterface_admin(w1.area, w1.build, w1.room, watermoney, electricitymoney);
                result.Add(pa);
            }
            return result;
        }
    }
}
