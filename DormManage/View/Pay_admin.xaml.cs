using DormManage.Connection;
using DormManage.DataMethod;
using DormManage.ViewModel;
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
    /// Pay_admin.xaml 的交互逻辑
    /// </summary>
    public partial class Pay_admin : Page
    {
        public Pay_admin()
        {
            InitializeComponent();
            Datagrid1.CanUserAddRows = false;
            Datagrid1.CanUserDeleteRows = false;
            Datagrid1.IsReadOnly = true;

            PayData_admin pa = new PayData_admin();
            List<PayInterface_admin> list = pa.getData();
            Datagrid1.ItemsSource = list.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string area = ComboBox_area.Text;
            bool b1 = int.TryParse(TextBox_build.Text, out int build);
            bool b2 = int.TryParse(TextBox_room.Text, out int room);

            PayData_admin pa = new PayData_admin();
            List<PayInterface_admin> list = pa.getData();
            PayInterface_admin result = new PayInterface_admin();

            if (b1 && b2 && area != "")
            {
                for (int i = 0; i < list.Count(); i++)
                {
                    PayInterface_admin p = list[i];
                    if (p.Area == area && p.Build == build && p.Room == room)
                    {
                        result = p;
                    }
                }
                if(result.Area != null)
                {
                    List<PayInterface_admin> l = new List<PayInterface_admin>();
                    l.Add(result);
                    Datagrid1.ItemsSource = l.ToList();
                }
                else
                {
                    MessageBox.Show("未查找到该宿舍");
                }
            }
            else
            {
                MessageBox.Show("请输入要查找的宿舍");
            }
        }
    }
}
