import { Component } from "@angular/core";
import { Person } from "./shared/model";

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
  styleUrls: ["./app.component.css"]
})
export class AppComponent {
  title = "app";

  constructor() {
    let p: Person;
  }
}
