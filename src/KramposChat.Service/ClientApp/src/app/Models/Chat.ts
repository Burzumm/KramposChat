import {User} from "./User";

export class Chat {
  constructor(public id: string, public name: string, public users: Array<User>, public messages: { user: User, message: string }) {
  }

}
