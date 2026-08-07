using Prism.Mvvm;
using Prism.Regions;
using System.Windows;

namespace ModuleA.ViewModels
{
    public class ViewAViewModel : BindableBase, IConfirmNavigationRequest//, INavigationAware
    {
        private string _msg;

        public string Msg
        {
            get { return _msg; }
            set
            {
                _msg = value;

                RaisePropertyChanged();// 值改变时通知界面更新

            }
        }

        /// <summary>
        /// 接受参数
        /// </summary>
        /// <param name="navigationContext"></param>
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            if (navigationContext.Parameters["MsgA"] != null)
            {
                Msg = navigationContext.Parameters["MsgA"].ToString();
            }
        }

        /// <summary>
        ///  是否重用实例
        /// </summary>
        /// <param name="navigationContext"></param>
        /// <returns></returns>
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        /// <summary>
        /// 确认导航请求
        /// </summary>
        /// <param name="navigationContext"></param>
        /// <param name="continuationCallback"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
            bool result = true;
            if (MessageBox.Show("是切换前页面？", "温馨提示", MessageBoxButton.YesNo) == MessageBoxResult.No)
            {
                result = false;
            }
            continuationCallback(result);
        }
    }
}
