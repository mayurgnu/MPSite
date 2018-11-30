import { Component, OnInit } from '@angular/core';
import { StoreService } from '../services/store.service';
import { Product } from '../models/product';

@Component({
  selector: 'app-store',
  templateUrl: './store.component.html'
})
export class StoreComponent implements OnInit {
  products: Product[];
  constructor(private storeService: StoreService) { }

  ngOnInit() {
    this.storeService.GetProducts().subscribe((res) => {
      console.log(res);
      this.products = res;
    });
  }
}
