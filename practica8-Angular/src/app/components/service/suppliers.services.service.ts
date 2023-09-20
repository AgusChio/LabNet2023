import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Suppliers } from 'src/app/core/models/suppliers'; 
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SuppliersServicesService {

  apiURL: string = environment.apipracticapath;

  constructor(private http:HttpClient) { }

  public getSuppliers(): Observable<Suppliers[]>{
    return this.http.get<Suppliers[]>(`${this.apiURL}Suppliers`);
  }

  public getSupplierById(id: number): Observable<Suppliers>{
    return this.http.get<Suppliers>(`${this.apiURL}Suppliers/${id}`);
  }

  public createSupplier(supplier: Suppliers): Observable<Suppliers>{
    return this.http.post<Suppliers>(`${this.apiURL}Suppliers`, supplier);
  }

  public updateSupplier(supplier: Suppliers): Observable<Suppliers>{
    return this.http.put<Suppliers>(`${this.apiURL}Suppliers/${supplier.SupplierID}`, supplier);
  }

  public deleteSupplier(id: number): Observable<any>{
    return this.http.delete<any>(`${this.apiURL}Suppliers/${id}`);
  }
}
