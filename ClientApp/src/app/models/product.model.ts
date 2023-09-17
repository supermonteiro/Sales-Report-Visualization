import { Brand } from "./brand.model";
import { Category } from "./category.model";

export interface Product {
  productId: number;
  name: string;
  categoryId: number;
  category: Category; 
  brandId: number;
  brand: Brand; 
}
