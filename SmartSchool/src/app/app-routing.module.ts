import { AuthGuard } from './shared/guard/auth.guard';
import { HomeLayoutComponent } from './layout/home-layout/home-layout.component';
import { LoginComponent } from './pages/authentication/login/login.component';
import { LoginLayoutComponent } from './layout/login-layout/login-layout.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AlunosComponent } from './alunos/alunos.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { PerfilComponent } from './perfil/perfil.component';
import { ProfessoresComponent } from './professores/professores.component';
import { JwtModule } from '@auth0/angular-jwt';
import { environment } from 'src/environments/environment';

const routes: Routes = [
  {
    path: '', component: HomeLayoutComponent,
    children: [
      { path: '', redirectTo: 'dashboard', pathMatch: 'full'},
      { path:'dashboard', component: DashboardComponent},
      { path:'alunos', component: AlunosComponent},
      { path:'perfil', component: PerfilComponent},
      { path:'professores', component: ProfessoresComponent},
    ],
    canActivate: [AuthGuard]
  },

  {
    path: '', component: LoginLayoutComponent,
    children: [
      { path: '', redirectTo: 'login', pathMatch: 'full' },
      { path: 'login', component: LoginComponent }
    ]
  }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes),

    JwtModule.forRoot({
      config: {
        tokenGetter: () => localStorage.getItem('token'),
        allowedDomains: [
          environment.UrlPrincipal.replace(/(^\w+:|^)\/\//, '')
        ],
        disallowedRoutes: [
          `${environment.UrlPrincipal}/Account`
        ]
      }
    })
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
