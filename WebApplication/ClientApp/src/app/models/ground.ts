import { IBase } from "./base";
import { GroundType } from "./groundType";

export interface IGround extends IBase{
    name: string,
    groundType: GroundType
}