import { Component, OnInit } from "@angular/core";
import { BalanceAccount } from "../shared";
import { AccountService } from "./account.service";

@Component({
  selector: "app-accounts",
  templateUrl: "./accounts.component.html",
  styleUrls: ["./accounts.component.css"]
})
export class AccountsComponent implements OnInit {

  account: BalanceAccount;
  

  constructor(private vs: AccountServicentService, private route: ActivatedRoute) {}

  ngOnInit() {}

  selectDetail(detail) {
    this.currentDetail = detail;
  }
}
