import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Aluno } from '../models/Aluno';
import { AlunoService } from './aluno.service';

@Component({
  selector: 'app-alunos',
  templateUrl: './alunos.component.html',
  styleUrls: ['./alunos.component.css']
})
export class AlunosComponent implements OnInit {

  public modalRef: BsModalRef;
  public alunoForm: FormGroup;
  public title = 'Alunos';
  public alunoSelecionado: Aluno;
  public textSimple: string;
  public modo = 'post';

  public alunos: Aluno[];

  
 
  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }
  
  constructor(private fb:FormBuilder, 
              private modalService: BsModalService,
              private alunoService: AlunoService) {
    this.createForm();
   }

  ngOnInit(){
    this.carregarAlunos();
  }

  carregarAlunos(){
    this.alunoService.getAll().subscribe(
      (alunos: Aluno[]) => {
        this.alunos = alunos;
      },
      (erro: any) => {
        console.error(erro);
      }
    );
  }

  createForm() {
    this.alunoForm = this.fb.group({
      id:[''],
      nome:['', Validators.required],
      sobrenome:['', Validators.required],
      telefone:['', Validators.required]
    });
  }

  salvarAluno(aluno: Aluno){
    (aluno.id === 0) ? this.modo = 'post' : this.modo = 'put';
    this.alunoService[this.modo](aluno).subscribe(
      (retorno: Aluno) =>{
        console.log(retorno);
        this.carregarAlunos();
      },
      (erro: any) => {
        console.log(erro);
      }
    );
  }

  deletarAluno(id: number){
    this.alunoService.delete(id).subscribe(
      (model: any) =>{
        console.log(model)
      },
      (erro: any) => {
        console.log(erro);
      }
    )
  }

  alunoSubmit(){
    this.salvarAluno(this.alunoForm.value);
  }

  alunoSelect(aluno: Aluno){
    this.alunoSelecionado = aluno;
    this.alunoForm.patchValue(aluno);
  }

  alunoNovo(){
    this.alunoSelecionado = new Aluno;
    this.alunoForm.patchValue(this.alunoSelecionado);
  }

  voltar(){
    this.alunoSelecionado = null;
  }

}
