import { IModelBase } from './model-base.interface';

export interface ISupplier extends IModelBase {
    name: string;
    documentNumber: string;
    phone: string;
    email: string;
}