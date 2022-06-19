using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DormManage.DataMethod
{
    class MoveAdd
    {
        DormManageDataEntities Entities = new DormManageDataEntities();

        public bool addMove(string studentnumber,string studentname,string area,int build,int room,string description)
        {
            bool result = false;

            DormQuery dq = new DormQuery();
            if (dq.queryByKey(area, build, room).Count() > 0)
            {

                change c = new change
                {
                    studentnumber = studentnumber,
                    studentname = studentname,
                    area = area,
                    build = build,
                    room = room,
                    description = description
                };
                Entities.change.Add(c);  //插入
                Entities.SaveChanges(); //保存
                result = true;
            }
            else
            {
                MessageBox.Show("未查询到此宿舍");
            }

            return result;
        }
    }
}
