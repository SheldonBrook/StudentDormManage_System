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
    /// RenewStudent.xaml 的交互逻辑
    /// </summary>
    public partial class RenewStudent : Window
    {
        public RenewStudent()
        {
            InitializeComponent();
        }

        public RenewStudent(string area, int buil, int room, string studentnumber,string studentname)
        {
            InitializeComponent();
            ComboBox_area.Text = area;
            TextBox_build.Text = buil.ToString();
            TextBox_room.Text = room.ToString();
            TextBox_studentnumber.Text = studentnumber;
            TextBox_studentname.Text = studentname;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string area = ComboBox_area.Text;
            bool b1 = int.TryParse(TextBox_build.Text, out int build);
            bool b2 = int.TryParse(TextBox_room.Text, out int room);
            string studentnumber = TextBox_studentnumber.Text;
            string studentname = TextBox_studentname.Text;
            if (area != "" && b1 && b2 && studentname != "")
            {
                if (StudentlistOperation.renewStudent(area, build, room, studentnumber, studentname))
                {
                    MessageBox.Show("修改成功");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("修改失败");
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
