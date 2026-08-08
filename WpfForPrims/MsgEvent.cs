using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Events;

namespace WpfForPrims
{
    /// <summary>
    /// 发布订阅消息事件
    /// </summary>
    public class MsgEvent : PubSubEvent<string>
    {
    }
}
