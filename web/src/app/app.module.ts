import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { HttpClientModule } from "@angular/common/http";
import { ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from "./app.component";
import { RouterModule } from "@angular/router";
import { HomeComponent } from "./home/home.component";
import { AddStudentComponent } from "./add-student/add-student.component";
import { NavMenuComponent } from "./nav-menu/nav-menu.component";

function getBaseUrl() {
  return "http://localhost:5000/";
}

@NgModule({
  declarations: [AppComponent, HomeComponent, AddStudentComponent, NavMenuComponent],
  imports: [
    BrowserModule,
    RouterModule.forRoot([
      { path: "", component: HomeComponent, pathMatch: "full" },
      { path: "home", component: HomeComponent, pathMatch: "full" },
      { path: "add-student", component: AddStudentComponent, pathMatch: "full" },
    ]),
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [{ provide: "BASE_URL", useFactory: getBaseUrl, deps: [] }],
  bootstrap: [AppComponent],
})
export class AppModule {}
