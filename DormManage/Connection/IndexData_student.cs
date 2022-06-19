using DormManage.DataMethod;
using DormManage.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DormManage.Connection
{
    class IndexData_student
    {
        static string studentnumber = SaveInfo.getId();

        public IndexInterface_student getData()
        {
            IndexInterface_student result = null;

            StudentQuery studentQuery = new StudentQuery();
            student s = studentQuery.queryByStudentnumber(studentnumber).First();//查询学生表

            DormQuery dormQuery = new DormQuery();
            dorm d = dormQuery.queryByKey(s.area, s.build, s.room).First();//查询宿舍表

            WaterQuery waterQuery = new WaterQuery();
            water w = waterQuery.queryByKey(s.area, s.build, s.room).First();//查询水表

            ElectricityQuery electricityQuery = new ElectricityQuery();
            electricity e = electricityQuery.queryByKey(s.area, s.build, s.room).First();//查询电表

            //封装数据
            string area = s.area;
            int build = s.build;
            int room = s.room;
            string dormtype = d.dormtype;
            string dormheader = d.dormheader;
            float water1 = (float)w.month1;
            float water2 = (float)w.month2;
            float water3 = (float)w.month3;
            float water4 = (float)w.month4;
            float watermoney = (float)w.money;
            float electricity1 = (float)e.month1;
            float electricity2 = (float)e.month2;
            float electricity3 = (float)e.month3;
            float electricity4 = (float)e.month4;
            float electricitymoney = (float)e.money;
            result = new IndexInterface_student(area, build, room, dormtype, dormheader, water1, water2, water3, water4, watermoney, electricity1, electricity2, electricity3, electricity4, electricitymoney);
            return result;
        }
    }
}
