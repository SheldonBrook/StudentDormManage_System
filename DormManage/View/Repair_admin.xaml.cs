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
    /// Repair_admin.xaml 的交互逻辑
    /// </summary>
    public partial class Repair_admin : Page
    {
        public Repair_admin()
        {
            InitializeComponent();
            Datagrid1.CanUserAddRows = false;
            Datagrid1.CanUserDeleteRows = false;
            Datagrid1.IsReadOnly = true;

            RepairQuery rq = new RepairQuery();
            Datagrid1.ItemsSource = rq.queryAll();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string area = ComboBox_area.Text;
            bool b1 = int.TryParse(TextBox_build.Text, out int build);
            bool b2 = int.TryParse(TextBox_room.Text, out int room);
            if (b1 && b2 && area != "")
            {
                RepairQuery rq = new RepairQuery();
                List<repair> list = rq.queryAll().ToList();
                repair result = new repair();
                for (int i = 0; i < list.Count; i++)
                {
                    repair r = list[i];
                    if(r.area == area&& r.build == build && r.room == room)
                    {
                        result = r;
                        List<repair> l = new List<repair>();
                        l.Add(r);
                        Datagrid1.ItemsSource = l.ToList();
                    }
                    else
                    {
                        MessageBox.Show("未查找到该宿舍报修");
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
            var item = Datagrid1.SelectedItem as repair;
            if (item == null)
            {
                MessageBox.Show("请先选择要删除的报修信息");
                return;
            }
            MessageBoxResult result = MessageBox.Show("确定要删除该条报修信息吗？", "删除确认", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                if (RepairlistOperation.delRepair(item.area, item.build, item.room,item.type))
                {
                    MessageBox.Show("删除成功");
                }
                else
                {
                    MessageBox.Show("删除失败");
                }
            }
            //刷新页面
            RepairQuery rq = new RepairQuery();
            Datagrid1.ItemsSource = rq.queryAll();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var item = Datagrid1.SelectedItem as repair;
            if (item == null)
            {
                MessageBox.Show("请先选择要展示的图片");
                return;
            }
            if(item.picture != null)
            {
                ShowPicture sp = new ShowPicture(item.picture);
                sp.ShowDialog();
            }
            else
            {
                MessageBox.Show("该条报修信息没有上传图片");
            }

        }
    }
}