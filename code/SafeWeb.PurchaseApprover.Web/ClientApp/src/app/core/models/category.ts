import { ICategory } from './category.interface';

export class Category implements ICategory {
    id: number;
    name: string;
    description: string;
}