import {AfterViewInit, Component, ViewChild} from '@angular/core';
import {MatTableDataSource} from '@angular/material/table';
import {MatPaginator} from '@angular/material/paginator';

export interface Shippers {
  companyName: string;
  phone: string;
}

const SHIPPER_DATA: Shippers[] = [
  {companyName: 'Speedy Express', phone: '(503) 555-9831'},
  {companyName: 'United Package', phone: '(503) 555-3199'},
  {companyName: 'Federal Shipping', phone: '(503) 555-9931'},
  {companyName: 'Speedy Express', phone: '(503) 555-9831'},
  {companyName: 'United Package', phone: '(503) 555-3199'},
  {companyName: 'Federal Shipping', phone: '(503) 555-9931'},
  {companyName: 'Speedy Express', phone: '(503) 555-9831'},
  {companyName: 'United Package', phone: '(503) 555-3199'},
  {companyName: 'Federal Shipping', phone: '(503) 555-9931'},
  {companyName: 'Speedy Express', phone: '(503) 555-9831'},
  {companyName: 'United Package', phone: '(503) 555-3199'},
  {companyName: 'Federal Shipping', phone: '(503) 555-9931'},
  {companyName: 'Speedy Express', phone: '(503) 555-9831'},
  {companyName: 'United Package', phone: '(503) 555-3199'},
  {companyName: 'Federal Shipping', phone: '(503) 555-9931'},
];
@Component({
  selector: 'app-shippers',
  templateUrl: './shippers.component.html',
  styleUrls: ['./shippers.component.css']
})
export class ShippersComponent implements AfterViewInit {
  displayedColumns: string[] = ['companyName', 'phone', 'delete', 'edit'];
  dataSource = new MatTableDataSource<Shippers>(SHIPPER_DATA);

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }
}

