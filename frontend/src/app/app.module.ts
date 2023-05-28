import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ReactiveFormsModule } from '@angular/forms';

import { NbThemeModule, NbLayoutModule, NbSpinnerModule, NbCardModule, NbAlertModule, NbUserModule, NbSidebarModule, NbMenuModule, NbIconModule, NbDialogModule, NbDatepickerModule } from '@nebular/theme';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoaderComponent } from './shared/loader/loader.component';
import { AlertsComponent } from './shared/alerts/alerts.component';
import { JwtModule } from '@auth0/angular-jwt';
import { MenuComponent } from './shared/menu/menu.component';
import { NbEvaIconsModule } from '@nebular/eva-icons';
import { NbMomentDateModule } from '@nebular/moment';
import { AuthInterceptor } from './shared/auth.interceptor';

@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    LoaderComponent,
    AlertsComponent
  ],
  imports: [
    CommonModule,
    BrowserModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    HttpClientModule,
    AppRoutingModule,

    JwtModule.forRoot({
      config: {
        tokenGetter: () => {
          return localStorage.getItem("token");
        },
        authScheme: ""
      }
    }),

    NbCardModule,
    NbSpinnerModule,
    NbAlertModule,
    NbUserModule,
    NbEvaIconsModule,
    NbIconModule,

    NbThemeModule.forRoot({ name: 'eventplanner' }),
    NbDialogModule.forRoot(),
    NbLayoutModule,
    NbSidebarModule.forRoot(),
    NbMenuModule.forRoot(),
    NbDatepickerModule.forRoot(),
    NbMomentDateModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
