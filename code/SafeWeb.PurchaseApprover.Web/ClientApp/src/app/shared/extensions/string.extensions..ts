export { };

declare global {
    interface String {
        isNullOrEmpty(): boolean;
    }
}

if (!String.prototype.isNullOrEmpty) {
    String.prototype.isNullOrEmpty = function (): boolean {
        return this === '' || this === null;
    };
}
