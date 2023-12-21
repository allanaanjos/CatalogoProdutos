import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, Validators } from '@angular/forms';
import { Produto} from 'src/app/service/Produto';
import { ProdutoService } from 'src/app/service/ProdutoService';


@Component({
  selector: 'app-novo-produto',
  templateUrl: './novo-produto.component.html',
  styleUrls: ['./novo-produto.component.css']
})
export class NovoProdutoComponent implements OnInit {
 btnText: string = "cadastrar produto"
  produtoForm!: FormGroup;
  produtoPostBody!: Produto;
  resposta!:Produto;
  tiporesp:string [] = ['Orgânico', 'Não Orgânico']
  isLoading: boolean = false;
  
  
  constructor(private produtoService:ProdutoService) { }

  ngOnInit(): void { 

    this.produtoForm = new FormGroup({
      nome: new FormControl('', Validators.required),
      preco: new FormControl('', Validators.required),
      descricao: new FormControl('', Validators.required),
      quantidade: new FormControl('', Validators.required),
      tipo: new FormControl('', Validators.required)
    })
  }  

 

  get nomeProduto(){
    return this.produtoForm.get('nome')!;
  }

  get preco(){
    return this.produtoForm.get('preco')!;
  }

  get descricao(){
    return this.produtoForm.get('descricao')!;
  }

  get quantidade(){
    return this.produtoForm.get('quantidade')!;
  }

  get tipo(){
    return this.produtoForm.get('tipo')!;
  }
  submit() {

    if (this.produtoForm.invalid) {
      this.produtoForm.markAllAsTouched();
      return;
    }

    this.isLoading =true;
  
    const body = this.criaPostModel(); 
  
    this.produtoService.createProduto(body).subscribe(
      resposta => {
        this.resposta = resposta;
        console.log('Produto cadastrado com sucesso:', resposta);
      },
      error => {
        console.error('Erro na requisição HTTP:', error);  
        if (error instanceof HttpErrorResponse && error.status === 400) {
       
          console.log('Detalhes do erro de validação:', error.error);

          const descricaoErrors = error.error.errors.Descricao;
          if (descricaoErrors && descricaoErrors.length > 0) {
         
            console.log('Erros no campo "Descricao":', descricaoErrors);  
          
            alert('Erro: ' + descricaoErrors.join(', '));
          }
        }
      },
      () => {
        alert('Produto Salvo com Sucesso!');
        this.isLoading = false; 
        this.limparCampos();
      }    
    );
  }

  limparCampos(){
    this.produtoForm.reset();

    Object.keys(this.produtoForm.controls).forEach(controlName => {
      let control:any = this.produtoForm.get(controlName);
      control.setErrors(null);
    });
    this.produtoForm.markAsPristine();
    this.produtoForm.markAsUntouched();
  }
  
  criaPostModel():Produto{
    return {
       nome: this.nomeProduto.value,
       preco: this.preco.value,
       descricao: this.descricao.value,
       quantidade: this.quantidade.value,
       tipo: this.tipo.value,
    }

  }



}
