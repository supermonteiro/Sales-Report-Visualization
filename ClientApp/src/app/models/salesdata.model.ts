import { Brand } from "./brand.model";
import { Product } from "./product.model";

export interface SalesData {
  salesDataId: number;
  month: Date;
  quantitySold: number;
  productId: number;
  product: Product; 
  brandId: number;
  brand: Brand;   
}
