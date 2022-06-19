using DormManage.DataMethod;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Setting_student.xaml 的交互逻辑
    /// </summary>
    public partial class Setting_student : Page
    {
        string studentnumber = SaveInfo.getId();
        DormManageDataEntities dbEntities = new DormManageDataEntities();
        public Setting_student()
        {
            InitializeComponent();
            
            StudentQuery sq = new StudentQuery();
            student s = sq.queryByStudentnumber(studentnumber).FirstOrDefault();
            if (s.picture != null)
            {
                MemoryStream ms = new MemoryStream(s.picture);
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.StreamSource = ms;
                bi.EndInit();
                Image1.ImageSource = bi;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string password = PasswordBox_password.Password;
            string newpassword = PasswordBox_newpassword.Password;
            string surepassword = PasswordBox_surepassword.Password;

            if(newpassword == surepassword)
            {
                if(LoginQuery.loginQuery_student(studentnumber, password))
                {
                    PasswordChange pc = new PasswordChange();
                    if (pc.password_student(studentnumber, newpassword))
                    {
                        MessageBox.Show("修改成功，下次登入生效");
                    }
                    else
                    {
                        MessageBox.Show("修改失败");
                    }
                }
                else
                {
                    MessageBox.Show("原密码输入错误");
                }
            }
            else
            {
                MessageBox.Show("两次输入新密码不一致");
            }
        }

        string photofilePath = "";
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == true)
            {
                photofilePath = ofd.FileName;
                //图像显示到image控件内
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.UriSource = new Uri(photofilePath, UriKind.RelativeOrAbsolute);
                bi.EndInit();
                Image1.ImageSource = bi;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (photofilePath != "")
            {
                Stream mystream = File.OpenRead(photofilePath);
                byte[] bt = new byte[mystream.Length];
                mystream.Read(bt, 0, (int)mystream.Length);
                var s = dbEntities.student.FirstOrDefault((t) => t.studentnumber == studentnumber);
                s.picture = bt;
                int i = dbEntities.SaveChanges();
                if (i > 0)
                {
                    MessageBox.Show("修改成功");
                    MemoryStream ms = new MemoryStream(s.picture);
                    BitmapImage bi = new BitmapImage();
                    bi.BeginInit();
                    bi.StreamSource = ms;
                    bi.EndInit();
                    Image1.ImageSource = bi;
                    var window = (Main_student)Window.GetWindow(this);//获得页面的父类窗口
                    window.Image.ImageSource = bi;
                }
                else
                {
                    MessageBox.Show("修改失败");
                }
            }
            else
            {
                MessageBox.Show("请选择图片");
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var window = (Main_student)Window.GetWindow(this);//获得页面的父类窗口
            Login login = new Login();
            window.Close();
            login.ShowDialog();
        }
    }
}
