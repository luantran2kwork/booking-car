using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SM.Training.Utils;
using System;
using System.Net;
using System.Security.Authentication;
using System.Threading.Tasks;

namespace SM.Training.Api.Common
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context /* other dependencies */)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            string errorCode = string.Empty;
            HttpStatusCode code = GetStatusCode(ex, out errorCode);

            string msg = string.IsNullOrWhiteSpace(errorCode) ? ex.Message : errorCode + " - " + ex.Message; // Nếu có trả ra mã lỗi thì fill thêm mã lỗi vào message để hiển thị ở client.
            if (msg.Length > 512)
            {
                msg = msg.Substring(0, 512); // Chỉ cắt 512 ký tự, vì dài quá sẽ gây lỗi Url trên trình duyệt

                int lastSpace = msg.LastIndexOf(' ');
                msg = msg.Substring(0, lastSpace) + "..."; // Lấy đến ký tự space cuối cùng và thêm ... để biết còn nữa
            }

            var content = new
            {
                StatusCode = code,
                Message = msg
            };

            var result = JsonConvert.SerializeObject(content);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }

        private HttpStatusCode GetStatusCode(Exception ex, out string errorCode)
        {
            errorCode = string.Empty;

            // Lỗi nghiệp vụ, sẽ show message lỗi tại trang đang hiển thị
            if (ex is SoftMart.Kernel.Exceptions.SMXException)
            {
                return HttpStatusCode.BadRequest; // Trả về mã lỗi thất bại - 400
            }

            // Chưa đăng nhập, nhảy về trang login
            if (ex is AuthenticationException)
            {
                return HttpStatusCode.Unauthorized; // Mã lỗi chưa đăng nhập - 401
            }

            DateTime now = DateTime.Now;
            errorCode = int.Parse(now.ToString("yyyyMMdd")).ToString("X") + "." + int.Parse(now.ToString("HHmmssfff")).ToString("X");

            // Tất cả lỗi khác, nhảy về trang báo lỗi
            LogManager.Web.LogError(errorCode, ex); // Log lại các lỗi không kiểm soát được

            return HttpStatusCode.NotAcceptable; // Trả về mã lỗi thất bại - 406
        }
    }
}