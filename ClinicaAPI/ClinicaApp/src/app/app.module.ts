
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { MatDialogModule } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './sharepage/navbar/navbar.component';
import { HomeComponent } from './pages/home/home.component';
import { AgendaComponent } from './pages/agenda/agenda.component';
import { CadprofComponent } from './pages/cadprof/cadprof.component';
import { FichaclienteComponent } from './pages/fichacliente/fichacliente.component';
import { ProtadmComponent } from './pages/protadm/protadm.component';
import { ProtclinComponent } from './pages/protclin/protclin.component';
import { MatTableModule } from '@angular/material/table';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CustomDateComponent } from '../app/sharepage/custom-date/custom-date.component';
import { registerLocaleData } from '@angular/common';
import localePt from '@angular/common/locales/pt';
import { ConverterDiaSemanaParaPortuguesPipe } from '../app/sharepage/custom-date/converter-dia-semana-para-portugues.pipe'; // Ajuste o caminho
import { ReactiveFormsModule } from '@angular/forms'; // Importe ReactiveFormsModule
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatInputModule } from '@angular/material/input';
import { FormsModule } from '@angular/forms';
import { ControleFinaceiroComponent } from './pages/controle-finaceiro/controle-finaceiro.component';
import { MeuBotaoComponent } from './sharepage/meu-botao/meu-botao.component';
import { ContainerComponent } from './sharepage/container/container.component';
import { InputComponent } from './sharepage/input/input.component';
import { FormularioComponent } from './sharepage/formulario/formulario.component';
import { TextboxComponent } from './sharepage/textbox/textbox.component';
import { LoginComponent } from './pages/login/login.component';
import { CelAgendaComponent } from './sharepage/cel-agenda/cel-agenda.component';
import { Grid01Component } from './sharepage/grid01/grid01.component';
import { FormClienteComponent } from './sharepage/form-cliente/form-cliente.component';
import { FormsComponent } from './sharepage/forms/forms.component';
import { ContainerFormsComponent } from './sharepage/container-forms/container-forms.component';
import { FormsEquiComponent } from './sharepage/forms-equi/forms-equi.component';
import { BlocoNotasComponent } from './sharepage/bloco-notas/bloco-notas.component';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { JwtModule } from '@auth0/angular-jwt';
import { RequestInterceptor } from '../app/pages/login/request.interceptor';
import { ClienteService } from './services/cliente/cliente.service';
import { UserService } from './services/user.service';
import { DefinitionsComponent } from './pages/definitions/definitions.component';
import { PerfilTabComponent } from './sharepage/perfil-tab/perfil-tab.component';
registerLocaleData(localePt);

export function tokenGetter() {
  return localStorage.getItem('access_token');
}


@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    HomeComponent,
    AgendaComponent,
    CadprofComponent,
    FichaclienteComponent,
    ProtadmComponent,
    ProtclinComponent,
    CustomDateComponent,
    ConverterDiaSemanaParaPortuguesPipe,
    ControleFinaceiroComponent,
    ContainerComponent,
    InputComponent,
    FormularioComponent,
    TextboxComponent,
    LoginComponent,
    CelAgendaComponent,
    MeuBotaoComponent,
    Grid01Component,
    FormClienteComponent,
    FormsComponent,
    ContainerFormsComponent,
    FormsEquiComponent,
    BlocoNotasComponent,
    DefinitionsComponent,
    PerfilTabComponent,

  ],


imports: [
  FormsModule,
  HttpClientModule,
  BrowserModule,
  AppRoutingModule,
  ReactiveFormsModule,
  FormsModule,
  BrowserAnimationsModule,
  MatTableModule,
  MatDatepickerModule,
  MatNativeDateModule,
  MatInputModule,
  ReactiveFormsModule,
  MatDialogModule,
  MatButtonModule,
  FormsModule,
  HttpClientModule,
  // JwtModule.forRoot({
  //   config: {
  //     tokenGetter: tokenGetter,
  //     allowedDomains: ['https://localhost:7298/api'],
  //     disallowedRoutes: [],
  //   },
  // }),
 ],
  providers: [BrowserModule, FormsModule,
      {
          provide: HTTP_INTERCEPTORS,
          useClass: RequestInterceptor,
          multi: true
      },
    ],
  bootstrap: [AppComponent]
})
export class AppModule { }
