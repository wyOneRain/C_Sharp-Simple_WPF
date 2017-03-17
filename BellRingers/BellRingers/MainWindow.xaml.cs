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

namespace BellRingers
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private string[] towers = { "Great Shevington", "Little Mudford", "Upper Gumtree", "Downley Hatch" };
        private string[] ringingMethods = {"Plain Bob", "Reverse Canterbury","Grandsire", "Stedman", "Kent Treble Bob",
            "Old Oxford Delight","Winchendon Place", "Norwich Suprise", "Crayford Little Court" };


        public MainWindow()
        {
            InitializeComponent();
            this.Reset();
     
        }

        public void Reset()//初始化界面
        {
            firstName.Text = String.Empty;//清空指定文本框内容
            lastName.Text = String.Empty;

            towerNames.Items.Clear();//初始化towerNames
            foreach (string towerName in towers)//遍历
            {
                towerNames.Items.Add(towerName);//为ComboBox添加成员
            }

            methods.Items.Clear();//初始化methods
            CheckBox method = null;
            foreach(string methodName in ringingMethods)
            {
                method = new CheckBox();
                method.Margin = new Thickness(0, 0, 0, 10);//设定位置
                method.Content = methodName;
                methods.Items.Add(method);
            }

            isCaptain.IsChecked = false;//初始化IsCaptain

            memberSince.Text = DateTime.Today.ToString();//显示当前时间(初始化)
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            this.Reset();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            string nameAndTower = String.Format("Member name :{0} {1} from the tower at {2} rings the following methods:", firstName.Text, lastName.Text, towerNames.Text);

            StringBuilder details = new StringBuilder();
            details.AppendLine(nameAndTower);

            foreach(CheckBox cb in methods.Items)
            {
                if (cb.IsChecked.Value)
                    details.AppendLine(cb.Content.ToString());
            }

            MessageBox.Show(details.ToString(), "Member Information");
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)//确认用户是否想退出程序
        {
            MessageBoxResult key = MessageBox.Show("Are you sure you want to quit", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question,MessageBoxResult.);
            e.Cancel = (key == MessageBoxResult.No);
        }
    }
}
