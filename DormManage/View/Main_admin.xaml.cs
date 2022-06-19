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
    /// Main_admin.xaml 的交互逻辑
    /// </summary>
    public partial class Main_admin : Window
    {
        public Main_admin()
        {
            InitializeComponent();
            AdminQuery aq = new AdminQuery();
            String adminnumber = SaveInfo.getId();
            admin a = aq.queryByAdminnumber(adminnumber).FirstOrDefault();
            if (a.picture != null)
            {
                MemoryStream ms = new MemoryStream(a.picture);
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.StreamSource = ms;
                bi.EndInit();
                Image.ImageSource = bi;
            }

            this.frame1.Source = new Uri("Dormlist_admin.xaml", UriKind.Relative);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button item = e.Source as Button;
            String content = item.Content.ToString();
            Brush gray = Brushes.Gray;
            Brush wheat = Brushes.Wheat;
            switch (content)
            {
                case "宿舍列表 ":
                    button1.Background = gray.Clone();
                    button2.Background = wheat.Clone();
                    button3.Background = wheat.Clone();
                    button4.Background = wheat.Clone();
                    button5.Background = wheat.Clone();
                    button6.Background = wheat.Clone();
                    button7.Background = wheat.Clone();
                    button8.Background = wheat.Clone();
                    this.frame1.Source = new Uri("Dormlist_admin.xaml", UriKind.Relative);
                    break;
                case "学生列表 ":
                    button2.Background = gray.Clone();
                    button1.Background = wheat.Clone();
                    button3.Background = wheat.Clone();
                    button4.Background = wheat.Clone();
                    button5.Background = wheat.Clone();
                    button6.Background = wheat.Clone();
                    button7.Background = wheat.Clone();
                    button8.Background = wheat.Clone();
                    this.frame1.Source = new Uri("Studentlist_admin.xaml", UriKind.Relative);
                    break;
                case "水电费用 ":
                    button3.Background = gray.Clone();
                    button1.Background = wheat.Clone();
                    button2.Background = wheat.Clone();
                    button4.Background = wheat.Clone();
                    button5.Background = wheat.Clone();
                    button6.Background = wheat.Clone();
                    button7.Background = wheat.Clone();
                    button8.Background = wheat.Clone();
                    this.frame1.Source = new Uri("Pay_admin.xaml", UriKind.Relative);
                    break;
                case "故障报修 ":
                    button4.Background = gray.Clone();
                    button1.Background = wheat.Clone();
                    button2.Background = wheat.Clone();
                    button3.Background = wheat.Clone();
                    button5.Background = wheat.Clone();
                    button6.Background = wheat.Clone();
                    button7.Background = wheat.Clone();
                    button8.Background = wheat.Clone();
                    this.frame1.Source = new Uri("Repair_admin.xaml", UriKind.Relative);
                    break;
                case "投诉举报 ":
                    button5.Background = gray.Clone();
                    button1.Background = wheat.Clone();
                    button2.Background = wheat.Clone();
                    button3.Background = wheat.Clone();
                    button4.Background = wheat.Clone();
                    button6.Background = wheat.Clone();
                    button7.Background = wheat.Clone();
                    button8.Background = wheat.Clone();
                    this.frame1.Source = new Uri("Complain_admin.xaml", UriKind.Relative);
                    break;
                case "转宿申请 ":
                    button6.Background = gray.Clone();
                    button1.Background = wheat.Clone();
                    button2.Background = wheat.Clone();
                    button3.Background = wheat.Clone();
                    button4.Background = wheat.Clone();
                    button5.Background = wheat.Clone();
                    button7.Background = wheat.Clone();
                    button8.Background = wheat.Clone();
                    this.frame1.Source = new Uri("Move_admin.xaml", UriKind.Relative);
                    break;
                case "用户设置 ":
                    button7.Background = gray.Clone();
                    button1.Background = wheat.Clone();
                    button2.Background = wheat.Clone();
                    button3.Background = wheat.Clone();
                    button4.Background = wheat.Clone();
                    button5.Background = wheat.Clone();
                    button6.Background = wheat.Clone();
                    button8.Background = wheat.Clone();
                    this.frame1.Source = new Uri("Setting_admin.xaml", UriKind.Relative);
                    break;
                case "系统通知 ":
                    button8.Background = gray.Clone();
                    button1.Background = wheat.Clone();
                    button2.Background = wheat.Clone();
                    button3.Background = wheat.Clone();
                    button4.Background = wheat.Clone();
                    button5.Background = wheat.Clone();
                    button6.Background = wheat.Clone();
                    button7.Background = wheat.Clone();
                    this.frame1.Source = new Uri("Notice_admin.xaml", UriKind.Relative);
                    break;
            }
        }
    }
}
