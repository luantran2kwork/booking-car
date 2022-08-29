using SM.Training.Administration.Dao;
using SM.Training.SharedComponent.Entities;
using SM.Training.SharedComponent.Constants;
using SM.Training.SharedComponent.Filter;
using SoftMart.Kernel.Entity;
using SoftMart.Kernel.Exceptions;
using System;
using System.Linq;
using System.Collections.Generic;

namespace SM.Training.Administration.Biz
{
    public class RoleBiz// : BizBase
    {
        RoleDao _dao = new RoleDao();

        #region AddNew

        public (List<KeyValuePair<bool, string>> ListActiveStatus, object obj) SetupAddNewForm()
        {
            var lstValue = SMX.YesNoStatus.dctName.ToList();

            return (lstValue, null);
        }

        public Role AddNewItem(Role item)
        {
            //01.Validate data
            ValidateItem(item);

            item.Deleted = SMX.smx_IsNotDeleted;
            item.Version = SMX.smx_FirstVersion;
            item.CreatedBy = "Training"; // App thật sẽ lấy ở profile ra
            item.CreatedDTG = DateTime.Now;

            _dao.InsertRole(item);
            return item;
        }

        private void ValidateItem(Role item)
        {
            List<string> lstMsg = new List<string>();

            if (string.IsNullOrWhiteSpace(item.Name))
                lstMsg.Add("[Tên vai trò] không được để trống.");

            if (!string.IsNullOrWhiteSpace(item.Code))
            {
                int? oldID = _dao.GetIDByCode(item.Code);
                if (oldID != null && item.RoleID != oldID)
                {
                    lstMsg.Add("[Mã vai trò] đã có trong hệ thống.");
                }
            }
            // Update 21/5: IsSystem = 1 thì không cho sửa, xóa
            if (item.IsSystem != null && item.IsSystem.Value)
            {

                lstMsg.Add("[Mã vai trò] là vai trò của hệ thống.");
            }
            if (lstMsg.Count > 0)
                throw new SMXException(lstMsg);
        }

        #endregion

        #region Edit

        public (Role Role, List<KeyValuePair<bool, string>> ListActiveStatus) SetupEditForm(int roleId)
        {
            Role role = _dao.GetRoleByID(roleId);
            if (role == null)
                throw new KeyNotFoundException();

            var lstValue = SMX.YesNoStatus.dctName.ToList();

            return (role, null);
        }

        public void UpdateItem(Role item)
        {
            //01. Validate Item
            ValidateItem(item);

            //2. Prepare data
            item.UpdatedBy = "Training";// App thật lấy ở profile
            item.UpdatedDTG = DateTime.Now;

            //3. Update
            _dao.UpdateRole(item);
        }

        public void DeleteItem(Role role)
        {
            role.Deleted = SMX.smx_IsDeleted;
            role.UpdatedBy = "Training";// App thật lấy ở profile
            role.UpdatedDTG = DateTime.Now;

            //01. Validate Item
            List<string> lstMsg = new List<string>();
            if (role.IsSystem != null && role.IsSystem.Value)
            {
                lstMsg.Add("[Role Code] is system role.");
            }
            if (lstMsg.Count > 0)
                throw new SMXException(lstMsg);

            _dao.UpdateRole(role);
        }

        #endregion

        #region Display

        public (Role Role, object obj) SetupDisplay(int roleID)
        {
            Role role = _dao.GetRoleByID(roleID);
            if (role == null)
                throw new KeyNotFoundException();
            return (role, null);
        }

        #endregion

        #region View

        public (List<KeyValuePair<bool, string>> ListActiveStatus, object obj) SetupViewForm()
        {
            var lstValue = SMX.YesNoStatus.dctName.ToList();

            return (lstValue, null);
        }

        public (List<Role> ListRole, object obj) SearchItemsForView(RoleFilter filter)
        {
            PagingInfo pagingInfo = new PagingInfo();
            //pagingInfo.PageSize = 20;
            pagingInfo.PageIndex = filter.PageIndex;
            var lstRole = _dao.SearchRole(filter, pagingInfo);
            return (lstRole, null);
        }

        #endregion

        public List<Role> SearchRoleByRoleName(string roleName)
        {
            return _dao.SearchRoleByRoleName(roleName);
        }
    }
}
