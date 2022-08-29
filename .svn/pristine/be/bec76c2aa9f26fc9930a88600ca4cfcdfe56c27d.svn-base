import ProcessValuation from "../Entities/ProcessValuation";
import ProcessValuationDocument from "../Entities/ProcessValuationDocument";
import ProcessValuationRE from "../Entities/ProcessValuationRE";
import ProcessValuationREApartment from "../Entities/ProcessValuationREApartment";
import ProcessValuationREConstruction from "../Entities/ProcessValuationREConstruction";
import ProcessValuationVehicle from "../Entities/ProcessValuationVehicle";


import adm_SystemParameter from "../Entities/adm_SystemParameter";
import { BaseParam } from "./BaseParam";
import ProcessValuationEquipment from "../Entities/ProcessValuationEquipment";
import MortgageAssetProductionLineDetail from "../Entities/MortgageAssetProductionLineDetail";
import ProcessValuationVessel from "../Entities/ProcessValuationVessel";
import MortgageAsset from "../Entities/MortgageAsset";

export default class ActionMobileDto extends BaseParam {

    public ProcessValuationDocumentID?: number;
    public ProcessValuationDocument?: ProcessValuationDocument;
    public ProcessValuation?: ProcessValuation;
    public MACode2?: string;
    public ProcessValuationRE?: ProcessValuationRE;
    public ProcessValuationREApartment?: ProcessValuationREApartment;
    public ProcessValuationREConstruction?: ProcessValuationREConstruction;
    public LstContiguousStreetType?: adm_SystemParameter[];
    public SaveType? : number;
    public LstBuildingType ?: adm_SystemParameter[];
    public LstConstructionType ?: adm_SystemParameter[];
    public ListProcessValuationREConstruction?: ProcessValuationREConstruction[];
    public ProcessValuationVehicle?: ProcessValuationVehicle;
    public LstCarType ?: adm_SystemParameter[];
    public LstUsePurpose ?: adm_SystemParameter[]; 
    public ListProcessValuationREApartment? : ProcessValuationREApartment[];

    public ProcessValuationEquipment?: ProcessValuationEquipment;

    public MortgageAssetProductionLineDetail?: MortgageAssetProductionLineDetail;

    /**ID máy móc thiết bị */
    public ProcessValuationEquipmentID?: number;

    public ProcessValuationVessel?: ProcessValuationVessel;

    /** */
    public LstMortgageAsset?: MortgageAsset[];

    /** */
    public MortgageAssetID?: number;
}