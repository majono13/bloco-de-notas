import { Notes } from './notes.model';

export interface User {
  id: number;
  firstName: string;
  lastName: string;
  email: string;
  notes: Notes[];
  token?: string;
}
