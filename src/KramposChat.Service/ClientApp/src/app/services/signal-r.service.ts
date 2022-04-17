import {Injectable} from '@angular/core';
import {HubConnection, HubConnectionBuilder} from "@microsoft/signalr";
import {User} from "../Models/User";
import {Chat} from "../Models/Chat";


@Injectable({
  providedIn: 'root'
})
export class SignalRService {
  public data: { userName: string; message: string; } | undefined


  private hubConnection: HubConnection | undefined

  public StartSignalRConnection() {
    this.hubConnection = new HubConnectionBuilder().withUrl("https://localhost:7076/chathub").build();
    this.hubConnection!.on("messageReceived", (username: string, message: string) => {
      console.log(username, message)
    })
    this.hubConnection!
      .start()
      .then(() => console.log('Connection started'))
      .catch(err => console.log('Error while starting connection: ' + err))
  }


  public getConnection(): HubConnection | undefined {
    return this.hubConnection
  }

  public CreateChat(chatName: string) {
    this.hubConnection!.invoke("createChat", chatName).then(() => console.log("Чат создан "))
  }

  public SendMessage(user: User, message: string, chat: Chat) {
    this.hubConnection!.invoke('sendMessage', user, message, chat).then(() => console.log("Сообщение создано"))
  }

  public AddUser(userName: string, chat: Chat) {
    this.hubConnection!.invoke('addUser', userName, chat).then(() => console.log("ПОльзователь создан"))
  }
}
