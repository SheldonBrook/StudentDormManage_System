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
    /// Move_student.xaml 的交互逻辑
    /// </summary>
    public partial class Move_student : Page
    {
        public Move_student()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string studentnumber = SaveInfo.getId();
            StudentQuery sq = new StudentQuery();
            string studentname = sq.queryByStudentnumber(studentnumber).FirstOrDefault().studentname;
            string area = ComboBox_area.Text;
            bool b1 = int.TryParse(TextBox_build.Text, out int build);
            bool b2 = int.TryParse(TextBox_room.Text, out int room);
            string description = TextBox_description.Text;
            if(b1&&b2&&area != "" && description != "")
            {
                MoveQuery mq = new MoveQuery();
                string area1 = sq.queryByStudentnumber(studentnumber).FirstOrDefault().area;
                int build1 = sq.queryByStudentnumber(studentnumber).FirstOrDefault().build;
                int room1 = sq.queryByStudentnumber(studentnumber).FirstOrDefault().room;
                if(area == area1 && build == build1 && room == room1)
                {
                    MessageBox.Show("你现在已经在"+area+build+"号楼"+room+"宿舍了，不可以原地转宿哦！");
                }
                else
                {
                    if (mq.queryByKey(studentnumber).Count() > 0)
                    {
                        MessageBox.Show("已提交过申请，不可以重复提交，请等待审核");
                    }
                    else
                    {
                        MoveAdd ma = new MoveAdd();
                        if (ma.addMove(studentnumber, studentname, area, build, room, description))
                        {

                            MessageBox.Show("已提交申请");
                        }
                        else
                        {
                            MessageBox.Show("提交申请失败");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("请检查输入");
            }
        }
    }
}
