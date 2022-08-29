import EnvConfig from "../Utils/EnvConfig";

class ApiUrl {
  // Service dùng chung mức hệ thống
  static Global_GetVersion_Api =
    EnvConfig.getApiHost() + "/api/mobile/GetAppInfomation";
  static Global_LogError = EnvConfig.getApiHost() + "/api/mobile/LogError";

  // Authentication
  static Authentication_Login =
    EnvConfig.getApiHost() + "/api/mobile/commons/Authentication/Login";
  static AuthenticationFinger_Login = EnvConfig.getApiHost() + "/api/mobile/commons/Authentication/LoginFinger";
  static Authentication_RequestOTP = EnvConfig.getApiHost() + "/api/mobile/commons/Authentication/Request_OTP";
  static Authentication_VerifyOTP = EnvConfig.getApiHost() + "/api/mobile/commons/Authentication/Verify_OTP";
  static Profile_Execute = EnvConfig.getApiHost() + "/api/mobile/Profile/Action";
  static Authentication_Logout = EnvConfig.getApiHost() + "/api/mobile/commons/Authentication/Logout";
  static Authentication_GetListRight = EnvConfig.getApiHost() + "/api/mobile/commons/Authentication/GetListRight";
  static QuickValuation_Execute = EnvConfig.getApiHost() + "/api/mobile/QuickValuation/Action";

  static ProcessValuationDocument_Execute =
    EnvConfig.getApiHost() + "/api/mobile/ProcessValuationDocument/Action";
  static Action_Execute =
    EnvConfig.getApiHost() + "/api/mobile/Action/Action";
  static Attachment_Execute =
    EnvConfig.getApiHost() + "/api/mobile/Attachment/Action";
  static ProcessValuation_Execute =
    EnvConfig.getApiHost() + "/api/mobile/ProcessValuation/Action";
  static BatchEquipment_Execute =
    EnvConfig.getApiHost() + "/api/mobile/BatchEquipment/Action";
  static VehicleRoad_Execute =
    EnvConfig.getApiHost() + "/api/mobile/VehicleRoad/Action";

  static BatchVehicles_Execute =
    EnvConfig.getApiHost() + "/api/mobile/BatchVehicles/Action";

  static Vessel_Execute =
    EnvConfig.getApiHost() + "/api/mobile/Vessel/Action";
  
  static BatchRE_Execute =
    EnvConfig.getApiHost() + "/api/mobile/BatchRE/Action";

  static MobileLog_Execute =
    EnvConfig.getApiHost() + "/api/mobile/MobileLog/Action";

  static Attachment_PDFView = EnvConfig.getApiHost() + "/api/mobile/public/ViewAttachment";
  
}

export default ApiUrl;
