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
    /// Complain_admin.xaml 的交互逻辑
    /// </summary>
    public partial class Complain_admin : Page
    {
        public Complain_admin()
        {
            InitializeComponent();
            Datagrid1.CanUserAddRows = false;
            Datagrid1.CanUserDeleteRows = false;
            Datagrid1.IsReadOnly = true;
            Datagrid2.CanUserAddRows = false;
            Datagrid2.CanUserDeleteRows = false;
            Datagrid2.IsReadOnly = true;

            ComplainQuery cq = new ComplainQuery();
            Datagrid1.ItemsSource = cq.queryDormAll();
            Datagrid2.ItemsSource = cq.queryAdminAll();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string area = ComboBox_area_dorm.Text;
            bool b1 = int.TryParse(TextBox_build_dorm.Text, out int build);
            bool b2 = int.TryParse(TextBox_room.Text, out int room);
            if (b1 && b2 && area != "")
            {
                ComplainQuery cq = new ComplainQuery();
                List<complain_dorm> list = cq.queryDormAll().ToList();
                complain_dorm result = new complain_dorm();
                for (int i = 0; i < list.Count; i++)
                {
                    complain_dorm r = list[i];
                    if (r.area == area && r.build == build && r.room == room)
                    {
                        result = r;
                        List<complain_dorm> l = new List<complain_dorm>();
                        l.Add(r);
                        Datagrid1.ItemsSource = l.ToList();
                    }
                    else
                    {
                        MessageBox.Show("未查找到举报该宿舍的信息");
                    }
                }
            }
            else
            {
                MessageBox.Show("请输入要查找的宿舍");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var item = Datagrid1.SelectedItem as complain_dorm;
            if (item == null)
            {
                MessageBox.Show("请先选择要删除的举报信息");
                return;
            }
            MessageBoxResult result = MessageBox.Show("确定要删除该条举报信息吗？", "删除确认", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                if (ComplainlistOperation.delComplainDorm(item.id))
                {
                    MessageBox.Show("删除成功");
                }
                else
                {
                    MessageBox.Show("删除失败");
                }
            }
            //刷新页面
            ComplainQuery cq = new ComplainQuery();
            Datagrid1.ItemsSource = cq.queryDormAll();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string area = ComboBox_area_admin.Text;
            bool b1 = int.TryParse(TextBox_build_admin.Text, out int build);
            string admin = TextBox_admin.Text;
            if (b1 && admin != "" && area != "")
            {
                ComplainQuery cq = new ComplainQuery();
                List<complain_admin> list = cq.queryAdminAll().ToList();
                complain_admin result = new complain_admin();
                for (int i = 0; i < list.Count; i++)
                {
                    complain_admin r = list[i];
                    if (r.area == area && r.build == build && r.admin == admin)
                    {
                        result = r;
                        List<complain_admin> l = new List<complain_admin>();
                        l.Add(r);
                        Datagrid2.ItemsSource = l.ToList();
                    }
                    else
                    {
                        MessageBox.Show("未查找到举报该管理员的信息");
                    }
                }
            }
            else
            {
                MessageBox.Show("请输入要查找的宿舍");
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var item = Datagrid2.SelectedItem as complain_admin;
            if (item == null)
            {
                MessageBox.Show("请先选择要删除的举报信息");
                return;
            }
            MessageBoxResult result = MessageBox.Show("确定要删除该条举报信息吗？", "删除确认", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                if (ComplainlistOperation.delComplainAdmin(item.id))
                {
                    MessageBox.Show("删除成功");
                }
                else
                {
                    MessageBox.Show("删除失败");
                }
            }
            //刷新页面
            ComplainQuery cq = new ComplainQuery();
            Datagrid2.ItemsSource = cq.queryAdminAll();
        }
    }
}
