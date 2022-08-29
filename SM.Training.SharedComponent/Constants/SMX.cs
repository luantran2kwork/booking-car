using System.Collections.Generic;

namespace SM.Training.SharedComponent.Constants
{
    /// <summary>
    /// Constants and Pre-defined data
    /// </summary>
    public class SMX
    {

        //public const int Status = 0;
        //public const int NotStatus = 1;
        public const int SYSTEM_EMPLOYEE_ID = -1;

        public const int smx_IsNotDeleted = 0;
        public const int smx_IsDeleted = 1;
        public const int smx_FirstVersion = 1;
        public const int smx_PageSize = 20;


        public static class YesNoStatus
        {
            public static Dictionary<bool, string> dctName = new Dictionary<bool, string>()
            {
                {true,  "Hoạt động"},
                {false, "Không hoạt động"}
            };
        }
    }
}