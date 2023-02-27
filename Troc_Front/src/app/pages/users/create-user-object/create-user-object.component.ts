import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Guid } from 'guid-typescript';
import { Object } from 'src/models/object';
import { UserService } from 'src/services/user.service';

@Component({
  selector: 'app-create-user-object',
  templateUrl: './create-user-object.component.html',
  styleUrls: ['./create-user-object.component.scss'],
})
export class CreateUserObjectComponent implements OnInit {
  constructor(
    private userService: UserService,
    private router: Router,
    private activatedRoute: ActivatedRoute
  ) {}

  ownerId: Guid = this.activatedRoute.snapshot.params['id'];
  errMsg?: string;
  editValue: {
    label: string;
    state: number;
    desc: string;
    value: number;
    uDate: string;
  } = {
    label: '',
    state: 0,
    desc: '',
    value: 0,
    uDate: new Date().toJSON().substring(0, 10),
  };

  ngOnInit(): void {
    throw new Error('Method not implemented.');
  }

  async createObject() {
    try {
      let ob = new Object();
      ob.label = this.editValue.label;
      ob.objectState = this.editValue.state;
      ob.description = this.editValue.desc;
      ob.value = this.editValue.value;
      ob.uploadDate = new Date(this.editValue.uDate);
      try {
        let id = await this.userService.addObjectAsync(ob, this.ownerId);
        this.router.navigateByUrl(`/details-users/${this.ownerId}`);
      } catch (error) {
        this.errMsg = "Impossible d'enregistrer l'objet pour le moment";
      }
    } catch (error) {
      this.errMsg = "Ajout d'objet non permis";
    }
  }
}
