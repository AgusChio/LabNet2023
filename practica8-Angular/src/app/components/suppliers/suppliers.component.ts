import {AfterViewInit, Component, ViewChild} from '@angular/core';
import {MatTableModule} from '@angular/material/table';
import {MatTableDataSource} from '@angular/material/table';
import {MatPaginator, MatPaginatorModule} from '@angular/material/paginator';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common'; 


import { SuppliersServicesService } from '../service/suppliers.services.service';

import { Suppliers } from '../../core/models/suppliers';

import Swal from 'sweetalert2';

@Component({
  selector: 'app-suppliers',
  templateUrl: './suppliers.component.html',
  styleUrls: ['./suppliers.component.css'],
  standalone: true,
  imports: [ MatTableModule, MatPaginatorModule, FormsModule, CommonModule]
})

export class SuppliersComponent implements AfterViewInit {
  displayedColumns: string[] = ['companyName', 'contactName', 'contactTitle', 'address', 'city', 'region', 'postalCode', 'country', 'phone', 'fax', 'delete', 'edit'];
  dataSource = new MatTableDataSource<Suppliers>([]);
  editingSupplier: Suppliers | null = null;
  isCreating: boolean = false;
  newSupplier: Suppliers = { SupplierID: 0, CompanyName: '', ContactName: '', ContactTitle: '', Address: '', City: '', Region: '', PostalCode: '', Country: '', Phone: '', Fax: '', isEditing: true, isCreating: true };

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

  editSupplier(supplier: Suppliers) {
    supplier.isEditing = true;
    this.editingSupplier = supplier;
  }

  cancelEdit(supplier: Suppliers) {
    this.editingSupplier = null;
    supplier.isEditing = false;
  }

  saveSupplier() {
    if (this.editingSupplier) {
      this.suppliersService.updateSupplier(this.editingSupplier).subscribe(
        (response: Suppliers) => {
          Swal.fire('Success!', 'Supplier updated successfully', 'success');
          this.loadSuppliers();
          this.editingSupplier = null;
        },
        (error) => {
          console.error(error);
          Swal.fire('Error!', 'Failed to update supplier. Error: ' + error.error.ExceptionMessage, 'error');
          setTimeout(() => {
            window.location.reload();
          }, 2000);
        }
      );
    }
  }

  startCreating() {
    this.isCreating = true;
  }

  createSupplier() {
    const newSupplier: Suppliers = { SupplierID: 0, CompanyName: '', ContactName: '', ContactTitle: '', Address: '', City: '', Region: '', PostalCode: '', Country: '', Phone: '', Fax: '', isEditing: true, isCreating: true };
    this.dataSource.data.unshift(newSupplier);
    newSupplier.isEditing = true;
    this.editingSupplier = newSupplier;
  }

  cancelCreating() {
    this.isCreating = false;
    this.newSupplier = { SupplierID: 0, CompanyName: '', ContactName: '', ContactTitle: '', Address: '', City: '', Region: '', PostalCode: '', Country: '', Phone: '', Fax: '', isEditing: true, isCreating: true };
  }

  saveCreatingSupplier() {
    this.suppliersService.createSupplier(this.newSupplier).subscribe(
      (response: Suppliers) => {
        Swal.fire('Success!', 'Supplier created successfully', 'success');
        this.loadSuppliers();
        this.isCreating = false; // Desactiva el modo de creación
        this.newSupplier = { SupplierID: 0, CompanyName: '', ContactName: '', ContactTitle: '', Address: '', City: '', Region: '', PostalCode: '', Country: '', Phone: '', Fax: '', isEditing: true, isCreating: true };
      },
      (error) => {
        console.error(error);
        Swal.fire('Error!', 'Failed to create supplier. Error: ' + error.error.ExceptionMessage, 'error');
        setTimeout(() => {
          window.location.reload();
        }, 2000);
      }
    );
  }

  deleteSupplier(supplier: Suppliers) {
    Swal.fire({
      title: 'Are you sure?',
      text: "You won't be able to revert this operation!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      cancelButtonText: 'Cancel',
      confirmButtonText: 'Yes, Delete!',
    }).then((result) => {
      if (result.isConfirmed) {
        this.suppliersService.deleteSupplier(supplier.SupplierID).subscribe(
          (response: Suppliers) => {
            Swal.fire(
              'Deleted!',
              'The supplier has been deleted.',
              'success'
            ).then(() => {
              this.loadSuppliers();
            });
          },
          (error) => {
            console.error(error);
            Swal.fire('Error!', 'Failed to delete supplier. Error: ' + error.error.ExceptionMessage, 'error');
            setTimeout(() => {
              window.location.reload();
            }, 2000);
          }
        );
      }
    });
  }
}

