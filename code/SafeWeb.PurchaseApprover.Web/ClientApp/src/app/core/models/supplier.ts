import { ISupplier } from './supplier.interface';

export class Supplier implements ISupplier {
    id: number;
    name: string;
    documentNumber: string;
    phone: string;
    email: string;
}