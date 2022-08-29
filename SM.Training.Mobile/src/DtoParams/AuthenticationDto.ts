import { BaseParam } from "./BaseParam";
import Employee from "../Entities/adm_Employee";
import FunctionRight from "../Entities/FunctionRight";

class AuthenticationDto extends BaseParam {
  public UserName?: string;
  public Password?: string;
  public UserToken?: string;

  public LstRight?: FunctionRight[];

  public Employee?: Employee;
  public DeviceName?: string;
  public Guid?: string;
}
export default AuthenticationDto;
