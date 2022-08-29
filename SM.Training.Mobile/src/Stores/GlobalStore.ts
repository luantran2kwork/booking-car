import {
  observable,
  action,
  runInAction,
  computed,
  IObservableValue,
} from "mobx";
import { ProcessValuationDocumentFilter } from "../DtoParams/ProcessValuationDocumentDto";
import adm_Attachment from "../Entities/adm_Attachment";
import { SMXException } from "../SharedEntity/SMXException";

export default class GlobalStore {
  @observable Exception?: SMXException;

  @observable IsLoading?: boolean;

  @observable UpdatedStatusTrigger?: any;

  @observable DSFilterValue?: ProcessValuationDocumentFilter;

  @observable DS_TSKS_FilterValue?: ProcessValuationDocumentFilter;

  @observable DS_DinhGia_FilterValue?: ProcessValuationDocumentFilter;

  @observable DS_KySo_FilterValue?: ProcessValuationDocumentFilter;

  @observable DS_Approving_FilterValue?: ProcessValuationDocumentFilter;

  @observable DanhSachTSKhaoSatFilterTrigger?: any;

  @observable ApprovingValuationFilterTrigger?: any;

  @observable HoSoDangDinhGiaFilterTrigger?: any;

  @observable HoSoDangKySoFilterTrigger?: any;

  @observable UpdatedStatusTriggerDSAll?: any;

  @observable ProcessValuationDocumentID?: number;

  @observable IsHasNotification?: any;

  @observable UpdateImageTrigger?: any;

  @observable ImageValueUpdatedSDVT?: adm_Attachment;

  @observable ImageValueUpdatedSDQH?: adm_Attachment;

  @observable ImageChangedInFlatList?: boolean;

  @observable UpdateActField?: any;

  // Bật loading
  @action ShowLoading() {
    this.IsLoading = true;
  }

  // Tắt loading
  @action HideLoading() {
    this.IsLoading = false;
  }

  @action HandleException = (ex?: SMXException) => {
    this.Exception = ex;
  };
}
