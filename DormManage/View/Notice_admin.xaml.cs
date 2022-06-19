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
    /// Notice_admin.xaml 的交互逻辑
    /// </summary>
    public partial class Notice_admin : Page
    {
        public Notice_admin()
        {
            InitializeComponent();
            Datagrid1.CanUserAddRows = false;
            Datagrid1.CanUserDeleteRows = false;
            Datagrid1.IsReadOnly = true;

            NoticeQuery nq = new NoticeQuery();
            Datagrid1.ItemsSource = nq.query();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string content = TextBox_content.Text;
            DateTime date = DateTime.Now;
            if(content != "")
            {
                if(NoticelistOperation.addNotice(content, date))
                {
                    MessageBox.Show("通知已发布");
                    NoticeQuery nq = new NoticeQuery();
                    Datagrid1.ItemsSource = nq.query();
                }
                else
                {
                    MessageBox.Show("通知发布失败");
                }
            }
            else
            {
                MessageBox.Show("请输入通知内容");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var item = Datagrid1.SelectedItem as notice;
            if (item == null)
            {
                MessageBox.Show("请先选择要删除的通知");
                return;
            }
            MessageBoxResult result = MessageBox.Show("确定要删除该条通知吗？", "删除确认", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                if (NoticelistOperation.delNotice(item.id))
                {
                    MessageBox.Show("删除成功");
                }
                else
                {
                    MessageBox.Show("删除失败");
                }
            }
            //刷新页面
            NoticeQuery nq = new NoticeQuery();
            Datagrid1.ItemsSource = nq.query();
        }
    }
}
