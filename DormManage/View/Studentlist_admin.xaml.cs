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
    /// Studentlist_admin.xaml 的交互逻辑
    /// </summary>
    public partial class Studentlist_admin : Page
    {
        public Studentlist_admin()
        {
            InitializeComponent();
            Datagrid1.CanUserAddRows = false;
            Datagrid1.CanUserDeleteRows = false;
            Datagrid1.IsReadOnly = true;

            StudentQuery sq = new StudentQuery();
            Datagrid1.ItemsSource = sq.queryAll();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string studentnumber = TextBox_studentnumber.Text;
            string studentname = TextBox_studentname.Text;
            if (studentnumber != "" && studentname != "")
            {
                StudentQuery sq = new StudentQuery();
                var q = sq.queryByNumAndNam(studentnumber, studentname);
                if (q.Count() > 0)
                {
                    Datagrid1.ItemsSource = q.ToList();
                }
                else
                {
                    MessageBox.Show("未查询到此学生");
                }
            }
            else
            {
                MessageBox.Show("请输入要查找的学生");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddStudent s = new AddStudent();
            s.ShowDialog();
            //刷新页面
            StudentQuery sq = new StudentQuery();
            Datagrid1.ItemsSource = sq.queryAll();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var item = Datagrid1.SelectedItem as student;
            if (item == null)
            {
                MessageBox.Show("请先选择要修改的学生");
                return;
            }
            RenewStudent rs = new RenewStudent(item.area, item.build, item.room, item.studentnumber, item.studentname);
            rs.ShowDialog();
            //刷新页面
            StudentQuery sq = new StudentQuery();
            Datagrid1.ItemsSource = sq.queryAll();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var item = Datagrid1.SelectedItem as student;
            if (item == null)
            {
                MessageBox.Show("请先选择要删除的学生");
                return;
            }
            MessageBoxResult result = MessageBox.Show("确定要删除该学生的信息吗？", "删除确认", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                if (StudentlistOperation.delStudent(item.studentnumber))
                {
                    StudentlistOperation.delDormNumber(item.area, item.build, item.room);
                    StudentlistOperation.delLogin(item.studentnumber);
                    MessageBox.Show("删除成功");
                }
                else
                {
                    MessageBox.Show("删除失败");
                }
            }
            //刷新页面
            StudentQuery sq = new StudentQuery();
            Datagrid1.ItemsSource = sq.queryAll();
        }
    }
}
