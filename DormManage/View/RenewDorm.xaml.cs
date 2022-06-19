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
    /// RenewDorm.xaml 的交互逻辑
    /// </summary>
    public partial class RenewDorm : Window
    {
        public RenewDorm()
        {
            InitializeComponent();
        }
        public RenewDorm(string area,int buil,int room,string type,int people,string dormheader)
        {
            InitializeComponent();
            ComboBox_area.Text = area;
            TextBox_build.Text = buil.ToString();
            TextBox_room.Text = room.ToString();
            ComboBox_tpye.Text = type;
            TextBox_people.Text = people.ToString();
            TextBox_dormheader.Text = dormheader;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string area = ComboBox_area.Text;
            bool b1 = int.TryParse(TextBox_build.Text, out int build);
            bool b2 = int.TryParse(TextBox_room.Text, out int room);
            string dormtype = ComboBox_tpye.Text;
            bool b3 = int.TryParse(TextBox_people.Text, out int peoplenumber);
            string dormheader = TextBox_dormheader.Text;
            if(dormtype != "" && b3 && dormheader != "")
            {
                if(DormlistOperation.renewDorm(area, build, room, dormtype, peoplenumber, dormheader))
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
