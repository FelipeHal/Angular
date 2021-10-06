import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  public title = 'Bem vindo! Faça seu login para continuar.';
  public loginForm: FormGroup;

  constructor(private fb: FormBuilder) { }

  ngOnInit(): void {
    this.loginForm = this.fb.group({
      username:['', Validators.required],
      password:['', Validators.required],
    })
  }

  loginSubmit(){
    console.log(this.loginForm.value);
  }
}
