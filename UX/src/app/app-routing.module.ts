import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';
import { ProgressComponent } from './components/progress/progress.component';
import { RunnersComponent } from './components/runners/runners.component';
import { ExchangesComponent } from './components/exchanges/exchanges.component';
import { LegComponent } from './components/leg/leg.component';

const routes: Routes = [
  { path: '', component: ProgressComponent },
  { path: 'progress', component: ProgressComponent },
  { path: 'runners', component: RunnersComponent },
  { path: 'exchanges', component: ExchangesComponent },
  { path: 'leg', component: LegComponent },
  { path: '**', component: PageNotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
