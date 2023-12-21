import { Component, OnInit } from '@angular/core';
import { ProdutoService } from 'src/app/service/ProdutoService';
import { ResponseProduto } from 'src/app/service/ProdutoResponse';

@Component({
  selector: 'app-produtos',
  templateUrl: './produtos.component.html',
  styleUrls: ['./produtos.component.css']
})
export class ProdutosComponent implements OnInit {
  responseProd: ResponseProduto[] = [];

  constructor(private produtoService: ProdutoService) { }

  ngOnInit(): void {
    this.getProdutos();
  }

  getProdutos(): void {
   this.produtoService.getAll().subscribe(responseProd => {this.responseProd = responseProd 
    console.log(responseProd)
  })
  }
}



