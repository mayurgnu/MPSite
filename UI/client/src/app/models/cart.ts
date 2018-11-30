import { CartItem } from './cartItem';
import { environment } from "../../environments/environment";

export class Cart {
  CartId: number;
  Items: any;
  Total: number;
  TotalItems: number;
  UserId: number;
  CreatedDate: string;
  CartName: string;
  constructor() {
    this.CartName = environment.cartName;
    this.Items = [];
    this.TotalItems = 0;
  }
}
