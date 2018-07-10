import { IModelBase } from './model-base.interface';
import { IUserProfile } from './user-profile.interface';

export interface IUser extends IModelBase {
    name: string;
    documentNumber: string;
    birthDate: Date;
    email: string;
    profile: IUserProfile;
    username: string;
    password: string;
    userProfileId: number;
}