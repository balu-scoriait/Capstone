import { Component, OnInit, ViewChild } from '@angular/core';
import { CartService } from '../../cart.service';
import { ICart } from '../../ICart';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-cart-list',
  templateUrl: './cart-list.component.html',
  styleUrls: ['./cart-list.component.css']
})
export class CartListComponent implements OnInit {
  cart: ICart[] = []

  displayedColumns: string[] = ['product_id', 'product_name', 'product_price', 'image_url', 'product_quantity', 'total_price', 'Perform'];
  dataSource !: MatTableDataSource<any>;
  @ViewChild(MatPaginator) paginator !: MatPaginator;


  constructor(private cartService: CartService) { }
  ngOnInit(): void {
    this.getAllProducts();
  }





  getAllProducts() {
    this.cartService.getcart().subscribe({
      next: (result: any[] | undefined) => {
        this.dataSource = new MatTableDataSource(result);
        this.dataSource.paginator = this.paginator;
      }
    })
  }

  deleteEmployee(productid: number) {
    this.cartService.deleteproduct(productid).subscribe({
      next: () => {
        alert("Deleted Successfully..!");
        this.getAllProducts();
      }
    })
  }

  emptycart() {
    this.cartService.removeAllCart();
  }

  deleterow(row: any) {
    this.cartService.removeAllCart(row);
  }
}

