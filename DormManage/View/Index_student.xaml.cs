using DormManage.Connection;
using DormManage.DataMethod;
using DormManage.HelpClass;
using DormManage.ViewModel;
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
using System.Windows.Threading;

namespace DormManage.View
{
    /// <summary>
    /// Index_student.xaml 的交互逻辑
    /// </summary>
    public partial class Index_student : Page
    {
        public Index_student()
        {
            InitializeComponent();


            IndexData_student connection = new IndexData_student();
            IndexInterface_student data = connection.getData();

            Label_area.Content = data.Area;
            Label_build.Content = data.Build;
            Label_room.Content = data.Room;
            Label_dormtype.Content = data.Dormtype;
            Label_dormheader.Content = data.Dormheader;

            Label_watermonth1.Content = data.Water1;
            Label_watermonth2.Content = data.Water2;
            Label_watermonth3.Content = data.Water3;
            Label_watermonth4.Content = data.Water4;
            Label_watermoney.Content = data.Watermoney;

            Label_powermonth1.Content = data.Electricity1;
            Label_powermonth2.Content = data.Electricity2;
            Label_powermonth3.Content = data.Electricity3;
            Label_powermonth4.Content = data.Electricity4;
            Label_powermoney.Content = data.Electricitymoney;

            NoticeQuery noticeQuery = new NoticeQuery();
            List<notice> n = noticeQuery.query();//查询系统通知
            for (int i = 0; i < n.Count(); i++)
            {
                switch (i)
                {
                    case 0:
                        TextBlock_notice1.Text = n[i].content + " " + n[i].date;
                        break;
                    case 1:
                        TextBlock_notice2.Text = n[i].content + " " + n[i].date;
                        break;
                    case 2:
                        TextBlock_notice3.Text = n[i].content + " " + n[i].date;
                        break;
                    case 3:
                        TextBlock_notice4.Text = n[i].content + " " + n[i].date;
                        break;
                    case 4:
                        TextBlock_notice5.Text = n[i].content + " " + n[i].date;
                        break;
                    case 5:
                        TextBlock_notice6.Text = n[i].content + " " + n[i].date;
                        break;

                }
                
            }
            

        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            timer.Tick += new EventHandler(Time_method);
            timer.Start();
        }

    private void Time_method(object sender, EventArgs e)
        {
            TextBlock_timeblock.Text = NowTime.getNowTime();
        }
        
    }
}
