import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Shippers } from 'src/app/core/models/shippers';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class ShippersServicesService {

  apiURL: string = environment.apipracticapath;

  constructor(private http:HttpClient) { }

  public getShippers(): Observable<Shippers[]>{
    return this.http.get<Shippers[]>(`${this.apiURL}/Shippers`);
  }

  public getShipperById(id: number): Observable<Shippers>{
    return this.http.get<Shippers>(`${this.apiURL}/Shippers/${id}`);
  }

  public createShipper(shipper: Shippers): Observable<Shippers>{
    return this.http.post<Shippers>(`${this.apiURL}/Shippers`, shipper);
  }

  public updateShipper(shipper: Shippers): Observable<Shippers>{
    return this.http.put<Shippers>(`${this.apiURL}/Shippers/${shipper.ShipperID}`, shipper);
  }

  public deleteShipper(id: number): Observable<any>{
    return this.http.delete<any>(`${this.apiURL}/Shippers/${id}`);
  }
}
