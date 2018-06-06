import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { BalanceAccount } from "../shared/index";

@Injectable({
  providedIn: "root"
})
export class AccountService {
  constructor(private http: HttpClient) {}
  vouchers = null;

  getVouchers(): Promise<any> {
    return this.http.get("/assets/accounts.json").toPromise();
  }

  getVoucher(id: number): Promise<any> {
    return new Promise<BalanceAccount>((resolve, reject) => {
      this.http
        .get("/assets/vouchers.json")
        .toPromise()
        .then((data: BalanceAccount[]) => {
          var v = data.filter(item => {
            return item.ID == id;
          });
          resolve(v[0]);
        })
        .catch(err => reject(err));
    });
  }
}
