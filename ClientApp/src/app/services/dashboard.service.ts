import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Category } from '../models/category.model';
import { Product } from '../models/product.model';
import { Brand } from '../models/brand.model';
import { SalesData } from '../models/salesdata.model';

@Injectable({
  providedIn: 'root',
})
export class DashboardService {
  private apiUrl = '/api/dashboard'; // Update with your API URL

  constructor(private http: HttpClient) { }

  getCategories(): Observable<Category[]> {
    return this.http.get<Category[]>(`${this.apiUrl}/categories`);
  }

  getProductsByCategory(categoryId: number): Observable<Product[]> {
    return this.http.get<Product[]>(`${this.apiUrl}/products/${categoryId}`);
  }

  getBrandsByProduct(productId: number): Observable<Brand[]> {
    return this.http.get<Brand[]>(`${this.apiUrl}/brands/${productId}`);
  }

  getSalesData(
    categoryId: number,
    productId: number,
    brandId: number
  ): Observable<SalesData[]> {
    // Modify the API endpoint to match your backend
    return this.http.get<SalesData[]>(
      `${this.apiUrl}/salesdata?categoryId=${categoryId}&productId=${productId}&brandId=${brandId}`
    );
  }
}
