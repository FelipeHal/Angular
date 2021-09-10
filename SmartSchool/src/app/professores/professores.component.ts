import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Professor } from '../models/Professor';
import { ProfessorService } from './professor.service';

@Component({
  selector: 'app-professores',
  templateUrl: './professores.component.html',
  styleUrls: ['./professores.component.css']
})
export class ProfessoresComponent implements OnInit {

  public modalRef: BsModalRef;
  public professorForm: FormGroup;
  public title = 'Professores';
  public professorSelecionado: Professor;
  public textSimple: string;
  public modo = 'post';

  public professores: Professor[];

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }

  constructor(private fb:FormBuilder, 
    private modalService: BsModalService,
    private professorService: ProfessorService) {
    this.createForm()
   }

  ngOnInit() {
    this.carregarProfessores();
  }

  carregarProfessores(){
    this.professorService.getAll().subscribe(
      (professores: Professor[]) => {
        this.professores = professores;
      },
      (erro: any) => {
        console.error(erro);
      } 
    )
  }

  createForm() {
    this.professorForm = this.fb.group({
      id:[''],
      nome:['', Validators.required],
      disciplina:['', Validators.required],
    });
  }

  salvarProfessor(professor: Professor){
    (professor.id === 0) ? this.modo = 'post' : this.modo = 'put';
    this.professorService[this.modo](professor).subscribe(
      (retorno: Professor) =>{
        console.log(retorno);
        this.carregarProfessores();
      },
      (erro: any) => {
        console.log(erro);
      }
    );
  }

  deletarProfessor(id: number){
    this.professorService.delete(id).subscribe(
      (model: any) => {
        console.log(model);
        this.carregarProfessores();
      },
      (erro: any) => {
        console.log(erro);
      }
    );
  }

  professorSubmit(){
    console.log(this.professorForm.value);
  }

  professorSelect(professor: Professor){
    this.professorSelecionado = professor;
    this.professorForm.patchValue(professor);
  }

  professorNovo(){
    this.professorSelecionado = new Professor();
    this.professorForm.patchValue(this.professorSelecionado);
  }

  voltar(){
    this.professorSelecionado = null;
  }
}