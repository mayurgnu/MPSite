
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Product } from '../models/product';
import { environment } from '../../environments/environment';
import { Cart } from '../models/cart';

@Injectable()
export class StoreService {
  headers: HttpHeaders
  constructor(private httpClient: HttpClient) {
    this.headers = new HttpHeaders({ 'content-type': 'application/json' })
  }
  GetProducts(): Observable<Product[]> {
    return this.httpClient.get<Product[]>(environment.apiAddress + "/store");
  }
  SaveCart(cart: Cart): Observable<any> {
    return this.httpClient.post<any>(environment.apiAddress + "/store", JSON.stringify(cart),
      { headers: this.headers });
  }
}
