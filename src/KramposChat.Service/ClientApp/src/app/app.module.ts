import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {HttpClientModule} from '@angular/common/http';
import {RouterModule} from '@angular/router';
import {NgChartsModule} from 'ng2-charts';

import {AppComponent} from './app.component';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {ChatComponent} from './chat/chat.component';
import {SignalRService} from "./services/signal-r.service";


@NgModule({
  declarations: [
    AppComponent,
    ChatComponent,

  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    NgChartsModule,
    RouterModule.forRoot([
      {path: '', component: ChatComponent, pathMatch: 'full'},
    ]),
    BrowserAnimationsModule,
    ReactiveFormsModule
  ],
  providers: [
    SignalRService
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
}
