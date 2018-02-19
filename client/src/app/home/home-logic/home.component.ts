import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'home-comp',
    templateUrl: 'home.component.html',
    styleUrls: ['home.component.scss']
})
export class HomeComponent implements OnInit {
    public title = 'Home';

    constructor() {}

    ngOnInit() {
        console.log(`Home component lazy loaded`);
    }
}