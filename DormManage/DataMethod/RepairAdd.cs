using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DormManage.DataMethod
{
    class RepairAdd
    {
        DormManageDataEntities dbEntities = new DormManageDataEntities();

        public bool addRepair(string area,int build,int room,string type,DateTime date,string phone)
        {
            bool result = false;
            DormQuery dq = new DormQuery();
            if (dq.queryByKey(area, build, room).Count() > 0)
            {
                repair d = new repair
                {
                    area = area,
                    build = build,
                    room = room,
                    type = type,
                    date = date,
                    phone = phone
                };
                dbEntities.repair.Add(d);  //插入
                dbEntities.SaveChanges(); //保存
                result = true;
            }
            else
            {
                MessageBox.Show("未查询到此宿舍");
            }

            return result;
        }
        public bool addRepairWithPicture(string area, int build, int room, string type, DateTime date, string phone, string photofilePath)
        {
            bool result = false;
            DormQuery dq = new DormQuery();
            if (dq.queryByKey(area, build, room).Count() > 0)
            {
                Stream mystream = File.OpenRead(photofilePath);
                byte[] bt = new byte[mystream.Length];
                mystream.Read(bt, 0, (int)mystream.Length);

                repair d = new repair
                {
                    area = area,
                    build = build,
                    room = room,
                    type = type,
                    date = date,
                    phone = phone,
                    picture = bt
                };
                dbEntities.repair.Add(d);  //插入
                dbEntities.SaveChanges(); //保存
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
