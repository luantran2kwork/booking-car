import * as Enums from "./Enums";
export default class SMX {
  static PageSize = 20;
  static StoreName = class {
    static GlobalStore = "GlobalStore";
  };

  static PromisePaid = class {
    static dicName: iKeyValuePair<Enums.PromisePaid, string>[] = [
      { Key: Enums.PromisePaid.ThatHua, Value: "BPTP - Không đúng cam kết" },
      { Key: Enums.PromisePaid.TraDu, Value: "KPTP - Đúng cam kết" },
    ];

    static dicColor: iKeyValuePair<Enums.PromisePaid, string>[] = [
      { Key: Enums.PromisePaid.ThatHua, Value: "#EE6400" },
      { Key: Enums.PromisePaid.TraDu, Value: "#597EF7" },
    ];
  };

  static NotificationType = class {
    static dicName: iKeyValuePair<Enums.NotificationType, string>[] = [
      { Key: Enums.NotificationType.SinhNhat, Value: "Sinh nhật" },
      { Key: Enums.NotificationType.KyNiem, Value: "Kỷ niệm" },
      { Key: Enums.NotificationType.ThanhLap, Value: "Thành lập" },
      { Key: Enums.NotificationType.TruyenThong, Value: "Truyền thống" },
    ];
  };

  static Attitudes = class {
    static dicName: iKeyValuePair<Enums.Attitude, string>[] = [
      { Key: Enums.Attitude.TichCuc, Value: "Tích cực" },
      { Key: Enums.Attitude.TieuCuc, Value: "Tiêu cực" },
      { Key: Enums.Attitude.TrungLap, Value: "Trung lập" },
    ];

    static dicColor: iKeyValuePair<Enums.Attitude, string>[] = [
      { Key: Enums.Attitude.TichCuc, Value: "#597EF7" },
      { Key: Enums.Attitude.TieuCuc, Value: "#EE6400" },
      { Key: Enums.Attitude.TrungLap, Value: "#389E0D" },
    ];
  };

  static RelationshipWithMB = class {
    static dicName: iKeyValuePair<Enums.RelationshipWithMB, string>[] = [
      { Key: Enums.RelationshipWithMB.NongAm, Value: "Nồng ấm" },
      { Key: Enums.RelationshipWithMB.ThietLap, Value: "Thiết lập" },
      { Key: Enums.RelationshipWithMB.HieuBiet, Value: "Hiểu biết" },
      { Key: Enums.RelationshipWithMB.ThanThiet, Value: "Thân thiết" },
    ];

    static dicColor: iKeyValuePair<Enums.RelationshipWithMB, string>[] = [
      { Key: Enums.RelationshipWithMB.NongAm, Value: "#597EF7" },
      { Key: Enums.RelationshipWithMB.ThietLap, Value: "#EE6400" },
      { Key: Enums.RelationshipWithMB.HieuBiet, Value: "#389E0D" },
      { Key: Enums.RelationshipWithMB.ThanThiet, Value: "#D9001B" },
    ];
  };

  static PositiveType = class {
    static readonly dicName: iKeyValuePair<Enums.PositiveType, string>[] = [
      { Key: Enums.PositiveType.TruyenHinh, Value: "Truyền hình" },
      { Key: Enums.PositiveType.BaoMang, Value: "Báo mạng" },
      { Key: Enums.PositiveType.BaoGiay, Value: "Báo giấy" },
      { Key: Enums.PositiveType.MangXaHoi, Value: "Mạng xã hội" },
      { Key: Enums.PositiveType.DienDan, Value: "Diễn đàn" },
    ];
  };

  static NegativeNews = class {
    static readonly dicName: iKeyValuePair<Enums.NegativeNews, string>[] = [
      { Key: Enums.NegativeNews.ChuaPhatSinh, Value: "Chưa lên báo" },
      { Key: Enums.NegativeNews.DaPhatSinh, Value: "Đã lên báo" },
    ];
    static readonly dicColor: iKeyValuePair<Enums.NegativeNews, string>[] = [
      { Key: Enums.NegativeNews.ChuaPhatSinh, Value: "#597EF7" },
      { Key: Enums.NegativeNews.DaPhatSinh, Value: "#D9001B" },
    ];
  };

  static NewStatus = class {
    static dicName: iKeyValuePair<Enums.NewStatus, string>[] = [
      { Key: Enums.NewStatus.MoiTao, Value: "Đang xử lý" },
      { Key: Enums.NewStatus.HoanThanh, Value: "Hoàn thành" },
    ];
    static readonly dicColor: iKeyValuePair<Enums.NewStatus, string>[] = [
      { Key: Enums.NewStatus.MoiTao, Value: "#EE6400" },
      { Key: Enums.NewStatus.HoanThanh, Value: "#389E0D" },
    ];
  };

  static Classification = class {
    static readonly dicName: iKeyValuePair<Enums.Classification, string>[] = [
      { Key: Enums.Classification.BinhThuong, Value: "Bình thường" },
      { Key: Enums.Classification.QuanTrong, Value: "Quan trọng" },
      { Key: Enums.Classification.TrungBinh, Value: "Trung bình" },
    ];
    static readonly dicColor: iKeyValuePair<Enums.Classification, string>[] = [
      { Key: Enums.Classification.BinhThuong, Value: "#2F54EB" },
      { Key: Enums.Classification.QuanTrong, Value: "red" },
      { Key: Enums.Classification.TrungBinh, Value: "green" },
    ];
  };

  // Trạng thái Yes/No
  static YesNo = class {
    static Yes = true;
    static No = false;

    static dicName: iKeyValuePair<boolean, string>[] = [
      { Key: true, Value: "Có" },
      { Key: false, Value: "Không" },
    ];
  };

  // Giới tính
  static Gender = class {
    static readonly dicName: iKeyValuePair<Enums.Gender, string>[] = [
      { Key: Enums.Gender.Male, Value: "Nam" },
      { Key: Enums.Gender.Female, Value: "Nữ" },
      { Key: Enums.Gender.Other, Value: "Khác" },
    ];
  };

  static NewsStatus = class {
    static readonly dicName: iKeyValuePair<Enums.NewsStatus, string>[] = [
      { Key: Enums.NewsStatus.HoanThanh, Value: "Hoàn hành" },
      { Key: Enums.NewsStatus.MoiTao, Value: "Mới tạo" },
    ];

    static readonly dicColorBackground: iKeyValuePair<
      Enums.NewsStatus,
      string
    >[] = [
      { Key: Enums.NewsStatus.HoanThanh, Value: "#F0F5FF" },
      { Key: Enums.NewsStatus.MoiTao, Value: "#FFF7E6" },
    ];

    static readonly dicColor: iKeyValuePair<Enums.NewsStatus, string>[] = [
      { Key: Enums.NewsStatus.HoanThanh, Value: "#2F54EB" },
      { Key: Enums.NewsStatus.MoiTao, Value: "#FA8C16" },
    ];

    static readonly dicIcons: iKeyValuePair<Enums.NewsStatus, string>[] = [
      { Key: Enums.NewsStatus.HoanThanh, Value: "download" },
      { Key: Enums.NewsStatus.MoiTao, Value: "arrow-right" },
    ];
  };

  static KyHuaTra = class {
    static readonly dicName: iKeyValuePair<Enums.KyHuaTra, string>[] = [
      { Key: Enums.KyHuaTra.k1, Value: "Hứa trả 1 kỳ" },
      { Key: Enums.KyHuaTra.k2, Value: "Hứa trả 2 kỳ" },
      { Key: Enums.KyHuaTra.k3, Value: "Hứa trả 3 kỳ" },
      { Key: Enums.KyHuaTra.k4, Value: "Tất cả" },
    ];
  };

  static AttachmentRefType = class {
    static readonly dicName: iKeyValuePair<Enums.AttachmentRefType, string>[] =
      [{ Key: Enums.AttachmentRefType.MortgageAsset, Value: "Tài sản" }];
  };

  static ValidateDocumentReason = class {
    static readonly dicValidateDocumentReason: iKeyValuePair<
      Enums.ValidateDocumentReason,
      string
    >[] = [
      { Key: Enums.ValidateDocumentReason.BoSungHoSo, Value: "Bổ sung hồ sơ" },
      {
        Key: Enums.ValidateDocumentReason.XacMinhQuyHoach,
        Value: "Xác minh quy hoạch",
      },
      {
        Key: Enums.ValidateDocumentReason.XacMinhViTri,
        Value: "Xác minh vị trí",
      },
      {
        Key: Enums.ValidateDocumentReason.XacMinhTranhChap,
        Value: "Xác minh tranh chấp",
      },
      {
        Key: Enums.ValidateDocumentReason.KhachHangKhongVayNua,
        Value: "Khách hàng không vay nữa",
      },
      { Key: Enums.ValidateDocumentReason.LyDoKhac, Value: "Lý do khác" },
    ];
  };
  
  static MapDocumentRequireStatus_N1 = {
    Suggest : true,
    Obligatory: false,
  }
  static MapDocumentRequireStatus = class {
    static readonly dtcMapDocumentTypeStatus: iKeyValuePair<
      boolean,
      string
    >[] = [
      { Key: SMX.MapDocumentRequireStatus_N1.Suggest, Value: "Nên có" },
      { Key: SMX.MapDocumentRequireStatus_N1.Obligatory, Value: "Bắt buộc" },
    ];
  };

  static ProcessValuationDocumentContactType = class {
    static readonly dicName: iKeyValuePair<
      Enums.ProcessValuationDocumentContactType,
      string
    >[] = [
      {
        Key: Enums.ProcessValuationDocumentContactType.ChualienLacDuoc,
        Value: "Chưa liên lạc được",
      },
      {
        Key: Enums.ProcessValuationDocumentContactType.LienLacDuoc,
        Value: "Liên lạc được",
      },
    ];
  };

  static ProcessValuationVehicle = class {
    static Vehicle_Khac = "PTVT_Khac";
    static LoaiXe_Khac = "LoaiXe_Khac";
    static LoaiXe_ChuyenDung = "2014_XeChuyenDung";
  };

  static ApiActionCode = class {
    static SetupViewForm = "SetupViewForm";
    static SearchData = "SearchData";
    static SetupEditForm = "SetupEditForm";
    static SaveItem = "SaveItem";
    static SetupDisplay = "SetupDisplay";
    static DeleteItem = "DeleteItem";
    static Request = "Request";
    static Approve = "Approve";
    static Reject = "Reject";
    static SaveImage = "SaveImage";
    static RejectBatch = "RejectBatch";
    static DetailDisplay = "DetailDisplay";
    static UpdateAttachment = "UpdateAttachment";
    static UploadImage = "UploadImage";
    static InsertLog = "InsertLog";
    static UploadFile = "UploadFile";
    static DeletedImage = "DeletedImage";
    static GetListImage = "GetListImage";
    //Lấy thông tin người đăng nhập
    static GetProfile = "GetProfile";

    static OTP = "OTP";

    static Verify_OTP = "Verify_OTP";

    static CancelItem = "CancelItem";

    static SetupViewREForm = "SetupViewREForm";

    static ValuationREs = "ValuationREs";

    static SetupViewVehicleForm = "SetupViewVehicleForm";

    static ValuationVehicles = "ValuationVehicles";

    static SetupViewCondominiumForm = "SetupViewCondominiumForm";

    static ValuationCondominiums = "ValuationCondominiums";

    static DanhsachTSKhaoSat = "DanhsachTSKhaoSat";

    static LoadData = "LoadData";

    static CheckIn = "CheckIn";

    static SaveActions = "SaveActions";

    static SetupFormRE = "SetupFormRE";

    static UploadImageConstructionID = "UploadImageConstructionID";

    static LoadListConstructionREContruction = "LoadListConstructionREContruction";

    static DeleteConstruction = "DeleteConstruction";

    static DeletedImageConstruction = "DeletedImageConstruction";

    static LoadListConstructionREApartment = "LoadListConstructionREApartment";

    static LoadListApartment = "LoadListApartment";

    static DeleteApartment = "DeleteApartment";

    static DocumentRequest = "DocumentRequest";

    static SaveData = "SaveData";

    static GetAttachmentByECMID = "GetAttachmentByECMID";

    static Done = "Done";

    static CheckExistsPVEBatchEquipment = "CheckExistsPVEBatchEquipment";

    static GetProcessValuationEquipmentByID = "GetProcessValuationEquipmentByID";

    static LoadDataBatch = "LoadDataBatch";

    static SaveDataPVE = "SaveDataPVE";

    static SaveComplete = "SaveComplete";

    static GetProcessValuationREByMA = "GetProcessValuationREByMA";

    static SaveDataRE = "SaveDataRE";

    static GetListValuationApproving = "GetListValuationApproving";

    static GetPVDApproving = "GetPVDApproving";

    static GetListEmployee = "GetListEmployee";

    static ApprovalManuallyPVD = "ApprovalManuallyPVD";

    static Setup_PreLiminareQuote = "Setup_PreLiminareQuote";

    static Load_PreLiminareQuote = "Load_PreLiminareQuote";

    static UpdateData_PreLiminareQuote = "UpdateData_PreLiminareQuote";

    static GetListValuation = "GetListValuation";

    static LoadDataBatchRE = "LoadDataBatchRE";

  };

  static Features = class {
    static AddressProvince = 1204;
    static AddressDistrict = 1205;
    static AddressTown = 1206;
    static AddressStreet = 1207;
    static ComparingMASourceType = 1336;
    static DocumentType = 1313;
    static LandType = 1339;
    static smx_CollateralGroup_1 = 2004;
  };

  static RandomColor = [
    "#02c39a",
    "#fb5607",
    "#028090",
    "#3a86ff",
    "#8338ec",
    "#ff006e",
    "#e63946",
    "#8ac926",
    "#fee440",
    "#f15bb5",
    "#9a031e",
    "#5f0f40",
    "#7678ed",
    "#245501",
    "#926c15",
  ];

  static BtnColor = ["#0fe7d4", "#ed9a1e"];
  
  //Màu của các Button
  static BtnColorABB = ["#0fe7d4", "#ed9a1e"];

  //Màu của các Button không pha màu
  static BtnColorABBNotTinting = "#00ae9f" ;;

  // Màu của nút thêm CTXD
  static BtnColorABB_Chird = ["#00ae9f", "#00ae9f"];

  static TextColorABB = "#00ae9f" ;

  static TextColorItemListABB = "#00ae9f" ;

  //Màu của Loadding
  static ColorLoaddingABB = "#00ae9f" ;

  static IconImage = "file-image";

  static ActionCode = class {
    static Calculate_Price = "Calculate_Price";
    static Verify_OTP = "Verify_OTP";
    static OTP = "OTP";
  };

  static DocumentCode = class {
    static DocumentWorkfield = "BienBan_KSHT";
    static ValuationReport = "BCDG";
    static ValuationReport_Scan = "BCDG_BanScan";
    static TaiLieuKhac = "TaiLieu_Khac";
    static ChungThuBenThu3 = "BenThu3_ChungThu";
    static KhoGia = "KhoGia";
    static TuVanGia = "TuVanGia";
    static SiteCheckSuggester = "SiteCheckSuggester";
    static BienBanTienKiem = "BienBanTienKiem";
    static BienBanThamDinh = "BienBanThamDinh";
    static SiteCheckValuationReport = "BCTĐ";
  };

  static MortgageAssetCode2 = class {
    // BDS
    static BatchEquipments = "BatchEquipments";
    static BatchVehicles = "BatchVehicles";
    static Equipments = "Equipments";
    static REApartments = "REApartments";
    static REBuildings = "REBuildings";
    static RECondominiums = "RECondominiums";
    static REFactories = "REFactories";
    static REProjects = "REProjects";
    static REResidentials = "REResidentials";
    static VehicleRoads = "VehicleRoads";
    static Vessels = "Vessels";
    static Workfields = "Workfields";
    static BatchRE = "BatchRE";
  };
  static ProcessValuationREFrontageType = class {
    static readonly dicProcessValuationREFrontageType: iKeyValuePair<
      Enums.ProcessValuationREFrontageType,
      string
    >[] = [
      {
        Key: Enums.ProcessValuationREFrontageType.MatDuongPho,
        Value: "Mặt đường/Phố",
      },
      {
        Key: Enums.ProcessValuationREFrontageType.MatNgoHem,
        Value: "Mặt ngõ/hẻm",
      },
      {
        Key: Enums.ProcessValuationREFrontageType.MatDuongNoiBo,
        Value: "Mặt đường nội bộ",
      },
    ];
  };
  // static TransformerType = class {
  //   static dicTransformerType: iKeyValuePair<
  //     Enums.TransformerType,
  //     string
  //   >[] = [
  //     { Key: Enums.TransformerType.Nhua, Value: "Nhựa " },
  //     { Key: Enums.TransformerType.BeTong, Value: "Bê tông " },
  //     { Key: Enums.TransformerType.Da, Value: "Đá " },
  //     { Key: Enums.TransformerType.Dat, Value: "Đất " },
  //     { Key: Enums.TransformerType.Thuy, Value: "Thủy  " },
  //   ];
  // };
  static TypeOfConstruction = class {
    static dicTypeOfConstruction: iKeyValuePair<
      Enums.TypeOfConstruction,
      string
    >[] = [
      {
        Key: Enums.TypeOfConstruction.ToanNhaVPTM,
        Value: "Tòa nhà văn phòng, thương mại  ",
      },
      { Key: Enums.TypeOfConstruction.SanVP, Value: "Sàn văn phòng " },
      { Key: Enums.TypeOfConstruction.KhachSan, Value: "Khách sạn " },
      {
        Key: Enums.TypeOfConstruction.ToaNhaHonHopVPVaKS,
        Value: "Tòa nhà hỗn hợp văn phòng và khách sạn ",
      },
      {
        Key: Enums.TypeOfConstruction.ToaNhaHonHopVPVaNO,
        Value: "Tòa nhà hỗn hợp văn phòng và nhà ở ",
      },
      {
        Key: Enums.TypeOfConstruction.ToaNhaHonHopKSVaNO,
        Value: "Tòa nhà hỗn hợp khách sạn và nhà ở ",
      },
      {
        Key: Enums.TypeOfConstruction.ToaNHaHonHopTMVaNO,
        Value: "Tòa nhà hỗn hợp thương mại và nhà ở ",
      },
      { Key: Enums.TypeOfConstruction.Khac, Value: "Khác " },
    ];
  };
  static SaveType = class {
    static dicSaveType: iKeyValuePair<Enums.SaveType, string>[] = [
      { Key: Enums.SaveType.Temporary, Value: "Temporary  " },
      { Key: Enums.SaveType.Completed, Value: "Completed " },
    ];
  };
  static WorkfieldImageType = class {
    static HinhAnh_BenNgoai = "HinhAnh_BenNgoai";
    static HinhAnh_BenTrong = "HinhAnh_BenTrong";
  };

  static WorkfieldImageTypeREFactories = class {
    static BenNgoai_CTXD = "BenNgoai_CTXD";
    static BenTrong_CTXD = "BenTrong_CTXD";
  };
}
