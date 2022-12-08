import { Notes } from './notes.model';

export interface User {
  Id: number;
  FirstName: string;
  LastName: string;
  Email: string;
  Notes: Notes[];
  Token?: string;
}
