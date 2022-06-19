using DormManage.DataMethod;
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
using System.Windows.Shapes;

namespace DormManage.View
{
    /// <summary>
    /// Main_student.xaml 的交互逻辑
    /// </summary>
    public partial class Main_student : Window
    {
        public Main_student()
        {
            InitializeComponent();

            StudentQuery sq = new StudentQuery();
            String studentnumber = SaveInfo.getId();
            student s = sq.queryByStudentnumber(studentnumber).FirstOrDefault();
            if(s.picture != null)
            {
                MemoryStream ms = new MemoryStream(s.picture);
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.StreamSource = ms;
                bi.EndInit();
                Image.ImageSource = bi;
            }

            this.frame1.Source = new Uri("Index_student.xaml", UriKind.Relative);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button item = e.Source as Button;
            String content = item.Content.ToString();
            Brush gray = Brushes.Gray;
            Brush wheat = Brushes.Wheat;
            switch(content)
            {
                case "我的首页 ":
                    button1.Background = gray.Clone();
                    button2.Background = wheat.Clone();
                    button3.Background = wheat.Clone();
                    button4.Background = wheat.Clone();
                    button5.Background = wheat.Clone();
                    button6.Background = wheat.Clone();
                    this.frame1.Source = new Uri("Index_student.xaml", UriKind.Relative);
                    break;
                case "生活缴费 ":
                    button2.Background = gray.Clone();
                    button1.Background = wheat.Clone();
                    button3.Background = wheat.Clone();
                    button4.Background = wheat.Clone();
                    button5.Background = wheat.Clone();
                    button6.Background = wheat.Clone();
                    this.frame1.Source = new Uri("Pay_student.xaml", UriKind.Relative);
                    break;
                case "故障报修 ":
                    button3.Background = gray.Clone();
                    button1.Background = wheat.Clone();
                    button2.Background = wheat.Clone();
                    button4.Background = wheat.Clone();
                    button5.Background = wheat.Clone();
                    button6.Background = wheat.Clone();
                    this.frame1.Source = new Uri("Repair_student.xaml", UriKind.Relative);
                    break;
                case "投诉举报 ":
                    button4.Background = gray.Clone();
                    button1.Background = wheat.Clone();
                    button2.Background = wheat.Clone();
                    button3.Background = wheat.Clone();
                    button5.Background = wheat.Clone();
                    button6.Background = wheat.Clone();
                    this.frame1.Source = new Uri("Complain_student.xaml", UriKind.Relative);
                    break;
                case "转宿申请 ":
                    button5.Background = gray.Clone();
                    button1.Background = wheat.Clone();
                    button2.Background = wheat.Clone();
                    button3.Background = wheat.Clone();
                    button4.Background = wheat.Clone();
                    button6.Background = wheat.Clone();
                    this.frame1.Source = new Uri("Move_student.xaml", UriKind.Relative);
                    break;
                case "用户设置 ":
                    button6.Background = gray.Clone();
                    button1.Background = wheat.Clone();
                    button2.Background = wheat.Clone();
                    button3.Background = wheat.Clone();
                    button4.Background = wheat.Clone();
                    button5.Background = wheat.Clone();
                    this.frame1.Source = new Uri("Setting_student.xaml", UriKind.Relative);
                    break;
            }
        }
    }
}
