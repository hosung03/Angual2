import { Component, Inject } from '@angular/core';
import { Http, Headers } from '@angular/http';

@Component({
    selector: "member-management",
    templateUrl: "./membermgmt.component.html"
})

export class MemberManagementComponent {
    private _http: Http;
    private _baseUrl: string;
    public members: any[] = [];
    API_GET_URL = "api/MemberMgmt/GetList";
    API_PUT_URL = "api/MemberMgmt/AddMember";

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        this._http = http;
        this._baseUrl = baseUrl;
        http.get(baseUrl + this.API_GET_URL).subscribe(result => {
            this.members = result.json();
        }, error => console.error(error));
    }

    doSave(formValue:any) {
        console.log(formValue);
        var hedears = new Headers();
        hedears.append("Content-Type", "application/json");
        this._http.post(
            this._baseUrl + this.API_PUT_URL,
            JSON.stringify(formValue),
            { headers: hedears }
        ).subscribe(result => {
            //this.members.push(result.json());
            this.members = result.json();
            console.log(this.members);
        }, error => console.error(error));
    }
}