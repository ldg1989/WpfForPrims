using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace WpfForPrims.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public DelegateCommand<string> ShowContentCmm { get; set; }

        private readonly IRegionManager _regionManager;

        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            ShowContentCmm = new DelegateCommand<string>(ShowContentFunc);
        }

        private void ShowContentFunc(string viewName)
        {
            // 字符串 "UCA" / "UCB" / "UCC" 必须和 App.RegisterForNavigation 注册的类型一一对应
            _regionManager.RequestNavigate("ContentRegion", viewName);
        }
    }
}
