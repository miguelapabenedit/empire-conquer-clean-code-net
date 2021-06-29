import { IBase } from "./base";

export interface IUser extends IBase{
    firstName: string,
    lastName: string,
    userName: string,
    email: string,
    password: string,
    role:number
}
