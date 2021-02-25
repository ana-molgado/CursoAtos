import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Cidade } from '../models/Cidade';
import { CidadeService } from '../services/cidade.service';

@Component({
  selector: 'app-cidade',
  templateUrl: './cidade.component.html',
  styleUrls: ['./cidade.component.css']
})
export class CidadeComponent implements OnInit {

  titleCidade = 'Cidades';
  public selectedCidade: Cidade;
  public cidadeForm: FormGroup;

  public cidades: Cidade[];


  createForm(){
    this.cidadeForm = this.fb.group({
      id: [''],
      nome: ['', Validators.required],
      estado: ['', Validators.required]
    })
  }

  selectCidade(cidade: Cidade){
    this.selectedCidade = cidade;
    this.cidadeForm.patchValue(cidade);
  }

  submit(){
    console.log(this.cidadeForm.value);
    this.saveCidade(this.cidadeForm.value);
    
  }

  saveCidade(cidade : Cidade){
    this.cidadeService.edit(cidade).subscribe(
      (retorno: Cidade) => {
        console.log(retorno);
      },
      (error: any) => {
        console.log(error);
      }
    )
  }

  back(){
    this.selectedCidade = null;
    this.loadCidade();
  }

  loadCidade(){
    this.cidadeService.getAll().subscribe(
      (cidades: Cidade[]) => {
        this.cidades = cidades;},
        (error: any) => {console.log(error)}
    );
  }

  deleteCidade(id:number){
    this.cidadeService.delete(id).subscribe(
      (modal: any)=> {
        console.log(modal);
        this.loadCidade();
      },
      (error: any) => {
        console.log(error);
        
      }
    )
  }

  constructor(private fb:FormBuilder, private cidadeService: CidadeService) { 
    this.createForm();
  }

  ngOnInit(): void {
    this.loadCidade()
  }

}
