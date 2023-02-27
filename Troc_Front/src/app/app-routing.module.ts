import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { HomeComponent } from './pages/home/home.component';
import { DetailsObjectComponent } from './pages/objects/details-object/details-object/details-object.component';
import { ListObjectsComponent } from './pages/objects/list-objects/list-objects.component';
import { DetailsUsersComponent } from './pages/users/details-users/details-users.component';
import { ListUsersComponent } from './pages/users/list-users/list-users.component';
import { CreateUserObjectComponent } from './pages/users/create-user-object/create-user-object.component';

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'list-objects', component: ListObjectsComponent },
  { path: 'details-object/:id', component: DetailsObjectComponent },
  { path: 'list-users', component: ListUsersComponent },
  { path: 'details-user/:id', component: DetailsUsersComponent },
  { path: 'details-user/:id/add', component: CreateUserObjectComponent },
  { path: '**', redirectTo: 'home' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: true })],
  exports: [RouterModule],
})
export class AppRoutingModule {}
