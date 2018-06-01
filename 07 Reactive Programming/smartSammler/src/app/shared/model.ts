export enum markerType {
  Beeren = 1,
  Holler = 2,
  Schwammerl = 3
}

export class Marker {
  constructor() {
    // this.coords = { lat: 0, lng: 0 };
  }

  id: number;
  imgURL: string;
  lable: string;
  type: number;
  lat: number;
  lng: number;
  hasCoords?: boolean;
  // coords: Coordinates,
  remark: string;
  picture?: any;

  static getMarkerLabel(type: number): string {
    return markerType[type];
  }
}

export interface Direction {
  origin: Coordinates;
  destination: Coordinates;
}

export interface Coordinates {
  lat: number;
  lng: number;
}
