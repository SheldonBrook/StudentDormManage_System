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
    /// Login.xaml 的交互逻辑
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            if (identity.SelectedItem.ToString().Contains("学生"))
            {
                string studentnumber = TextBox_number.Text;
                string password = PasswordBox.Password;
                if (LoginQuery.loginQuery_student(studentnumber, password))
                {
                    SaveInfo.setId(studentnumber);//用以储存用户输入的唯一身份标识
                    Main_student mainInterface = new Main_student();
                    this.Close();
                    mainInterface.ShowDialog();
                }
                else
                {
                    MessageBox.Show("此用户不存在,或密码错误");
                }
            }
            else
            {
                string adminnumber = TextBox_number.Text;
                string password = PasswordBox.Password;
                if (LoginQuery.loginQuery_admin(adminnumber, password))
                {
                    SaveInfo.setId(adminnumber);//用以储存用户输入的唯一身份标识
                    Main_admin mainInterface = new Main_admin();
                    this.Close();
                    mainInterface.ShowDialog();
                }
                else
                {
                    MessageBox.Show("此用户不存在,或密码错误");
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
