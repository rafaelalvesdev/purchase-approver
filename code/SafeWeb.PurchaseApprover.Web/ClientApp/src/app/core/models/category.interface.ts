import { IModelBase } from './model-base.interface';

export interface ICategory extends IModelBase {
    name: string;
    description: string;
}