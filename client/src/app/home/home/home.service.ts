import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { IPaginiation } from "src/app/shared/models/pagination";
import { environment } from "src/environments/environment";


@Injectable({
    providedIn: 'root'
})

export class HomeServices {
    baseUrl = 'https://localhost:5001/api/'

    constructor(private http:HttpClient){}

    getProducts(){
        return this.http.get<IPaginiation>(this.baseUrl + 'products');
    }
}