using System.Windows;
using Prism.DryIoc;
using Prism.Ioc;
using WpfForPrims.Views;

namespace WpfForPrims
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        /// <summary>
        /// 设置启动页
        /// </summary>
        /// <returns></returns>
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        /// <summary>
        /// 注入服务
        /// </summary>
        /// <param name="containerRegistry"></param>
        /// <exception cref="NotImplementedException"></exception>
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // 名称要和 ViewModel 里 RequestNavigate 的字符串一致
            containerRegistry.RegisterForNavigation<UCA>();
            containerRegistry.RegisterForNavigation<UCB>();
            containerRegistry.RegisterForNavigation<UCC>();
        }
    }
}
