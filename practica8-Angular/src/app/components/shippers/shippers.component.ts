import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { ShippersServicesService } from '../service/shippers.services.service';
import { Shippers } from 'src/app/core/models/shippers';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-shippers',
  templateUrl: './shippers.component.html',
  styleUrls: ['./shippers.component.css']
})
export class ShippersComponent implements OnInit {
  displayedColumns: string[] = ['companyName', 'phone', 'delete', 'edit'];
  dataSource = new MatTableDataSource<Shippers>([]);
  editingShipper: Shippers | null = null;
  isCreating: boolean = false;
  newShipper: Shippers = { ShipperID: 0, CompanyName: '', Phone: '', isEditing: true, isCreating: true};

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(private shippersService: ShippersServicesService) { }

  ngOnInit() {
    this.dataSource.paginator = this.paginator;
    this.loadShippers();
  }

  loadShippers() {
    this.shippersService.getShippers().subscribe(
      (shippers) => {
        this.dataSource.data = shippers;
      }
    );
  }

  editShipper(shipper: Shippers) {
    shipper.isEditing = true;
    this.editingShipper = shipper;
  }

  cancelEdit(shipper: Shippers) {
    this.editingShipper = null;
    shipper.isEditing = false;
  }

  saveShipper() {
    if (this.editingShipper) {
      this.shippersService.updateShipper(this.editingShipper).subscribe(
        (response: Shippers) => {
          Swal.fire('Success!', 'Shipper updated successfully', 'success');
          this.loadShippers();
          this.editingShipper = null;
        },
        (error) => {
          console.error(error);
          Swal.fire('Error!', 'Failed to update shipper. Error: ' + error.error.ExceptionMessage, 'error');
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

  createShipper() {
    const newShipper: Shippers = { ShipperID: 0, CompanyName: '', Phone: '', isEditing: true, isCreating: true};
    this.dataSource.data.unshift(newShipper);
    newShipper.isEditing = true;
    this.editingShipper = newShipper;
}

cancelCreating() {
  this.isCreating = false;
  this.newShipper = { ShipperID: 0, CompanyName: '', Phone: '', isEditing: true, isCreating: true };
}

saveCreatingShipper() {
  this.shippersService.createShipper(this.newShipper).subscribe(
    (response: Shippers) => {
      Swal.fire('Success!', 'Shipper created successfully', 'success');
      this.loadShippers();
      this.isCreating = false; // Desactiva el modo de creación
      this.newShipper = { ShipperID: 0, CompanyName: '', Phone: '', isEditing: true, isCreating: true };
    },
    (error) => {
      console.error(error);
      Swal.fire('Error!', 'Failed to create shipper. Error: ' + error.error.ExceptionMessage, 'error');
      setTimeout(() => {
        window.location.reload();
      }, 2000);
    }
  );
}


  deleteShipper(shipper: Shippers) {
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
        this.shippersService.deleteShipper(shipper.ShipperID).subscribe(
          (response: Shippers) => {
            Swal.fire(
              'Deleted!',
              'The shipper has been deleted.',
              'success'
            ).then(() => {
              this.loadShippers();
            });
          },
          (error) => {
            console.error(error);
            Swal.fire('Error!', 'Failed to delete shipper. Error: ' + error.error.ExceptionMessage, 'error');
            setTimeout(() => {
              window.location.reload();
            }, 2000);
          }
        );
      }
    });
  }
}
