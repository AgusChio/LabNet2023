import { Component, OnInit, AfterViewInit, ViewChild } from '@angular/core';
import {MatTableDataSource} from '@angular/material/table';
import {MatPaginator} from '@angular/material/paginator';
import { ShippersServicesService } from '../service/shippers.services.service';
import { Shippers } from 'src/app/core/models/shippers';
@Component({
  selector: 'app-shippers',
  templateUrl: './shippers.component.html',
  styleUrls: ['./shippers.component.css']
})


export class ShippersComponent implements AfterViewInit, OnInit {
  displayedColumns: string[] = ['companyName', 'phone', 'delete', 'edit'];
  dataSource = new MatTableDataSource<Shippers>([]);

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(private shippersService: ShippersServicesService) {}

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  ngOnInit() {
    this.loadShippers();
  }

  loadShippers() {
    this.shippersService.getShippers().subscribe(
      (shippers) => {
        this.dataSource.data = shippers;
      }
    );
  }
}