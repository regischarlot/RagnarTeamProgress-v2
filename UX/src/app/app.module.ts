import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { MaterialModule } from './material.module';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RunnersComponent } from './components/runners/runners.component';
import { ExchangesComponent } from './components/exchanges/exchanges.component';
import { ProgressComponent } from './components/progress/progress.component';
import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';
import { RagnarService } from './service/RagnarService.service';
import { HttpClient, HttpParams, HttpClientModule } from '@angular/common/http';
import { ApiService } from './service/api.service';
import { DifficultyPipe } from './pipes/difficulty.pipe';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SideNavigationWidgetComponent } from './components/side-navigation-widget/side-navigation-widget.component';
import { AgmCoreModule } from '@agm/core';
import { FlexLayoutModule } from '@angular/flex-layout';


@NgModule({
  declarations: [
    AppComponent,
    RunnersComponent,
    ExchangesComponent,
    ProgressComponent,
    PageNotFoundComponent,
    DifficultyPipe,
    SideNavigationWidgetComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule, 
    MaterialModule, 
    BrowserAnimationsModule, 
    HttpClientModule, 
    ReactiveFormsModule,
    MaterialModule,
    AgmCoreModule.forRoot({
      apiKey: 'AIzaSyAzH4SXmUXIy51Du7UnlcNdqYIFYTjWRJY'
    }),
    FlexLayoutModule
  ],
  providers: [RagnarService, ApiService],
  bootstrap: [AppComponent]
})
export class AppModule { }
