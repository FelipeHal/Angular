import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AccountService } from 'src/app/shared/services/account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  public title = 'Bem vindo! Faça seu login para continuar.';
  public loginForm: FormGroup;

  public status: 'success' | 'failure' | '' = '';
  public loginError: string;

  constructor(private fb: FormBuilder, private accountService: AccountService) { }

  ngOnInit(): void {
    this.loginForm = this.fb.group({
      username:['', Validators.required],
      password:['', Validators.required],
    })
  }

  async loginSubmit() {
    this.loginForm.disable();

    const res = await this.accountService.authenticate(this.loginForm.value);

    switch (res) {
      case 'ok':
        this.status = 'success';
        break;

      default:
        this.status = 'failure';

        if (res === 'invalid') {
          this.loginError = 'Invalid username or password!';
        }
        else {
          this.loginError = 'Some error occurred in server.';
        }

        this.loginForm.enable();

        break;
    }
  }
}
