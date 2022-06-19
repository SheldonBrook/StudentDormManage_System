using DormManage.DataMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DormManage.View
{
    /// <summary>
    /// AddStudent.xaml 的交互逻辑
    /// </summary>
    public partial class AddStudent : Window
    {
        public AddStudent()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string studentnumber = TextBox_studentnumber.Text;
            string studentname = TextBox_studentname.Text;
            string area = ComboBox_area.Text;
            bool b1 = int.TryParse(TextBox_build.Text, out int build);
            bool b2 = int.TryParse(TextBox_room.Text, out int room);

            if (b1 && b2 && studentnumber != "" && studentname != "" && area != "")
            {
                if (StudentlistOperation.addStudent(area, build, room,studentnumber,studentname))
                {
                    StudentlistOperation.addDormNumber(area, build, room);
                    if (LoginQuery.loginQuery_studentByKey(studentnumber))
                    {
                        MessageBox.Show("系统已为该生注册登入，默认密码为：123456");
                    }
                    else
                    {
                        LoginAdd la = new LoginAdd();
                        la.addLogin_student(studentnumber);
                        MessageBox.Show("添加成功，系统已录入，其登入密码默认为：123456");
                    }
                    this.Close();
                }
                else
                {
                    MessageBox.Show("添加失败");
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("请检查输入");
            }
        }
    }
}
