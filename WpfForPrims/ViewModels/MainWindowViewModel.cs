using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
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
        /// <summary>
        /// 导航记录
        /// </summary>
        private IRegionNavigationJournal Journal;

        /// <summary>
        /// 
        /// </summary>
        public DelegateCommand<string> ShowContentCmm { get; set; }

        /// <summary>
        /// 后退
        /// </summary>
        public DelegateCommand<string> BackCmm { get; set; }

        /// <summary>
        /// 对话框命令
        /// </summary>
        public DelegateCommand<string> DialogCmm { get; set; }


        /// <summary>
        /// 区域管理器
        /// </summary>
        private readonly IRegionManager _regionManager;

        /// <summary>
        /// 对话框服务
        /// </summary>
        private readonly IDialogService _dialogService;


        public MainWindowViewModel(IRegionManager regionManager, IDialogService dialogService)
        {
            _regionManager = regionManager;
            ShowContentCmm = new DelegateCommand<string>(ShowContentFunc);
            BackCmm = new DelegateCommand<string>(BackFunc);

            _dialogService = dialogService;//对话框服务
            DialogCmm = new DelegateCommand<string>(ShowDialogFunc);

        }

        /// <summary>
        /// 回退方法
        /// </summary>
        /// <param name="obj"></param>
        private void BackFunc(string obj)
        {
            if (Journal != null && Journal.CanGoBack)
            {
                Journal.GoBack();
            }
        }

        /// <summary>
        /// prism的实现 的实现
        /// </summary>
        /// <param name="viewName"></param>
        private void ShowContentFunc(string viewName)
        {
            // 字符串 "UCA" / "UCB" / "UCC" 必须和 App.RegisterForNavigation 注册的类型一一对应

            #region 打开
            NavigationParameters parameters = new NavigationParameters();
            parameters.Add("MsgA", "Hello World,I am A");

            //callback  导航完成后的回调 存下记录
            _regionManager.Regions["ContentRegion"].RequestNavigate(viewName, callback =>
            {
                Journal = callback.Context.NavigationService.Journal;
            }, parameters);
            #endregion
        }

        /// <summary>
        /// 对话框服务
        /// </summary>
        /// <param name="viewName">用户控件的名字</param>
        private void ShowDialogFunc(string viewName)
        {
            DialogParameters keyValuePairs = new DialogParameters();
            keyValuePairs.Add("Title", "这是对话框的标识AAAAAAAAAA");
            keyValuePairs.Add("para1", "参数1");
            keyValuePairs.Add("para2", "参数2");
            _dialogService.ShowDialog(viewName, keyValuePairs, callback =>
            {
                if (callback.Result == ButtonResult.OK)
                {
                    //接受对话框返回的参数
                    var r1 = callback.Parameters.GetValue<string>("para1");
                    var r2 = callback.Parameters.GetValue<string>("para2");
                }
                else if (callback.Result == ButtonResult.No)
                {
                    var r1 = callback.Parameters.GetValue<string>("para1");
                    var r2 = callback.Parameters.GetValue<string>("para2");
                }
            });
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
        //        RaisePropertyChanged();// 值改变时通知界面更新
        //    }
        //}
        #endregion

    }
}
