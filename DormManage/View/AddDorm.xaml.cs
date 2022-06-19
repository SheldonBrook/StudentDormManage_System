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
    /// AddDorm.xaml 的交互逻辑
    /// </summary>
    public partial class AddDorm : Window
    {
        public AddDorm()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string area = ComboBox_area.Text;
            bool b1 = int.TryParse(TextBox_build.Text, out int build);
            bool b2 = int.TryParse(TextBox_room.Text, out int room);
            string dormtype = ComboBox_tpye.Text;
            bool b3 = int.TryParse(TextBox_people.Text, out int peoplenumber);
            string dormheader = TextBox_dormheader.Text;
            if(b1 && b2 && b3 && area !="" && dormtype != "" && dormheader != "")
            {
                if(DormlistOperation.addDorm(area, build, room, dormtype, peoplenumber, dormheader))
                {
                    MessageBox.Show("添加成功");
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
