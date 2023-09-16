import {AfterViewInit, Component, ViewChild} from '@angular/core';
import {MatTableModule} from '@angular/material/table';
import {MatTableDataSource} from '@angular/material/table';
import {MatPaginator, MatPaginatorModule} from '@angular/material/paginator';

export interface Suppliers {
  companyName: string;
  cantactName: string;
  contactTitle: string;
  address: string;
  city: string;
  region: string;
  postalCode: string;
  country: string;
  phone: string;
  fax: string;
}

const SUPPLIERS_DATA: Suppliers[] = [
  {companyName: 'Hydrogen', cantactName: '1.0079', contactTitle: 'H', address: 'H', city: 'H', region: 'H', postalCode: 'H', country: 'H', phone: 'H', fax: 'H'},
  {companyName: 'Helium', cantactName: '4.0026', contactTitle: 'He', address: 'He', city: 'He', region: 'He', postalCode: 'He', country: 'He', phone: 'He', fax: 'He'},
  {companyName: 'Lithium', cantactName: '6.941', contactTitle: 'Li', address: 'Li', city: 'Li', region: 'Li', postalCode: 'Li', country: 'Li', phone: 'Li', fax: 'Li'},
  {companyName: 'Beryllium', cantactName: '9.0122', contactTitle: 'Be', address: 'Be', city: 'Be', region: 'Be', postalCode: 'Be', country: 'Be', phone: 'Be', fax: 'Be'},
  {companyName: 'Boron', cantactName: '10.811', contactTitle: 'B', address: 'B', city: 'B', region: 'B', postalCode: 'B', country: 'B', phone: 'B', fax: 'B'},
  {companyName: 'Carbon', cantactName: '12.0107', contactTitle: 'C', address: 'C', city: 'C', region: 'C', postalCode: 'C', country: 'C', phone: 'C', fax: 'C'},
  {companyName: 'Nitrogen', cantactName: '14.0067', contactTitle: 'N', address: 'N', city: 'N', region: 'N', postalCode: 'N', country: 'N', phone: 'N', fax: 'N'},
  {companyName: 'Oxygen', cantactName: '15.9994', contactTitle: 'O', address: 'O', city: 'O', region: 'O', postalCode: 'O', country: 'O', phone: 'O', fax: 'O'},
  {companyName: 'Fluorine', cantactName: '18.9984', contactTitle: 'F', address: 'F', city: 'F', region: 'F', postalCode: 'F', country: 'F', phone: 'F', fax: 'F'},
  {companyName: 'Neon', cantactName: '20.1797', contactTitle: 'Ne', address: 'Ne', city: 'Ne', region: 'Ne', postalCode: 'Ne', country: 'Ne', phone: 'Ne', fax: 'Ne'},
  {companyName: 'Sodium', cantactName: '22.9897', contactTitle: 'Na', address: 'Na', city: 'Na', region: 'Na', postalCode: 'Na', country: 'Na', phone: 'Na', fax: 'Na'},
  {companyName: 'Magnesium', cantactName: '24.305', contactTitle: 'Mg', address: 'Mg', city: 'Mg', region: 'Mg', postalCode: 'Mg', country: 'Mg', phone: 'Mg', fax: 'Mg'},
  {companyName: 'Aluminum', cantactName: '26.9815', contactTitle: 'Al', address: 'Al', city: 'Al', region: 'Al', postalCode: 'Al', country: 'Al', phone: 'Al', fax: 'Al'},
  {companyName: 'Silicon', cantactName: '28.0855', contactTitle: 'Si', address: 'Si', city: 'Si', region: 'Si', postalCode: 'Si', country: 'Si', phone: 'Si', fax: 'Si'},
  {companyName: 'Phosphorus', cantactName: '30.9738', contactTitle: 'P', address: 'P', city: 'P', region: 'P', postalCode: 'P', country: 'P', phone: 'P', fax: 'P'},
  {companyName: 'Sulfur', cantactName: '32.065', contactTitle: 'S', address: 'S', city: 'S', region: 'S', postalCode: 'S', country: 'S', phone: 'S', fax: 'S'},
  {companyName: 'Chlorine', cantactName: '35.453', contactTitle: 'Cl', address: 'Cl', city: 'Cl', region: 'Cl', postalCode: 'Cl', country: 'Cl', phone: 'Cl', fax: 'Cl'},
  {companyName: 'Argon', cantactName: '39.948', contactTitle: 'Ar', address: 'Ar', city: 'Ar', region: 'Ar', postalCode: 'Ar', country: 'Ar', phone: 'Ar', fax: 'Ar'},
  {companyName: 'Potassium', cantactName: '39.0983', contactTitle: 'K', address: 'K', city: 'K', region: 'K', postalCode: 'K', country: 'K', phone: 'K', fax: 'K'},
  {companyName: 'Calcium', cantactName: '40.078', contactTitle: 'Ca', address: 'Ca', city: 'Ca', region: 'Ca', postalCode: 'Ca', country: 'Ca', phone: 'Ca', fax: 'Ca'},
];

@Component({
  selector: 'app-suppliers',
  templateUrl: './suppliers.component.html',
  styleUrls: ['./suppliers.component.css'],
  standalone: true,
  imports: [ MatTableModule, MatPaginatorModule]
})

export class SuppliersComponent implements AfterViewInit {
  displayedColumns: string[] = ['companyName', 'cantactName', 'contactTitle', 'address', 'city', 'region', 'postalCode', 'country', 'phone', 'fax', 'delete','edit'];
  dataSource = new MatTableDataSource<Suppliers>(SUPPLIERS_DATA);

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }
}

