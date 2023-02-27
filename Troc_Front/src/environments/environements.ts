import { ObjectHttpService } from 'src/services/object-http.service';
import { ObjectService } from 'src/services/object.service';
import { UserHttpService } from 'src/services/user-http.service';
import { UserService } from 'src/services/user.service';

export const environment = {
  raisonSociale: 'LebonTroc',
  serviceUrl: 'http://localhost:5160',
  providers: [
    { provide: ObjectService, useClass: ObjectHttpService },
    { provide: UserService, useClass: UserHttpService },
  ],
};
