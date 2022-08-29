using SoftMart.Core.Dao;
using System;

namespace SM.Training.SharedComponent.Entities
{
    public partial class Role : BaseEntity
    {
        #region Primitive members

        public const string C_RoleID = "RoleID";
        private int? _RoleID;
        [PropertyEntity(C_RoleID, true)]
        public int? RoleID
        {
            get { return _RoleID; }
            set { _RoleID = value; NotifyPropertyChanged(C_RoleID); }
        }

        public const string C_Name = "Name";
        private string _Name;
        [PropertyEntity(C_Name, false)]
        public string Name
        {
            get { return _Name; }
            set { _Name = value; NotifyPropertyChanged(C_Name); }
        }

        public const string C_Code = "Code";
        private string _Code;
        [PropertyEntity(C_Code, false)]
        public string Code
        {
            get { return _Code; }
            set { _Code = value; NotifyPropertyChanged(C_Code); }
        }

        // Update 21/5: Thêm cột IsPublic, IsSystem, thay Status => IsActive

        public const string C_IsPublic = "IsPublic"; // 
        private bool? _IsPublic;
        [PropertyEntity(C_IsPublic, false)]
        public bool? IsPublic
        {
            get { return _IsPublic; }
            set { _IsPublic = value; NotifyPropertyChanged(C_IsPublic); }
        }

        public const string C_IsSystem = "IsSystem"; // 
        private bool? _IsSystem;
        [PropertyEntity(C_IsSystem, false)]
        public bool? IsSystem
        {
            get { return _IsSystem; }
            set { _IsSystem = value; NotifyPropertyChanged(C_IsSystem); }
        }

        public const string C_IsActive = "IsActive"; // 
        private bool? _IsActive;
        [PropertyEntity(C_IsActive, false)]
        public bool? IsActive
        {
            get { return _IsActive; }
            set { _IsActive = value; NotifyPropertyChanged(C_IsActive); }
        }


        //public const string C_Status = "Status";
        //private int? _Status;
        //[PropertyEntity(C_Status, false)]
        //public int? Status
        //{
        //    get { return _Status; }
        //    set { _Status = value; NotifyPropertyChanged(C_Status); }
        //}

        public const string C_Deleted = "Deleted";
        private int? _Deleted;
        [PropertyEntity(C_Deleted, false)]
        public int? Deleted
        {
            get { return _Deleted; }
            set { _Deleted = value; NotifyPropertyChanged(C_Deleted); }
        }

        public const string C_Version = "Version";
        private int? _Version;
        [PropertyEntity(C_Version, false)]
        public int? Version
        {
            get { return _Version; }
            set { _Version = value; NotifyPropertyChanged(C_Version); }
        }

        public const string C_CreatedBy = "CreatedBy";
        private string _CreatedBy;
        [PropertyEntity(C_CreatedBy, false)]
        public string CreatedBy
        {
            get { return _CreatedBy; }
            set { _CreatedBy = value; NotifyPropertyChanged(C_CreatedBy); }
        }

        public const string C_CreatedDTG = "CreatedDTG";
        private DateTime? _CreatedDTG;
        [PropertyEntity(C_CreatedDTG, false)]
        public DateTime? CreatedDTG
        {
            get { return _CreatedDTG; }
            set { _CreatedDTG = value; NotifyPropertyChanged(C_CreatedDTG); }
        }

        public const string C_UpdatedBy = "UpdatedBy";
        private string _UpdatedBy;
        [PropertyEntity(C_UpdatedBy, false)]
        public string UpdatedBy
        {
            get { return _UpdatedBy; }
            set { _UpdatedBy = value; NotifyPropertyChanged(C_UpdatedBy); }
        }

        public const string C_UpdatedDTG = "UpdatedDTG";
        private DateTime? _UpdatedDTG;
        [PropertyEntity(C_UpdatedDTG, false)]
        public DateTime? UpdatedDTG
        {
            get { return _UpdatedDTG; }
            set { _UpdatedDTG = value; NotifyPropertyChanged(C_UpdatedDTG); }
        }

        public const string C_Description = "Description";
        private string _Description;
        [PropertyEntity(C_Description, false)]
        public string Description
        {
            get { return _Description; }
            set { _Description = value; NotifyPropertyChanged(C_Description); }
        }

        public Role() : base("adm_Role", "RoleID", "Deleted", "Version") { }

        #endregion

        public Role ConvertToInsert()
        {
            return new Role()
            {
                Name = this.Name,
                Code = this.Code,
                IsActive = this.IsActive,
                Description = this.Description,
            };
        }

        /// <summary>
        /// Convert từ Model sang Entity
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public Role ConvertToUpdate()
        {
            // Update 21/5: Thêm cột IsPublic, IsSystem, thay Status => IsActive
            return new Role()
            {
                RoleID = this.RoleID,
                Name = this.Name,
                Code = this.Code,
                IsActive = this.IsActive,
                Version = this.Version,
                Description = this.Description,
            };
        }
    }
}
