import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { MediaChange, ObservableMedia } from "@angular/flex-layout";
import { Router } from "@angular/router";
import * as signalR from "@aspnet/signalr";
import { LocalStorageService } from "ngx-webstorage";
import { BehaviorSubject, Observable, Subscription } from "rxjs";
import { map } from "rxjs/operators";
import { environment } from "../../environments/environment";
import { Marker } from "../shared/model";
import { ConnectionService } from "../shared/connection/connection.service";
import { KEY_MARKERS } from "../shared/consts";

@Injectable()
export class MarkerService {
  constructor(
    private httpClient: HttpClient,
    private router: Router,
    private obsMedia: ObservableMedia,
    private ls: LocalStorageService,
    private cs: ConnectionService
  ) {
    this.subscribeScreen();
    this.checkOnlineStatus();
    this.initMarkers();
  }

  // Markers
  private arrMarkers: Marker[] = [];
  private markers: BehaviorSubject<Marker[]> = new BehaviorSubject(
    this.arrMarkers
  );

  // Connection status
  private connection: signalR.HubConnection;
  public online: boolean;

  private checkOnlineStatus() {
    this.cs.isOnline.subscribe(data => (this.online = data));
  }

  //Responsive Screen Service - in larger projects outsourced to it's own service

  private watcher: Subscription;
  ScreenGtSmall: boolean;
  private currentMQ: string;

  private subscribeScreen() {
    this.watcher = this.obsMedia.subscribe((change: MediaChange) => {
      // console.log("Current Device Screen: " + change.mqAlias);
      this.currentMQ = change.mqAlias;
      switch (this.currentMQ) {
        case "xs":
          this.ScreenGtSmall = false;
          break;
        case "sm":
          this.ScreenGtSmall = false;
          break;
        default:
          this.ScreenGtSmall = true;
          break;
      }
    });
  }

  //Init

  private initMarkers() {
    if (this.online) {
      this.initSocketConnection();
    } else {
      this.initMarkersLocally();
    }
  }

  private initSocketConnection() {
    this.connection = new signalR.HubConnectionBuilder()
      .withUrl(environment.markerHub)
      .build();

    this.connection.on("broadcastMarkers", (data: Marker[]) => {
      this.arrMarkers = data;
      this.persistMarkerAndBroadcast(this.arrMarkers);
    });

    this.connection.start().then(() => this.initMarkersRemote());

    // Sample on how to communication with signalR Hub
    // connection.start().then(() => connection.invoke("broadcastMarkers", this.arrMarkers));
  }

  private initMarkersRemote() {
    this.httpClient
      .get<Marker[]>(`${environment.apiURL}markers/init`)
      .subscribe(data => {
        console.log("broadcast kicked on");
      });
  }

  private initMarkersLocally() {
    if (this.localStorageIsInitialized() == false) {
      this.arrMarkers = [
        {
          id: 1000,
          imgURL: "/assets/images/beeren.png",
          lable: "Waldviertel",
          type: 1,
          lat: 48.5839237,
          lng: 15.4276355,
          remark:
            "Als Beere gilt in der Botanik eine aus einem einzigen Fruchtknoten hervorgegangene Schließfrucht, bei der die komplette Fruchtwand (Perikarp) auch noch bei der Reife saftig oder mindestens fleischig ist",
          picture: null
        },
        {
          id: 1001,
          imgURL: "/assets/images/schwammerl.png",
          lable: "Steiermark",
          type: 3,
          lat: 47.5308866,
          lng: 15.9476211,
          remark:
            "Schwammerl ist die Bezeichnung für Großpilze in Österreich -  Gemeint sind damit nicht alle Pilze im biologischen Sinn, sondern die Fruchtkörper essbarer Pilzarten",
          picture: null
        },
        {
          id: 1002,
          imgURL: "/assets/images/holler.png",
          lable: "Neuwaldegg",
          type: 2,
          lat: 48.234201,
          lng: 16.277753,
          remark:
            "Holunder-Arten sind meist verholzende Pflanzen und wachsen als Halbsträucher, Sträucher oder kleine Bäume",
          picture: null
        }
      ];
      this.saveToLocalStorage(this.arrMarkers);
      console.log("Initialized markers");
    } else {
      this.arrMarkers = this.getFromLocalStorage();
      console.log("Markers taken from lokal storage");
    }
    this.markers.next(this.arrMarkers);
  }

  // Form Methods - Routing Helper

  showMarker(id: number): void {
    if (this.ScreenGtSmall) {
      this.router.navigate(["", { outlets: { sidebar: ["showmarker", id] } }]);
    } else {
      this.router.navigate(["", { outlets: { sidebar: null } }]);
      this.router.navigateByUrl(`/markers/${id}`);
    }
  }

  // Public Data methods

  persistMarkerAndBroadcast(markers: Marker[]) {
    this.saveToLocalStorage(markers);
    this.markers.next(markers);
  }

  getMarkers(): Observable<Marker[]> {
    return this.markers;
  }

  getMarker(id: number): Observable<Marker> {
    return this.markers.pipe(map(m => m.find((m: Marker) => m.id == id)));
  }

  saveMarker(m: Marker): void {
    if (m.id == undefined) {
      this.addToMarkerArray(m);
    } else {
      this.updateMarkerArray(m);
    }
    this.saveToLocalStorage(this.arrMarkers);
    this.saveMarkerRemote(m);
  }

  removeMarker(m: Marker): void {
    this.removeFromMarkerArray(m);
    this.saveToLocalStorage(this.arrMarkers);
    this.deleteMarkerRemote(m);
  }

  //Local Data Manipulation

  private updateMarkerArray(m: Marker): void {
    let old = this.arrMarkers.find(m => m.id == m.id);
    var idx = this.arrMarkers.indexOf(old);
    this.arrMarkers.splice(idx, 1, m);
  }

  private addToMarkerArray(m: Marker): void {
    this.arrMarkers.push(m);
  }

  private removeFromMarkerArray(m: Marker): void {
    var idx = this.arrMarkers.indexOf(m);
    if (idx !== -1) {
      this.arrMarkers.splice(idx, 1);
    }
  }

  //Local Storage

  private localStorageIsInitialized() {
    return this.ls.retrieve(KEY_MARKERS) != undefined;
  }

  private saveToLocalStorage(markers: Marker[]) {
    this.ls.store(KEY_MARKERS, markers);
  }

  private getFromLocalStorage(): Marker[] {
    return this.ls.retrieve(KEY_MARKERS);
  }

  //Remote Data Operations

  private saveMarkerRemote(m: Marker): void {
    this.httpClient
      .post<Marker>(`${environment.apiURL}markers`, m)
      .subscribe(result => console.log("save operation:", result));
  }

  private deleteMarkerRemote(m: Marker): void {
    this.httpClient
      .delete(`${environment.apiURL}markers/${m.id}`)
      .subscribe(result => console.log("delete operation:", result));
  }
}
