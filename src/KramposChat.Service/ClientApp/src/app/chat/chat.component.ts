import {Component, OnInit} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {SignalRService} from "../services/signal-r.service";
import {FormControl} from "@angular/forms";
import {Chat} from "../Models/Chat";
import {HubConnection} from "@microsoft/signalr";
import {User} from "../Models/User";

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.css']
})
export class ChatComponent implements OnInit {

  habConnection: HubConnection | undefined
  chat: Chat | undefined;
  userName: string = "";
  message: string = "";
  user: User | undefined
  userNameFormControl = new FormControl("")
  messageNameFormControl = new FormControl("")
  chatFormControl = new FormControl("")

  constructor(public signalRService: SignalRService, private http: HttpClient) {
  }

  ngOnInit(): void {
    this.signalRService.StartSignalRConnection()
    this.habConnection = this.signalRService.getConnection()
    this.getChat()
    this.getMessage()
  }

  sendMessageCreateUser(userName: string, message: string) {
    this.signalRService.AddUser(userName, this.chat!)
    this.habConnection?.on("addUser", (user: any) => {
      this.user = new User(user.id, user.name)
      console.log(this.user)
    })
    this.signalRService.SendMessage(this.user!, this.message, this.chat!)
  }

  createChat(chatName: string) {
    this.signalRService.CreateChat(chatName)
  }

  private getChat() {
    this.habConnection!.on("createChat", (chat: any) => {
      this.chat = new Chat(chat.id, chat.name, chat.users, chat.messages)
    })
  }

  private getMessage() {
    this.habConnection!.on("sendMessage", (chat: any) => {
      console.log(chat)
      this.chat!.messages.user = chat.messages.message
      this.chat!.messages.message = chat.messages.message
    })


  }


  private getUser() {
    this.habConnection?.on("addUser", (user: any) => {
      this.user = new User(user.id, user.name)
    })
  }
}
