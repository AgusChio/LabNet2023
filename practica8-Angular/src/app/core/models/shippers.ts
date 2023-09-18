export class Shippers {
    ShipperID!: number;
    CompanyName: string;
    Phone: string;
    isEditing: boolean;

    constructor(CompanyName: string, Phone: string) {
        this.CompanyName = CompanyName;
        this.Phone = Phone;
        this.isEditing = false;
    }
}