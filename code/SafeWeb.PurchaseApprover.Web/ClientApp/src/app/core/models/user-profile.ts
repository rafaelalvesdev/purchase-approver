import { IUserProfile } from './user-profile.interface';

export class UserProfile implements IUserProfile {
    id: number;
    name: string;
}