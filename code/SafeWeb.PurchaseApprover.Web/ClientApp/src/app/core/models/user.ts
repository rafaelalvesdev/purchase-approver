import { IUser } from './user.interface';
import { UserProfile } from './user-profile';

export class User implements IUser {
    id: number;
    name: string;
    documentNumber: string;
    birthDate: Date;
    email: string;
    profile: UserProfile;
    username: string;
    password: string;
    userProfileId: number;
}