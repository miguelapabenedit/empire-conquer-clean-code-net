import { IBase } from "./base";
import { ICity } from "./city";
import { IUser } from "./user";

export interface IEmpire extends IBase{
    name: string,
    user: IUser,
    userId: number,
    race:number,
    cities: ICity[]
}