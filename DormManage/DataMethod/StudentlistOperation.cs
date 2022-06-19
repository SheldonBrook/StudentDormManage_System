using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DormManage.DataMethod
{
    static class StudentlistOperation
    {
        static DormManageDataEntities dbEntities = new DormManageDataEntities();
        public static bool addStudent(string area, int build, int room, string studentnumber,string studentname)
        {
            bool result = false;
            StudentQuery sq = new StudentQuery();
            if (sq.queryByStudentnumber(studentnumber).Count() > 0)
            {
                MessageBox.Show("学生已存在");
            }
            else
            {
                DormQuery dq = new DormQuery();
                if (dq.queryByKey(area, build, room).Count() > 0)
                {
                    student s = new student
                    {
                        area = area,
                        build = build,
                        room = room,
                        studentname = studentname,
                        studentnumber = studentnumber,
                    };
                    dbEntities.student.Add(s);  //插入
                    dbEntities.SaveChanges(); //保存
                    result = true;
                }
                else
                {
                    MessageBox.Show("该宿舍不存在");
                }
            }
            return result;
        }
        public static bool renewStudent(string area, int build, int room, string studentnumber, string studentname)
        {
            bool result = false;

            var s = dbEntities.student.FirstOrDefault((t) => t.studentnumber == studentnumber);
            s.area = area;
            s.build = build;
            s.room = room;
            s.studentname = studentname;
            int i = dbEntities.SaveChanges();
            if (i > 0)
            {
                result = true;
            }
            return result;
        }
        public static bool delStudent(string studentnumber)
        {
            bool result = false;
            var s = dbEntities.student.FirstOrDefault((t) => t.studentnumber == studentnumber);
            dbEntities.student.Remove(s);
            int i = dbEntities.SaveChanges();
            if (i > 0)
            {
                result = true;
            }
            return result;
        }
        public static bool delLogin(string studentnumber)
        {
            bool result = false;
            var s = dbEntities.login_student.FirstOrDefault((t) => t.studentnumber == studentnumber);
            dbEntities.login_student.Remove(s);
            int i = dbEntities.SaveChanges();
            if (i > 0)
            {
                result = true;
            }
            return result;
        }

        public static bool addDormNumber(string area, int build, int room)
        {
            bool result = false;
            var w = dbEntities.dorm.FirstOrDefault((t) => t.area == area && t.build == build && t.room == room);
            w.peoplenumber = 1 + w.peoplenumber;
            int i = dbEntities.SaveChanges();
            if (i > 0)
            {
                result = true;
            }
            return result;
        }
        public static bool delDormNumber(string area, int build, int room)
        {
            bool result = false;
            var w = dbEntities.dorm.FirstOrDefault((t) => t.area == area && t.build == build && t.room == room);
            w.peoplenumber = w.peoplenumber - 1;
            int i = dbEntities.SaveChanges();
            if (i > 0)
            {
                result = true;
            }
            return result;
        }
    }
}
