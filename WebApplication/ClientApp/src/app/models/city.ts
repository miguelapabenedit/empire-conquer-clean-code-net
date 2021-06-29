import { IBase } from "./base";
import { IEmpire } from "./empire";
import { IRegion } from "./region";

export interface ICity extends IBase{
    name: string,
    population: number,
    empire: IEmpire,
    empireId: number,
    region: IRegion,
    regionId: number
}