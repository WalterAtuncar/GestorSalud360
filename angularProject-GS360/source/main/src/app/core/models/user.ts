import { Role } from './role';

export class User {
  id!: number;
  img!: string;
  username!: string;
  password!: string;
  personId! : string | null;
  professionId!: number | null;
  roleId!: number | null;
  firstName!: string;
  lastName!: string;
  role!: Role;
  token!: string;
}
