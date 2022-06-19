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
    /// Dormlist_admin.xaml 的交互逻辑
    /// </summary>
    public partial class Dormlist_admin : Page
    {
        public Dormlist_admin()
        {
            InitializeComponent();
            Datagrid1.CanUserAddRows = false;
            Datagrid1.CanUserDeleteRows = false;
            Datagrid1.IsReadOnly = true;

            DormQuery dq = new DormQuery();
            Datagrid1.ItemsSource = dq.queryAll();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string area = ComboBox_area.Text;
            bool b1 = int.TryParse(TextBox_build.Text, out int build);
            bool b2 = int.TryParse(TextBox_room.Text, out int room);
            if (b1 && b2 && area != "")
            {
                DormQuery dq = new DormQuery();
                var q = dq.queryByKey(area, build, room);
                if (q.Count() > 0)
                {
                    Datagrid1.ItemsSource = q.ToList();
                }
                else
                {
                    MessageBox.Show("未查询到此宿舍");
                }
            }
            else
            {
                MessageBox.Show("请输入要查找的宿舍");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddDorm ad = new AddDorm();
            ad.ShowDialog();
            //刷新页面
            DormQuery dq = new DormQuery();
            Datagrid1.ItemsSource = dq.queryAll();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var item = Datagrid1.SelectedItem as dorm;
            if (item == null)
            {
                MessageBox.Show("请先选择要修改的宿舍");
                return;
            }
            RenewDorm rd = new RenewDorm(item.area,item.build,item.room,item.dormtype,item.peoplenumber,item.dormheader);
            rd.ShowDialog();
            //刷新页面
            DormQuery dq = new DormQuery();
            Datagrid1.ItemsSource = dq.queryAll();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var item = Datagrid1.SelectedItem as dorm;
            if (item == null)
            {
                MessageBox.Show("请先选择要删除的宿舍");
                return;
            }
            MessageBoxResult result = MessageBox.Show("确定要删除该宿舍的信息吗？", "删除确认", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                if(DormlistOperation.delDorm(item.area, item.build, item.room))
                {
                    MessageBox.Show("删除成功");
                }
                else
                {
                    MessageBox.Show("删除失败");
                }
            }
            //刷新页面
            DormQuery dq = new DormQuery();
            Datagrid1.ItemsSource = dq.queryAll();
        }
    }
}
