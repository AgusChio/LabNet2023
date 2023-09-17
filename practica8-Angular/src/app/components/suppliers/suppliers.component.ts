import {AfterViewInit, Component, ViewChild} from '@angular/core';
import {MatTableModule} from '@angular/material/table';
import {MatTableDataSource} from '@angular/material/table';
import {MatPaginator, MatPaginatorModule} from '@angular/material/paginator';

import { SuppliersServicesService } from '../service/suppliers.services.service';

import { Suppliers } from '../../core/models/suppliers';
@Component({
  selector: 'app-suppliers',
  templateUrl: './suppliers.component.html',
  styleUrls: ['./suppliers.component.css'],
  standalone: true,
  imports: [ MatTableModule, MatPaginatorModule]
})

export class SuppliersComponent implements AfterViewInit {
  displayedColumns: string[] = ['companyName', 'contactName', 'contactTitle', 'address', 'city', 'region', 'postalCode', 'country', 'phone', 'fax', 'delete', 'edit'];
  dataSource = new MatTableDataSource<Suppliers>([]);

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(private suppliersService: SuppliersServicesService) {}

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  ngOnInit() {
    this.loadSuppliers();
  }

  loadSuppliers() {
    this.suppliersService.getSuppliers().subscribe(
      (suppliers) => {
        this.dataSource.data = suppliers;
      }
    );
  }
}

