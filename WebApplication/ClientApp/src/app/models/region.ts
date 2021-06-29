import { IBase } from "./base";
import { IGround } from "./ground";

export interface IRegion extends IBase{
    name: string,
    grounds: IGround[]
}