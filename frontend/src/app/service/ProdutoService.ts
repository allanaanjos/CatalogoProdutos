import { Injectable } from '@angular/core';
import { Observable, catchError, throwError } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Produto } from 'src/app/service/Produto'
import { ResponseProduto } from './ProdutoResponse';

@Injectable({
  providedIn: 'root'
})
export class ProdutoService {


private url = "https://localhost:7125/api/v1/produto";
  constructor(private http:HttpClient) { }

  getAll(): Observable<ResponseProduto[]> {
    return this.http.get<ResponseProduto[]>(this.url).pipe(
      catchError((error) => {
        console.error('Erro na requisição getAll', error);
        return throwError(error);
      })
    );
  }
  
 createProduto(produto: Produto): Observable<Produto>{
    return this.http.post<Produto>(this.url, produto);

  }
}
