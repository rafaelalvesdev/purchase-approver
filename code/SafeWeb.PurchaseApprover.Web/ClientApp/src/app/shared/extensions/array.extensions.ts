export { };

declare global {
    interface Array<T> {
        first(): T;
        remove(property: string, value: any): T;
        isEmpty(): boolean;
    }
}

Array.prototype.first = function <T>(): T {
    if (this && this.length > 0) {
        return this[0];
    }
};

Array.prototype.remove = function <T>(property: string, value: any): T {
    if (this) {
        for (let index = 0; index < this.length; index++) {
            if (this[index][property] === value) {
                return this.splice(index, 1).first();
            }
        }
    }
};

Array.prototype.isEmpty = function <T>(): boolean {
    return this && this.length === 0;
};
