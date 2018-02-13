import { Component, OnInit } from '@angular/core';
import { ViewEncapsulation } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ConfigService } from './config/config.service';

@Component({
    selector: 'app-root',
    template: `<div>
                    <h2>Stimulsoft Reports Designer - Angular 4 DEMO</h2>
                    <div id="designer"></div>
              </div>`
})
export class AppComponent implements OnInit {
    test: any;
    simul: any;

    constructor(private _configService: ConfigService) {

    }

    async ngOnInit() {
        this.test = await this._configService.getCustomers();

        console.log(`this.test`);
        console.log(this.test);
        this.simul = await this._configService.loadDesigner(this.test);
    }
}