import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './pages/home/home.component';
import { ListObjectsComponent } from './pages/objects/list-objects/list-objects.component';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';
import { HttpClientModule } from '@angular/common/http';
import { environment } from 'src/environments/environements';
import { DetailsObjectComponent } from './pages/objects/details-object/details-object/details-object.component';
import { ObjectService } from 'src/services/object.service';
import { ObjectHttpService } from 'src/services/object-http.service';
import { ListSearchResultComponent } from './controls/list-search-result/list-search-result/list-search-result.component';
import { ListUsersComponent } from './pages/users/list-users/list-users.component';
import { UserService } from 'src/services/user.service';
import { UserHttpService } from 'src/services/user-http.service';
import { DetailsUsersComponent } from './pages/users/details-users/details-users.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CreateUserObjectComponent } from './pages/users/create-user-object/create-user-object.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ListObjectsComponent,
    NavBarComponent,
    DetailsObjectComponent,
    ListSearchResultComponent,
    ListUsersComponent,
    DetailsUsersComponent,
    CreateUserObjectComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  providers: [
    environment.providers,
    { provide: ObjectService, useClass: ObjectHttpService },
    { provide: UserService, useClass: UserHttpService },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
