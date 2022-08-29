using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using SM.Training.Utils;
using SoftMart.Core.Dao;
using SoftMart.Kernel.Entity;
using System.Linq;
using SoftMart.Kernel.Exceptions;
using SM.Training.SharedComponent.Constants;

namespace SM.Training.Dao.Common
{
    public abstract class BaseDao
    {
        protected string TrimFilter(string keyword)
        {
            if (keyword == null)
            {
                return string.Empty;
            }
            else
            {
                return keyword.Trim();
            }
        }

        protected string BuildLikeFilter(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return null;
            return string.Format("%{0}%", keyword.Trim());
        }

        protected string BuildInCondition(List<int> lstValue)
        {
            if (lstValue.Count == 0)
            {
                return "null";
            }
            else
            {
                return string.Join(", ", lstValue.ToArray());
            }
        }

        protected string BuildInCondition(List<string> lstValue)
        {
            if (lstValue.Count == 0)
            {
                return "null";
            }
            else
            {
                string result = string.Empty;
                string separator = string.Empty;

                foreach (string item in lstValue)
                {
                    if (!string.IsNullOrWhiteSpace(item))
                    {
                        result += separator + "'" + item.Trim().Replace("'", "''") + "'";
                        separator = ",";
                    }
                }
                return result;
            }
        }

        protected string BuildInConditionText(List<string> lstValue, bool isNvarchar = true)
        {
            if (lstValue.Count == 0)
            {
                return "null";
            }
            else
            {
                string result = string.Empty;
                string separator = string.Empty;

                foreach (string item in lstValue)
                {
                    if (isNvarchar)
                    {
                        result += separator + "N'" + item.Trim().Replace("'", "''") + "'";
                    }
                    else
                    {
                        result += separator + "'" + item.Trim().Replace("'", "''") + "'";
                    }
                    separator = ",";
                }
                return result;
            }
        }

        /// <summary>
        /// Execute paging with RowNumber Mode
        /// </summary>
        protected List<T> ExecutePaging<T>(SqlCommand command, string orderStatement, PagingInfo pagingInfo, bool countingRecordCount = false)
        {
            using (var dataContext = new DataContext())
            {
                return ExecutePaging<T>(dataContext, command, orderStatement, pagingInfo, countingRecordCount);
            }

            //int recordCord;
            //List<T> lst;

            //using (var dataContext = new DataContext())
            //{
            //    if (ConfigUtils.PagingMode == SoftMart.Core.Dao.SqlPagingMode.RowNumber)
            //    {
            //        lst = dataContext.ExecutePaging<T>(command, pagingInfo.PageIndex, pagingInfo.PageSize, orderStatement, out recordCord, countingRecordCount);
            //    }
            //    else
            //    {
            //        lst = dataContext.ExecuteOffset<T>(command, pagingInfo.PageIndex, pagingInfo.PageSize, orderStatement, out recordCord, countingRecordCount);
            //    }
            //}
            //if (countingRecordCount == true)
            //{
            //    pagingInfo.RecordCount = recordCord;
            //}
            //else
            //{
            //    pagingInfo = null;
            //}
            //return lst;
        }

        protected List<T> ExecutePaging<T>(string query, string orderStatement, PagingInfo pagingInfo, bool countingRecordCount = false)
        {
            SqlCommand sqlCmd = new SqlCommand(query);

            return ExecutePaging<T>(sqlCmd, orderStatement, pagingInfo, countingRecordCount);
        }

        protected List<T> ExecutePaging<T>(DataContext dataContext, SqlCommand command, string orderStatement, PagingInfo pagingInfo, bool countingRecordCount = false)
        {
            int recordCord;
            List<T> lst;

            if (ConfigUtils.PagingMode == SoftMart.Core.Dao.SqlPagingMode.RowNumber)
            {
                lst = dataContext.ExecutePaging<T>(command, pagingInfo.PageIndex, pagingInfo.PageSize, orderStatement, out recordCord, countingRecordCount);
            }
            else
            {
                lst = dataContext.ExecuteOffset<T>(command, pagingInfo.PageIndex, pagingInfo.PageSize, orderStatement, out recordCord, countingRecordCount);
            }

            if (countingRecordCount == true)
            {
                pagingInfo.RecordCount = recordCord;
            }
            else
            {
                pagingInfo = null;
            }
            return lst;

            //List<T> lst = dataContext.ExecutePaging<T>(command, pagingInfo.PageIndex, pagingInfo.PageSize, orderStatement, out recordCord, countingRecordCount);
            //pagingInfo.RecordCount = recordCord;
            //return lst;
        }

        protected List<T> ExecutePaging<T>(DataContext dataContext, string query, string orderStatement, PagingInfo pagingInfo, bool countingRecordCount = false)
        {
            SqlCommand sqlCmd = new SqlCommand(query);

            return ExecutePaging<T>(dataContext, sqlCmd, orderStatement, pagingInfo, countingRecordCount);
        }

        protected System.Data.DataTable ExecuteDataTablePaging(DataContext dataContext, SqlCommand sqlCmd, string orderStatement, PagingInfo pagingInfo, bool countingRecordCount = false)
        {
            int recordCord;
            System.Data.DataTable data = dataContext.ExecuteDataTable(sqlCmd, pagingInfo.PageIndex, pagingInfo.PageSize, orderStatement, out recordCord, countingRecordCount);
            pagingInfo.RecordCount = recordCord;

            return data;
        }

        public void InsertItem<T>(T item) where T : BaseEntity
        {
            using (DataContext context = new DataContext())
            {
                context.InsertItem<T>(item);
            }
        }

        public void InsertItems<T>(List<T> lstItem, int batchSize = 0) where T : BaseEntity
        {
            using (DataContext context = new DataContext())
            {
                context.InsertItems<T>(lstItem, batchSize);
            }
        }

        /// <summary>
        /// DEV hạn chế dùng hàm Update trong Base,
        /// do chưa check trường hợp update không thành công. 
        /// Khi sử dụng cần cẩn thận lưu ý.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        public int UpdateItem<T>(T item, bool checkVersion = false) where T : BaseEntity
        {
            int affectedRow = 0;
            using (DataContext context = new DataContext())
            {
                affectedRow = context.UpdateItem<T>(item);
            }

            if (checkVersion == true && affectedRow == 0)
            {
                throw new SMXException("Bản ghi đã bị thay đổi, vui lòng tải lại dữ liệu");
            }
            return affectedRow;
        }

        public T GetItemByID<T>(object id) where T : class
        {
            using (DataContext context = new DataContext())
            {
                return context.SelectItemByID<T>(id);
            }
        }

        public List<T> GetItemByField<T>(string fieldName, object id) where T : class
        {
            using (DataContext context = new DataContext())
            {
                return context.SelectItemByColumnName<T>(fieldName, id);
            }
        }

        public T GetItemFieldsByID<T>(string[] fieldNames, object id) where T : class
        {
            using (DataContext context = new DataContext())
            {
                return context.SelectFieldsByID<T>(fieldNames, id);
            }
        }

        public string GetGeneralSetting(string key)
        {
            string sql = @"select SettingValue from adm_GeneralSetting where SettingKey = @Key";
            SqlCommand command = new SqlCommand(sql);
            command.Parameters.AddWithValue("@Key", key);

            List<string> lst;
            using (DataContext context = new DataContext())
            {
                lst = context.ExecuteSelect<string>(command);
            }
            if (lst.Count == 0)
                throw new SMXException(string.Format("Cấu hình hệ thống [{0}] chưa có giá trị. Vui lòng liên hệ QTHT.", key));
            return lst.First();
        }
    }
}