import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { CadprofComponent } from './pages/cadprof/cadprof.component';
import { FichaclienteComponent } from './pages/fichacliente/fichacliente.component';
import { AgendaComponent } from './pages/agenda/agenda.component';
import { ProtadmComponent } from './pages/protadm/protadm.component';
import { ProtclinComponent } from './pages/protclin/protclin.component';
import { ControleFinaceiroComponent } from './pages/controle-finaceiro/controle-finaceiro.component';
import { LoginComponent } from './pages/login/login.component';
import { DefinitionsComponent } from './pages/definitions/definitions.component';

const routes: Routes = [
  {path: 'inicio', component: HomeComponent, data: { title: 'PAINEL DE CONTROLE' }},
  {path: 'cadprof', component: CadprofComponent, data: { title: 'CADASTRO DA EQUIPE' }},
  {path: 'fichacliente', component: FichaclienteComponent, data: { title: 'FICHAS DE CLIENTES' }},
  {path: 'agenda', component: AgendaComponent, data: { title: 'AGENDA' }},
  {path: 'protadm', component: ProtadmComponent, data: { title: 'PRONTUÁRIO ADMINISTRATIVO' }},
  {path: 'protclin', component: ProtclinComponent, data: { title: 'PRONTUÁRIO CLÍNICO' }},
  {path: 'controleFinaceiro', component: ControleFinaceiroComponent, data: { title: 'CONTROLE FINANCEIRO' }},
  {path: 'login', component: LoginComponent, data: { title: 'LOGIN' }},
  { path: 'login', component: LoginComponent},
  { path: 'definitions', component: DefinitionsComponent},
  { path: '', redirectTo: 'login', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
