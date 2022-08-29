import { BaseParam } from "./BaseParam";
import Employee from "../Entities/adm_Employee";
import FunctionRight from "../Entities/FunctionRight";

class AuthenticationParam extends BaseParam {
  public UserName?: string;
  public Password?: string;
  public UserToken?: string;

  public LstRight?: FunctionRight[];

  public Employee?: Employee;
  public DeviceName?: string;
  public Guid?: string;

  /**Mã OTP */
  public OtpCode?: string;
}
export default AuthenticationParam;
