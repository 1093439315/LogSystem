using MSH.LogSystem.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace MSH.LogSystem.Filters
{
    public class DeflateCompressionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionContext)
        {
            if (actionContext.Response == null) return;
            var content = actionContext.Response?.Content;
            var bytes = content == null ? null : content.ReadAsByteArrayAsync().Result;
            var compressContent = bytes == null ? new byte[0] : CompressionHelper.DeflateByte(bytes);
            actionContext.Response.Content = new ByteArrayContent(compressContent);
            actionContext.Response.Content.Headers.Remove("Content-Type");
            if (string.Equals(actionContext.Request.Headers.AcceptEncoding.First().Value, "deflate"))
                actionContext.Response.Content.Headers.Add("Content-encoding", "deflate");
            else
                actionContext.Response.Content.Headers.Add("Content-encoding", "gzip");
            actionContext.Response.Content.Headers.Add("Content-Type", "application/json;charset=utf-8");
            base.OnActionExecuted(actionContext);
        }
    }
}