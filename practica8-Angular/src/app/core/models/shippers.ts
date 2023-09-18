export class Shippers {
    ShipperID!: number;
    CompanyName: string;
    Phone: string;
    isEditing: boolean;
    isCreating: boolean;

    constructor(CompanyName: string, Phone: string) {
        this.CompanyName = CompanyName;
        this.Phone = Phone;
        this.isEditing = false;
        this.isCreating = false;
    }
}