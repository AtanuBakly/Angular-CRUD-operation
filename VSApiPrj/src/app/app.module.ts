import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AddEmployeeComponent } from './add-employee/add-employee.component';
import { AllEmployeeComponent } from './all-employee/all-employee.component';
import { ByIdEmployeeComponent } from './by-id-employee/by-id-employee.component';
import { DeleteEmployeeComponent } from './delete-employee/delete-employee.component';
import { EditEmployeeComponent } from './edit-employee/edit-employee.component';

import {Routes,RouterModule} from '@angular/router';
import {HttpClientModule} from '@angular/common/http' // for database connection
import {FormsModule} from '@angular/forms'; // for <form> tag for Add employee page

import {BsDatepickerModule} from 'ngx-bootstrap/datepicker';

const appRoutes:Routes=[
  {path: "",component:AllEmployeeComponent},
  {path: "Add-Employee",component:AddEmployeeComponent},
  {path: "Edit-Employee",component:EditEmployeeComponent},
  {path: "All-Employee",component:AllEmployeeComponent},
  {path: "ById-Employee",component:ByIdEmployeeComponent},
  {path: "Delete-Employee",component:DeleteEmployeeComponent}
]

@NgModule({
  declarations: [
    AppComponent,
    AddEmployeeComponent,
    AllEmployeeComponent,
    ByIdEmployeeComponent,
    DeleteEmployeeComponent,
    EditEmployeeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule.forRoot(appRoutes),
    HttpClientModule,
    FormsModule,
    BsDatepickerModule.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
