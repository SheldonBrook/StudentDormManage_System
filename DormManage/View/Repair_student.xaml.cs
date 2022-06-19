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
    /// Repair_student.xaml 的交互逻辑
    /// </summary>
    public partial class Repair_student : Page
    {
        public Repair_student()
        {
            InitializeComponent();
        }

        private void repairbutton_Click(object sender, RoutedEventArgs e)
        {
            string tpye = ComboBox_type.Text;
            string area = ComboBox_area.Text;
            string phone = TextBox_phone.Text;

            bool b1 = int.TryParse(TextBox_build.Text, out int build);
            bool b2 = int.TryParse(TextBox_room.Text, out int room);
            try
            {
                DateTime date = (DateTime)DatePicker_date.SelectedDate;//空异常
                if (b1 && b2 && date != null && tpye != "" && area != "" && phone != "")
                {
                    RepairQuery rq = new RepairQuery();
                    if (rq.queryRepeat(area, build, room, tpye).Count() > 0)
                    {
                        MessageBox.Show("宿舍已申请维修此项目，不可以重复报修，请等候维修");
                    }
                    else
                    {
                        if (photofilePath != "")
                        {
                            RepairAdd ra = new RepairAdd();
                            if (ra.addRepairWithPicture(area, build, room, tpye, date, phone, photofilePath))
                            {
                                MessageBox.Show("已上报维修");
                            }
                            else
                            {
                                MessageBox.Show("上报维修失败");
                            }
                        }
                        else
                        {
                            RepairAdd ra = new RepairAdd();
                            if (ra.addRepair(area, build, room, tpye, date, phone))
                            {
                                MessageBox.Show("已上报维修");
                            }
                            else
                            {
                                MessageBox.Show("上报维修失败");
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("请检查输入");
                }
            }
            catch
            {
                MessageBox.Show("请检查输入");
            }
        }

        string photofilePath = "";
        private void uplode_Click(object sender, RoutedEventArgs e)
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
                Image.Source = bi;
            }
        }
    }
}
