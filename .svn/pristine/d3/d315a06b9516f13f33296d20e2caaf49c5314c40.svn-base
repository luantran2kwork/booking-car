import HttpUtils from "./HttpUtils";
import AuthenticationParam from "../DtoParams/AuthenticationParam";
import ApiUrl from "../constants/ApiUrl";
import GlobalCache from "../Caches/GlobalCache";
import MenuItem from "../Entities/entityInfos/MenuItem";
import FunctionRight from "../Entities/FunctionRight";
import * as Enums from "../constants/Enums";

export default class AuthenticationService {
  static async SignOut() {
    await HttpUtils.post<AuthenticationParam>(ApiUrl.Authentication_Logout, "", JSON.stringify(new AuthenticationParam()));
  }

  static IsSignIn() {
    return GlobalCache.UserToken && GlobalCache.UserToken !== "";
  }

  static GetMenuItem(right: FunctionRight): MenuItem {
    let item = new MenuItem();
    item.Label = "";
    item.NavigationName = "";
    switch (right.FeatureID) {
      case Enums.FeatureID.DanhSachHSDangKSo:
        item.FeatureID = right.FeatureID;
        item.Icon = "pen-fancy";
        item.Label = "DS HS đang Ký Số";
        item.NavigationName = "DSHoSoDangKySo";
        item.Image = require("../../assets/images/material.jpg");
        item.Text1 = "Danh sách HS";
        item.Text2 = "đang ký số";
        break;

      case Enums.FeatureID.TinhTrangCongViec:
        item.FeatureID = right.FeatureID;
        item.Icon = "calendar-check";
        item.Label = "Tình trạng công việc";
        item.NavigationName = "WorkInEmployee";
        item.Image = require("../../assets/images/WorkIn.jpg");
        item.Text1 = "Tình trạng CV";
        item.Text2 = "của chuyên viên";
        break;

      case Enums.FeatureID.DanhSachTSKhaoSat:
        item.FeatureID = right.FeatureID;
        item.Icon = "pencil-ruler";
        item.Label = "DS TS khảo sát";
        item.NavigationName = "DanhSachTSKhaoSat";
        item.Image = require("../../assets/images/workfield.png");
        item.Text1 = "Danh sách";
        item.Text2 = "TS khảo sát";
        break;

      case Enums.FeatureID.DanhSachBCDGChoDuyet:
        item.FeatureID = right.FeatureID;
        item.Icon = "folder-open";
        item.Label = "DS BCĐG chờ duyệt";
        item.NavigationName = "DanhsachBCDGChoDuyet";
        item.Image = require("../../assets/images/approval.png");
        item.Text1 = " Danh sách";
        item.Text2 = "BCĐG chờ duyệt";
        break;

      case Enums.FeatureID.DanhSachHSDangDinhGia:
        item.FeatureID = right.FeatureID;
        item.Icon = "folder";
        item.Label = "DS HS đang ĐG";
        item.NavigationName = "DSHoSoDangDinhGia";
        item.Image = require("../../assets/images/valuation.jpg");
        item.Text1 = "Danh sách HS";
        item.Text2 = "đang định giá";
        break;

      case Enums.FeatureID.TinhGiaNhanhNhaDatPhoThong:
        item.FeatureID = right.FeatureID;
        item.Icon = "home";
        item.Label = "TGN Nhà đất PT";
        item.NavigationName = "ValuationREs";
        item.Image = require("../../assets/images/real_estate.jpg");
        item.Text1 = "Tính giá nhanh";
        item.Text2 = "Nhà đất phổ thông";
        break;

      case Enums.FeatureID.TinhGiaNhanhChungCu:
        item.FeatureID = right.FeatureID;
        item.Icon = "building";
        item.Label = "TGN Chung cư";
        item.NavigationName = "ValuationCondominiums";
        item.Image = require("../../assets/images/condominium.jpg");
        item.Text1 = "Tính giá nhanh";
        item.Text2 = "Chung cư";
        break;

      case Enums.FeatureID.TinhGiaNhanhOto:
        item.FeatureID = right.FeatureID;
        item.Icon = "car";
        item.Label = "TGN PTGTVTĐB";
        item.NavigationName = "ValuationVehicles";
        item.Image = require("../../assets/images/car.jpg");
        item.Text1 = "Tính giá nhanh Oto";
        item.Text2 = "";
        break;
    }

    return item;
  }
}
