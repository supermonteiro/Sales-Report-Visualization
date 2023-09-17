import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Brand } from '../models/brand.model';
import { Category } from '../models/category.model';
import { Product } from '../models/product.model';
import { SalesData } from '../models/salesdata.model';
import { DashboardService } from '../services/dashboard.service';
import { catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';


@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  selectedCategory: number = 1;
  selectedProduct: number = 1;
  selectedBrand: number = 1;
  categories: Category[] = [];
  products: Product[] = [];
  brands: Brand[] = [];
  chartData: any[] = [
    {
      name: 'Month 1',
      value: 0 
    },
    {
      name: 'Month 2',
      value: 0
    },
    {
      name: 'Month 3',
      value: 0
    },
    {
      name: 'Month 4',
      value: 0
    }
  ];

  chartWidth: number = 600;
  chartHeight: number = 400;
  colorScheme: any = {
    domain: ['#5AA454', '#A10A28', '#C7B42C', '#AAAAAA']
  };
  showXAxis: boolean = true;
  showYAxis: boolean = true;
  showLegend: boolean = true;
  xAxisLabel: string = 'X-Axis Label';
  yAxisLabel: string = 'Y-Axis Label';

  constructor(
    private http: HttpClient,
    private dashboardService: DashboardService
  ) { }

  ngOnInit(): void {
    // Fetch initial data for categories
    this.dashboardService.getCategories().subscribe(data => {
      this.categories = data;
    });

    // Fetch initial data for products (default to selected category)
    this.fetchProductsByCategory(this.selectedCategory);    
    
  }

  onCategoryChange(): void {    
      this.fetchProductsByCategory(this.selectedCategory);    
  }

  onProductChange(): void {    
      this.fetchBrandsByProduct(this.selectedProduct);    
  }

  onBrandChange(): void {
    if (this.selectedCategory && this.selectedProduct && this.selectedBrand) {
      this.fetchSalesData(this.selectedCategory, this.selectedProduct, this.selectedBrand);
    }
  }

  fetchProductsByCategory(categoryId: number): void {
    this.dashboardService.getProductsByCategory(categoryId).subscribe(data => {
      this.products = data;
    });
  }

  fetchBrandsByProduct(productId: number): void {
    this.dashboardService.getBrandsByProduct(productId).subscribe(data => {
      this.brands = data;
    });
  }

  fetchSalesData(category: number, product: number, brand: number): void {
    this.dashboardService.getSalesData(category, product, brand)
      .pipe(
        catchError((error) => {
          console.error('Error fetching sales data:', error);          
          return throwError(error);
        })
      )
      .subscribe((data) => {
        this.chartData = data;
        this.updateChartData(data);
      });
  }

  updateChartData(data: SalesData[]): void {    
    this.chartData = data.map(item => ({
      name: item.month, 
      value: item.quantitySold 
    }));
  }

}
