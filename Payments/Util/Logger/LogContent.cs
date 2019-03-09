using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payments.Util.Logger
{
    /// <summary>
    /// 日志内容
    /// </summary>
    public class LogContent
    {
        public LogContent() : this(default(Guid), null, null, null)
        {
        }
        public LogContent(Guid EventId, string Module, string Title, IList<string> Contents)
        {
            this.EventId = EventId;
            this.Module = Module;
            this.Title = Title;
            this.Contents = Contents ?? new List<string>();
        }
        /// <summary>
        /// Id
        /// </summary>
        public Guid EventId { get; set; }

        /// <summary>
        /// 模块
        /// </summary>
        public string Module { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public IList<string> Contents { get; set; }
    }
}
