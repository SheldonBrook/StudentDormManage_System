using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormManage.ViewModel
{
    class PayInterface_admin
    {
        private string area;
        private int build;
        private int room;
        private float watermoney;
        private float electricitymoney;

        public PayInterface_admin()
        {

        }
        public PayInterface_admin(string area, int build, int room, float watermoney, float electricitymoney)
        {
            this.area = area;
            this.build = build;
            this.room = room;
            this.watermoney = watermoney;
            this.electricitymoney = electricitymoney;
        }
        public string Area { get => area; set => area = value; }
        public int Build { get => build; set => build = value; }
        public int Room { get => room; set => room = value; }
        public float Watermoney { get => watermoney; set => watermoney = value; }
        public float Electricitymoney { get => electricitymoney; set => electricitymoney = value; }
    }
}
