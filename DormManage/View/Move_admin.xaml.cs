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
    /// Move_admin.xaml 的交互逻辑
    /// </summary>
    public partial class Move_admin : Page
    {
        public Move_admin()
        {
            InitializeComponent();
            Datagrid1.CanUserAddRows = false;
            Datagrid1.CanUserDeleteRows = false;
            Datagrid1.IsReadOnly = true;

            MoveQuery mq = new MoveQuery();
            Datagrid1.ItemsSource = mq.queryAll();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string studentnumber = TextBox_studentnumber.Text;
            if (studentnumber != "")
            {
                MoveQuery mq = new MoveQuery();
                List<change> list = mq.queryAll().ToList();
                change result = new change();
                for (int i = 0; i < list.Count; i++)
                {
                    change r = list[i];
                    if (r.studentnumber == studentnumber)
                    {
                        result = r;
                        List<change> l = new List<change>();
                        l.Add(r);
                        Datagrid1.ItemsSource = l.ToList();
                    }
                    else
                    {
                        MessageBox.Show("未查找到该学生的转宿申请");
                    }
                }
            }
            else
            {
                MessageBox.Show("请输入要查找的学生学号");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var item = Datagrid1.SelectedItem as change;
            if (item == null)
            {
                MessageBox.Show("请先选择要删除的转宿申请");
                return;
            }
            MessageBoxResult result = MessageBox.Show("确定要删除该条转宿申请吗？", "删除确认", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                if (MovelistOperation.delMove(item.studentnumber))
                {
                    MessageBox.Show("删除成功");
                }
                else
                {
                    MessageBox.Show("删除失败");
                }
            }
            //刷新页面
            MoveQuery mq = new MoveQuery();
            Datagrid1.ItemsSource = mq.queryAll();
        }
    }
}
