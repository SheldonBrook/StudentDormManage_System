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
    /// Complain_student.xaml 的交互逻辑
    /// </summary>
    public partial class Complain_student : Page
    {
        public Complain_student()
        {
            InitializeComponent();
        }

        private void complaintype_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String content = ComboBox_complaintype.SelectedItem.ToString();
            if (content.Contains("宿舍"))
            {
                #region
                Label_areadorm.Visibility = Visibility.Visible;
                ComboBox_area_dorm.Visibility = Visibility.Visible;
                Label_builddorm.Visibility = Visibility.Visible;
                TextBox_build_dorm.Visibility = Visibility.Visible;
                Label_roomdorm.Visibility = Visibility.Visible;
                TextBox_room_dorm.Visibility = Visibility.Visible;
                Label_descriptiondorm.Visibility = Visibility.Visible;
                TextBox_description_dorm.Visibility = Visibility.Visible;

                areaadmin.Visibility = Visibility.Hidden;
                ComboBox_area_admin.Visibility = Visibility.Hidden;
                buildadmin.Visibility = Visibility.Hidden;
                TextBox_build_admin.Visibility = Visibility.Hidden;
                nameadmin.Visibility = Visibility.Hidden;
                TextBox_name_admin.Visibility = Visibility.Hidden;
                descriptionadmin.Visibility = Visibility.Hidden;
                TextBox_description_admin.Visibility = Visibility.Hidden;

                complainbutton.Visibility = Visibility.Visible;
                #endregion
            }
            else
            {
                #region
                Label_areadorm.Visibility = Visibility.Hidden;
                ComboBox_area_dorm.Visibility = Visibility.Hidden;
                Label_builddorm.Visibility = Visibility.Hidden;
                TextBox_build_dorm.Visibility = Visibility.Hidden;
                Label_roomdorm.Visibility = Visibility.Hidden;
                TextBox_room_dorm.Visibility = Visibility.Hidden;
                Label_descriptiondorm.Visibility = Visibility.Hidden;
                TextBox_description_dorm.Visibility = Visibility.Hidden;

                areaadmin.Visibility = Visibility.Visible;
                ComboBox_area_admin.Visibility = Visibility.Visible;
                buildadmin.Visibility = Visibility.Visible;
                TextBox_build_admin.Visibility = Visibility.Visible;
                nameadmin.Visibility = Visibility.Visible;
                TextBox_name_admin.Visibility = Visibility.Visible;
                descriptionadmin.Visibility = Visibility.Visible;
                TextBox_description_admin.Visibility = Visibility.Visible;

                complainbutton.Visibility = Visibility.Visible;
                #endregion
            }
        }

        private void complainbutton_Click(object sender, RoutedEventArgs e)
        {
            String content = ComboBox_complaintype.SelectedItem.ToString();
            if (content.Contains("宿舍"))
            {
                String area = ComboBox_area_dorm.Text;
                bool b1 = int.TryParse(TextBox_build_dorm.Text, out int build);
                bool b2 = int.TryParse(TextBox_room_dorm.Text, out int room);
                string description = TextBox_description_dorm.Text;
                ComplainAdd ca = new ComplainAdd();
                if (ca.addComplain_dorm(area, build, room, description))
                {
                    MessageBox.Show("已提交举报");
                }
                else
                {
                    MessageBox.Show("提交举报失败");
                }
            }
            else
            {
                String area = ComboBox_area_admin.Text;
                bool b1 = int.TryParse(TextBox_build_admin.Text, out int build);
                string admin = TextBox_name_admin.Text;
                string description = TextBox_description_admin.Text;
                ComplainAdd ca = new ComplainAdd();
                if (ca.addComplain_admin(area, build, admin, description))
                {
                    MessageBox.Show("已提交举报");
                }
                else
                {
                    MessageBox.Show("提交举报失败");
                }
            }
        }
    }
}
