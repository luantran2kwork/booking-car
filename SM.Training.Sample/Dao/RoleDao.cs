using Microsoft.Data.SqlClient;
using SM.Training.Dao.Common;
using SM.Training.SharedComponent.Entities;
using SM.Training.SharedComponent.Constants;
using SM.Training.SharedComponent.Filter;
using SoftMart.Kernel.Entity;
using SoftMart.Kernel.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace SM.Training.Administration.Dao
{
    public class RoleDao : BaseDao
    {
        #region Modification Methods

        public void InsertRole(Role item)
        {
            using (DataContext dataContext = new DataContext())
            {
                dataContext.InsertItem<Role>(item);
            }
        }

        public void UpdateRole(Role item)
        {
            int affectedRows;
            using (DataContext dataContext = new DataContext())
            {
                affectedRows = dataContext.UpdateItem<Role>(item);
            }
            if (affectedRows == 0)
            {
                throw new SMXException(string.Format(Messages.ItemChanged, "Role"));
            }
        }

        #endregion

        #region Getting methods

        public Role GetRoleByID(int? id)
        {
            using (DataContext dataContext = new DataContext())
            {
                return dataContext.SelectItemByID<Role>(id);
            }
        }

        #endregion

        public int? GetIDByCode(string code)
        {
            using (var dataContext = new DataContext())
            {
                Role enRole = dataContext.SelectFieldsByColumnName<Role>(new string[] { Role.C_RoleID }, Role.C_Code, code).FirstOrDefault();
                if (enRole != null)
                {
                    return enRole.RoleID;
                }
                else
                {
                    return null;
                }
            }
        }

        #region Get

        public List<Role> SearchRoleByRoleName(string name)
        {
            string cmdText = "Select * from adm_Role where (@Name is null Or Name like @Name) and Deleted = 0 order by Name";
            SqlCommand sqlCmd = new SqlCommand(cmdText);
            sqlCmd.Parameters.AddWithValue("@Name", base.BuildLikeFilter(name));

            using (var dataContext = new DataContext())
            {
                return dataContext.ExecuteSelect<Role>(sqlCmd);
            }
        }

        public List<Role> SearchRole(RoleFilter roleFilter, PagingInfo pInfo)
        {
            // Update 22/5: Bỏ cột Status, Thêm cột IsActive
            var cmdText = @"
select 
    RoleID,
    Name,
    Description,
    IsActive,
    Code
from adm_Role
where Deleted = 0 
and (@Name is null or Name like @Name)
and (@IsActive is null or IsActive = @IsActive)
";

            RoleFilter filter = roleFilter;
            var cmd = new SqlCommand(cmdText);
            cmd.Parameters.AddWithValue("@Name", BuildLikeFilter(filter.Name));
            //cmd.Parameters.AddWithValue("@Code", BuildLikeFilter(filter.Code));
            cmd.Parameters.AddWithValue("@IsActive", filter.IsActive);

            return base.ExecutePaging<Role>(cmd, "Name", pInfo);
        }
        #endregion
    }
}