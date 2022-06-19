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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DormManage.View
{
    /// <summary>
    /// Pay_student.xaml 的交互逻辑
    /// </summary>
    public partial class Pay_student : Page
    {
        public Pay_student()
        {
            InitializeComponent();
        }

        private void paybutton_Click(object sender, RoutedEventArgs e)
        {
            string tpye = ComboBox_paytype.Text;
            string area = ComboBox_area.Text;

            bool b1 = int.TryParse(TextBox_build.Text, out int build);
            bool b2 = int.TryParse(TextBox_room.Text, out int room);
            bool b3 = float.TryParse(TextBox_paymoney.Text, out float money);

            if (b1 && b2 && b3 && tpye != "" && area != "")
            {
                if(tpye == "水费")
                {
                    WaterAdd wa = new WaterAdd();
                    if (wa.addByKey(area, build, room, money))
                    {
                        WaterQuery wq = new WaterQuery();
                        water w2 = wq.queryByKey(area, build, room).FirstOrDefault();//更新后再次查询
                        MessageBox.Show(string.Format("充值成功，现有水费{0}元", w2.money));
                    }
                    else
                    {
                        MessageBox.Show("充值失败");
                    }
                }
                else
                {
                    ElectricityAdd ea = new ElectricityAdd();
                    if (ea.addByKey(area, build, room, money))
                    {
                        ElectricityQuery eq = new ElectricityQuery();
                        electricity e2 = eq.queryByKey(area, build, room).FirstOrDefault();//更新后再次查询
                        MessageBox.Show(string.Format("充值成功，现有电费{0}元", e2.money));
                    }
                    else
                    {
                        MessageBox.Show("充值失败");
                    }
                }
                
            }
            else
            {
                MessageBox.Show("请检查输入");
            }
        }
    }
}
