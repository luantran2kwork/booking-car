using Microsoft.AspNetCore.Mvc;
using SoftMart.Core.Utilities.Profiles;
using SoftMart.Kernel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SM.Training.Api.Controllers
{
    [ApiController]
    [ResponseCache(NoStore = false, Duration = 0)]
    public abstract class BaseController : ControllerBase
    {
        #region Vùng xử lý tạo link download và get link download
        protected static Dictionary<string, BaseDTO> dctDownloadLink = new Dictionary<string, BaseDTO>();
        protected string BuildDownloadLink(BaseDTO request)
        {
            // Tạo key là EmployeeID-Guide.
            // Khi đăng nhập hoặc logout sẽ xóa toàn bộ key theo ID của employee để đảm bảo không có rác
            string key = Guid.NewGuid().ToString().Replace("-", string.Empty);
            key = string.Format("{0}-{1}", Profiles.MyProfile.EmployeeID, key).ToLower();

            dctDownloadLink.Add(key, request);

            return key;
        }

        protected BaseDTO GetDownloadRequest(string key)
        {
            key = key.ToLower();
            if (!string.IsNullOrEmpty(key)
                && dctDownloadLink.ContainsKey(key))
            {
                return dctDownloadLink[key];
            }

            dctDownloadLink.Remove(key);

            //TODO: Cần tạo lại profile từ key vì có chức năng download sẽ sử dụng profile
            return null;
        }

        #endregion

        private string _functionCode;
        protected string ActionCode
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_functionCode))
                {
                    Microsoft.Extensions.Primitives.StringValues lstValue;

                    if (Request.Headers.TryGetValue("Flex_ActionCode", out lstValue))
                    {
                        _functionCode = lstValue.FirstOrDefault();
                    }
                }

                if (string.IsNullOrWhiteSpace(_functionCode))
                {
                    throw new NotSupportedException("Flex_ActionCode is missing");
                }

                return _functionCode;
            }
        }
        public class BaseApiActionCode
        {
            // Trang danh sach
            public const string SetupViewForm = "SetupViewForm";
            public const string SearchData = "SearchData";
            public const string ExportExcel = "ExportExcel";

            // Trang addnew
            public const string SetupAddNewForm = "SetupAddNewForm";
            public const string SetupAddNewTTB1Form = "SetupAddNewTTB1Form";
            public const string GetListEquipmentType = "GetListEquipmentType";
            public const string AddNewItem = "AddNewItem";

            // Trang edit
            public const string SetupEditForm = "SetupEditForm";
            public const string UpdateItem = "UpdateItem";

            // Trang display
            public const string SetupDisplay = "SetupDisplay";
            public const string DeleteItem = "DeleteItem";
            public const string ChangeStatus = "ChangeStatus";

            // Bo phe duyet
            public const string SetupBeforeSubmit = "SetupBeforeSubmit";
            public const string RequestForAppoval = "RequestForAppoval";

            public const string SetupBeforeApprove = "SetupBeforeApprove";
            public const string Approve = "Approve";

            public const string Reject = "Reject";
            public const string Cancel = "Cancel";

            public const string SetupDisplay_Mobile = "SetupDisplay_Mobile";
        }

        public class BaseDTO
        {
            public PagingInfo PagingInfo { get; set; }
            /// <summary>
            /// Danh sách chức năng để phân quyền trên UI
            /// </summary>
            public List<string> FunctionCodes { get; set; }
            public string DeviceIDs { get; set; }
        }
    }
}
