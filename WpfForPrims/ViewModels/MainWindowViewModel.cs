using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using WpfForPrims.Views;

namespace WpfForPrims.ViewModels
{
    /// <summary>
    ///  ViewModel 必须在 ViewModels 文件夹
    ///  
    /// 页面View 必须在 Views 文件夹
    /// 
    /// 名称必须保持一致
    /// 
    /// 
    /// 
    /// 
    /// </summary>


    public class MainWindowViewModel : BindableBase
    {
        public DelegateCommand<string> ShowContentCmm { get; set; }

        /// <summary>
        /// 区域管理器
        /// </summary>
        private readonly IRegionManager _regionManager;

        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            ShowContentCmm = new DelegateCommand<string>(ShowContentFunc);
        }

        /// <summary>
        /// prism的实现 的实现
        /// </summary>
        /// <param name="viewName"></param>
        private void ShowContentFunc(string viewName)
        {
            // 字符串 "UCA" / "UCB" / "UCC" 必须和 App.RegisterForNavigation 注册的类型一一对应
            _regionManager.RequestNavigate("ContentRegion", viewName);
        }


        #region 没使用 prism的实现
        //private void ShowContentFunc(string viewName)
        //{
        //    if (viewName == "UCA")
        //    {
        //        ShowContent = new UCA();
        //    }
        //    if (viewName == "UCB")
        //    {
        //        ShowContent = new UCB();
        //    }
        //    if (viewName == "UCC")
        //    {
        //        ShowContent = new UCC();
        //    }
        //}


        ///// <summary>
        ///// 显示内容
        ///// </summary>
        //private UserControl _showContent;

        //public UserControl ShowContent
        //{
        //    get { return _showContent; }
        //    set
        //    {
        //        _showContent = value;
        //        RaisePropertyChanged();
        //    }
        //}
        #endregion




    }
}
