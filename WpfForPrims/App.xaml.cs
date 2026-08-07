//using ModuleA;
//using ModuleB;
using ModuleA;
using ModuleB;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;
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
            //containerRegistry.RegisterForNavigation<UCA>();
            //containerRegistry.RegisterForNavigation<UCB>();
            //containerRegistry.RegisterForNavigation<UCC>();
        }
        //引用项目的方式
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<ModuleAProfile>();
            moduleCatalog.AddModule<ModuleBProfile>();
        }

        // 添加dll 方式
        //protected override IModuleCatalog CreateModuleCatalog()
        //{
        //    return new DirectoryModuleCatalog() { ModulePath = ".\\Modules" };
        //}



    }
}
