export class Suppliers {
    SupplierID!: number;
    CompanyName: string;
    ContactName: string;
    ContactTitle: string;
    Address: string;
    City: string;
    Region: string;
    PostalCode: string;
    Country: string;
    Phone: string;
    Fax: string;
    isEditing: boolean;
    isCreating: boolean;

    constructor(CompanyName: string, ContactName: string, ContactTitle: string, Address: string, City: string, Region: string, PostalCode: string, Country: string, Phone: string, Fax: string) {
        this.CompanyName = CompanyName;
        this.ContactName = ContactName;
        this.ContactTitle = ContactTitle;
        this.Address = Address;
        this.City = City;
        this.Region = Region;
        this.PostalCode = PostalCode;
        this.Country = Country;
        this.Phone = Phone;
        this.Fax = Fax;
        this.isEditing = false;
        this.isCreating = false;
    }
}