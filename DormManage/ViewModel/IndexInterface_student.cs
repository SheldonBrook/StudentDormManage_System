using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormManage.ViewModel
{
    class IndexInterface_student
    {
        private string area;
        private int build;
        private int room;
        private string dormtype;
        private string dormheader;

        private float water1;
        private float water2;
        private float water3;
        private float water4;
        private float watermoney;

        private float electricity1;
        private float electricity2;
        private float electricity3;
        private float electricity4;
        private float electricitymoney;

        public IndexInterface_student(string area, int build, int room, string dormtype, string dormheader, float water1, float water2, float water3, float water4, float watermoney, float electricity1, float electricity2, float electricity3, float electricity4, float electricitymoney)
        {
            this.area = area;
            this.build = build;
            this.room = room;
            this.dormtype = dormtype;
            this.dormheader = dormheader;
            this.water1 = water1;
            this.water2 = water2;
            this.water3 = water3;
            this.water4 = water4;
            this.watermoney = watermoney;
            this.electricity1 = electricity1;
            this.electricity2 = electricity2;
            this.electricity3 = electricity3;
            this.electricity4 = electricity4;
            this.electricitymoney = electricitymoney;
        }

        public string Area { get => area; set => area = value; }
        public int Build { get => build; set => build = value; }
        public int Room { get => room; set => room = value; }
        public string Dormtype { get => dormtype; set => dormtype = value; }
        public string Dormheader { get => dormheader; set => dormheader = value; }
        public float Water1 { get => water1; set => water1 = value; }
        public float Water2 { get => water2; set => water2 = value; }
        public float Water3 { get => water3; set => water3 = value; }
        public float Water4 { get => water4; set => water4 = value; }
        public float Watermoney { get => watermoney; set => watermoney = value; }
        public float Electricity1 { get => electricity1; set => electricity1 = value; }
        public float Electricity2 { get => electricity2; set => electricity2 = value; }
        public float Electricity3 { get => electricity3; set => electricity3 = value; }
        public float Electricity4 { get => electricity4; set => electricity4 = value; }
        public float Electricitymoney { get => electricitymoney; set => electricitymoney = value; }
    }
}
