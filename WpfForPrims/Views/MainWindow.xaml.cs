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
using System.Windows.Shapes;
using Prism.Events;

namespace WpfForPrims.Views
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// 事件聚合器，用于发布和订阅事件
        /// </summary>
        private readonly IEventAggregator _eventAggregator;


        public MainWindow(EventAggregator eventAggregator)
        {
            InitializeComponent();


            _eventAggregator = eventAggregator;

        }

        /// <summary>
        /// 发布
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _eventAggregator.GetEvent<MsgEvent>().Publish("Hello, World!");
        }

        /// <summary>
        /// 订阅消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _eventAggregator.GetEvent<MsgEvent>().Subscribe(Sub);
        }

        /// <summary>
        /// 处理订阅的消息
        /// </summary>
        /// <param name="obj"></param>
        private void Sub(string obj)
        {
            MessageBox.Show($"收到订阅的消息：{obj}");
        }

        /// <summary>
        /// 取消订阅消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            _eventAggregator.GetEvent<MsgEvent>().Unsubscribe(Sub);
        }
    }
}
