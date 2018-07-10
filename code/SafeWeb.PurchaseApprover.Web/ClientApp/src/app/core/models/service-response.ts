export class ServiceResponse<T> {
    data: T;
    isValid: boolean;
    entityKey: any;
    errors: Array<any>;
}
