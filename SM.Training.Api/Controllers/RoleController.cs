using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SM.Training.Administration.Biz;
using SM.Training.SharedComponent.Entities;
using SM.Training.SharedComponent.Filter;
using System;
using System.Collections.Generic;

namespace SM.Training.Api.Controllers
{
    [Route("Api/Internal/Administration/Role")]
    public class RoleController : BaseController
    {
        [HttpPost]
        [Route("")]
        public RoleDTO Post([FromBody] RoleDTO dtoRequest)
        {
            RoleBiz biz = new RoleBiz();
            var dtoResponse = new RoleDTO();

            switch (this.ActionCode)
            {
                case BaseApiActionCode.SetupViewForm:
                    {
                        var bizResult = biz.SetupViewForm();
                        dtoResponse.ListActiveStatus = bizResult.ListActiveStatus;
                        break;
                    }
                case BaseApiActionCode.SearchData:
                    {
                        var bizResult = biz.SearchItemsForView(dtoRequest.RoleFilter);
                        dtoResponse.Roles = bizResult.ListRole;
                        break;
                    }

                case ApiActionCode.SetupAddNewForm:
                    {
                        var bizResult = biz.SetupAddNewForm();
                        dtoResponse.ListActiveStatus = bizResult.ListActiveStatus;
                        break;
                    }

                case BaseApiActionCode.AddNewItem:
                    {
                        Role role = biz.AddNewItem(dtoRequest.Role.ConvertToInsert());
                        dtoResponse.Role = role;
                        break;
                    }

                case BaseApiActionCode.SetupEditForm:
                    {
                        var bizResult = biz.SetupEditForm(dtoRequest.RoleId);
                        dtoResponse.Role = bizResult.Role;
                        dtoResponse.ListActiveStatus = bizResult.ListActiveStatus;
                        break;
                    }
                case BaseApiActionCode.UpdateItem:
                    {
                        Role role = dtoRequest.Role.ConvertToUpdate();
                        biz.UpdateItem(role);
                        break;
                    }

                case BaseApiActionCode.SetupDisplay:
                    {
                        var bizResult = biz.SetupDisplay(dtoRequest.RoleId);
                        dtoResponse.Role = bizResult.Role;
                        break;
                    }
                case BaseApiActionCode.DeleteItem:
                    {
                        biz.DeleteItem(dtoRequest.Role);
                        break;
                    }

                default:
                    throw new NotImplementedException(this.ActionCode);
            }

            return dtoResponse;
        }

        #region Model
        /// <summary>
        /// Dữ liệu đầu vào/ra cho Api
        /// </summary>
        public class RoleDTO : BaseDTO
        {
            public List<KeyValuePair<bool, string>> ListActiveStatus { get; set; }

            [JsonProperty("Roles")]
            public List<Role> Roles { get; set; }

            [JsonProperty("Role")]
            public Role Role { get; set; }

            [JsonProperty("RoleName")]
            public string RoleName { get; set; }

            [JsonProperty("RoleId")]
            public int RoleId { get; set; }

            [JsonProperty("RoleFilter")]
            public RoleFilter RoleFilter { get; set; }
        }

        /// <summary>
        /// Các chức năng do api cung cấp
        /// </summary>
        public class ApiActionCode : BaseApiActionCode
        {
            public const string SearchItemsForView = "SearchItemsForView";
            public const string SearchRoleByRoleName = "SearchRoleByRoleName";
            public const string GetAllActiveRole = "GetAllActiveRole";
        }
        #endregion
    }
}
