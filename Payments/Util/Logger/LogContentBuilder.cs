using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payments.Util.Logger
{
    public class LogContentBuilder
    {
        private LogContent _logContent;

        private LogContentBuilder()
        {
            _logContent = new LogContent();
        }

        /// <summary>
        /// 创建对象
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public static LogContentBuilder CreateLogContentBuilder(Action<LogContent> action = null)
        {
            var logContentBuilder = new LogContentBuilder();
            action?.Invoke(logContentBuilder._logContent);
            return new LogContentBuilder();
        }

        public LogContent Build()
        {
            return _logContent;
        }

        /// <summary>
        /// 设置Id
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        public LogContentBuilder SetEventId(Guid eventId)
        {
            _logContent.EventId = eventId;
            return this;
        }

        /// <summary>
        /// 设置模块名称
        /// </summary>
        /// <param name="moudle"></param>
        /// <returns></returns>
        public LogContentBuilder SetMoudle(string moudle)
        {
            _logContent.Module = moudle;
            return this;
        }

        /// <summary>
        /// 设置标题
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public LogContentBuilder SetTitle(string title)
        {
            _logContent.Title = title;
            return this;
        }

        /// <summary>
        /// 添加内容
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public LogContentBuilder AddContent(string content)
        {
            _logContent.Contents.Add(content);
            return this;
        }
        /// <summary>
        /// 添加内容
        /// </summary>
        /// <param name="contents"></param>
        /// <returns></returns>
        public LogContentBuilder AddContent(IDictionary<string,string> contents)
        {
            foreach (var item in contents)
            {
                _logContent.Contents.Add($"{item.Key}:{item.Value}");
            }       
            return this;
        }
    }
}
