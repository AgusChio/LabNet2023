import { AfterViewInit, Component, ViewChild } from '@angular/core';

import { MatTableModule } from '@angular/material/table';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';

import { FormsModule, ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';

import { SuppliersServicesService } from '../service/suppliers.services.service';
import { Suppliers } from '../../core/models/suppliers';

import Swal from 'sweetalert2';

@Component({
  selector: 'app-suppliers',
  templateUrl: './suppliers.component.html',
  styleUrls: ['./suppliers.component.css'],
  standalone: true,
  imports: [MatTableModule, MatPaginatorModule, FormsModule, CommonModule]
})

export class SuppliersComponent implements AfterViewInit {
  form: FormGroup;
  displayedColumns: string[] = ['companyName', 'contactName', 'contactTitle', 'address', 'city', 'region', 'postalCode', 'country', 'phone', 'fax', 'delete', 'edit'];
  dataSource = new MatTableDataSource<Suppliers>([]);
  editingSupplier: Suppliers | null = null;
  isCreating: boolean = false;
  newSupplier: Suppliers = { SupplierID: 0, CompanyName: '', ContactName: '', ContactTitle: '', Address: '', City: '', Region: '', PostalCode: '', Country: '', Phone: '', Fax: '', isEditing: true, isCreating: true };

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(private suppliersService: SuppliersServicesService, private fb: FormBuilder) {
    this.form = this.fb.group({
      CompanyName: [
        '',
        [Validators.maxLength(40)]
      ],
      ContactName: [
        '',
        [Validators.maxLength(30)]
      ],
      ContactTitle: [
        '',
        [Validators.maxLength(30)]
      ],
      Address: [
        '',
        [Validators.maxLength(60)]
      ],
      City: [
        '',
        [Validators.maxLength(15)]
      ],
      Region: [
        '',
        [Validators.maxLength(15)]
      ],
      PostalCode: [
        '',
        [Validators.maxLength(10)]
      ],
      Country: [
        '',
        [Validators.maxLength(15)]
      ],
      Phone: [
        '',
        [Validators.maxLength(24)]
      ],
      Fax: [
        '',
        [Validators.maxLength(24)]
      ],
    });
  }

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

  saveSupplierEdited() {
    if (this.editingSupplier) {
      if (this.form.get('CompanyName')?.hasError('maxlength')) {
        Swal.fire('Error!', 'The Company Name cannot be longer than 40 characters.', 'error');
        return;
      }

      if (this.form.get('ContactName')?.hasError('maxlength')) {
        Swal.fire('Error!', 'The Contact Name cannot be longer than 30 characters.', 'error');
        return;
      }

      if (this.form.get('ContactTitle')?.hasError('maxlength')) {
        Swal.fire('Error!', 'The Contact Title cannot be longer than 30 characters.', 'error');
        return;
      }

      if (this.form.get('Address')?.hasError('maxlength')) {
        Swal.fire('Error!', 'The Address cannot be longer than 60 characters.', 'error');
        return;
      }

      if (this.form.get('City')?.hasError('maxlength')) {
        Swal.fire('Error!', 'The City cannot be longer than 15 characters.', 'error');
        return;
      }

      if (this.form.get('Region')?.hasError('maxlength')) {
        Swal.fire('Error!', 'The Region cannot be longer than 15 characters.', 'error');
        return;
      }

      if (this.form.get('PostalCode')?.hasError('maxlength')) {
        Swal.fire('Error!', 'The Postal Code cannot be longer than 10 characters.', 'error');
        return;
      }

      if (this.form.get('Country')?.hasError('maxlength')) {
        Swal.fire('Error!', 'The Country cannot be longer than 15 characters.', 'error');
        return;
      }

      if (this.form.get('Phone')?.hasError('maxlength')) {
        Swal.fire('Error!', 'The telephone number cannot be longer than 24 characters.', 'error');
        return;
      }

      if (this.form.get('Fax')?.hasError('maxlength')) {
        Swal.fire('Error!', 'The Fax cannot be longer than 24 characters.', 'error');
        return;
      }
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
    if (this.form.get('CompanyName')?.hasError('maxlength')) {
      Swal.fire('Error!', 'The Company Name cannot be longer than 40 characters.', 'error');
      return;
    }

    if (this.form.get('ContactName')?.hasError('maxlength')) {
      Swal.fire('Error!', 'The Contact Name cannot be longer than 30 characters.', 'error');
      return;
    }

    if (this.form.get('ContactTitle')?.hasError('maxlength')) {
      Swal.fire('Error!', 'The Contact Title cannot be longer than 30 characters.', 'error');
      return;
    }

    if (this.form.get('Address')?.hasError('maxlength')) {
      Swal.fire('Error!', 'The Address cannot be longer than 60 characters.', 'error');
      return;
    }

    if (this.form.get('City')?.hasError('maxlength')) {
      Swal.fire('Error!', 'The City cannot be longer than 15 characters.', 'error');
      return;
    }

    if (this.form.get('Region')?.hasError('maxlength')) {
      Swal.fire('Error!', 'The Region cannot be longer than 15 characters.', 'error');
      return;
    }

    if (this.form.get('PostalCode')?.hasError('maxlength')) {
      Swal.fire('Error!', 'The Postal Code cannot be longer than 10 characters.', 'error');
      return;
    }

    if (this.form.get('Country')?.hasError('maxlength')) {
      Swal.fire('Error!', 'The Country cannot be longer than 15 characters.', 'error');
      return;
    }

    if (this.form.get('Phone')?.hasError('maxlength')) {
      Swal.fire('Error!', 'The telephone number cannot be longer than 24 characters.', 'error');
      return;
    }

    if (this.form.get('Fax')?.hasError('maxlength')) {
      Swal.fire('Error!', 'The Fax cannot be longer than 24 characters.', 'error');
      return;
    }
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

