using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Services.Dialogs;

namespace ModuleA.ViewModels
{
    public class ViewCViewModel : IDialogAware
    {
        public string Title { get; set; }

        /// <summary>
        /// 关闭的额委托
        /// </summary>
        public event Action<IDialogResult> RequestClose;

        /// <summary>
        /// 取消命令
        /// </summary>
        public DelegateCommand CancelCMM { get; set; }

        /// <summary>
        /// 确定命令
        /// </summary>
        public DelegateCommand ConfirmCMM { get; set; }


        public ViewCViewModel()
        {
            //CancelCMM = new DelegateCommand(() =>
            //{
            //    if (RequestClose != null)
            //    {
            //        RequestClose(new DialogResult(ButtonResult.No));
            //    }
            //});
            //ConfirmCMM = new DelegateCommand(() =>
            //{
            //    if (RequestClose != null)
            //    {
            //        RequestClose(new DialogResult(ButtonResult.OK));
            //    }
            //});
            CancelCMM = new DelegateCommand(OnDialogClosed);

            ConfirmCMM = new DelegateCommand(Confirm);
        }

        private void Confirm()
        {
            if (RequestClose != null)
            {
                DialogParameters pairs = new DialogParameters();
                pairs.Add("para1", "我是对话框返回结果的参数1");
                pairs.Add("para2", "我是对话框返回结果的参数2");


                RequestClose(new DialogResult(ButtonResult.OK, pairs));
            }
        }


        /// <summary>
        /// 是否可以关闭对话框
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool CanCloseDialog()
        {
            return true;
        }

        /// <summary>
        /// 关闭对话框时触发
        /// </summary>
        public void OnDialogClosed()
        {
            if (RequestClose != null)
            {
                //返回对话框结果
                DialogParameters pairs = new DialogParameters();
                pairs.Add("para1", "我是对话框返回的参数1");
                pairs.Add("para2", "我是对话框返回的参数2");

                RequestClose(new DialogResult(ButtonResult.No, pairs));
            }

        }

        /// <summary>
        /// 打开对话框时传递参数
        /// </summary>
        /// <param name="parameters"></param>
        public void OnDialogOpened(IDialogParameters parameters)
        {
            Title = parameters.GetValue<string>("Title");

            var p1 = parameters.GetValue<string>("para1");
            var p2 = parameters.GetValue<string>("para2");

        }
    }
}
