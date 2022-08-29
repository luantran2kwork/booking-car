// Common
import RouteInfo from "./../models/RouteInfo";
import RoleAddNew from "./Administrations/Roles/AddNew";
// Administration - Role
import RoleList from "./Administrations/Roles/Default";
import RoleDisplay from "./Administrations/Roles/Display";
import RoleEdit from "./Administrations/Roles/Edit";
import Home from "./Home";


const RouteUrls = class {
    static Default: string = "list";
    static AddNew: string = "addnew";
    static Edit: string = "edit";
    static Display: string = "display";
    static Setting: string = "setting";
    static Review: string = "review";

    static ExportProposal: string = "exportproposal";
    static ImportProposal: string = "importproposal";

    static TabHopDongEdit: string = 'mortgage-contract-edit';
    static TabHopDongDisplay: string = 'mortgage-contract-info';
};

/**
 * Full Route collection
 */
const RouteCollection: RouteInfo[] = [
    // Addministration - Role
    new RouteInfo("/administration/roles/list", "", RoleList, true),
    new RouteInfo("/administration/roles/addnew", "", RoleAddNew, true),
    new RouteInfo("/administration/roles/edit", "/:id", RoleEdit, true),
    new RouteInfo("/administration/roles/display", "/:id", RoleDisplay, true),

    new RouteInfo("", "", Home, true),

];

const GetRouteInfoByPath = (path: string) => {
    path = path.toLowerCase();
    let enRoute = RouteCollection.find((en) => en.Path.toLowerCase() === path);
    return enRoute;
};

export { RouteUrls, RouteCollection, GetRouteInfoByPath };
