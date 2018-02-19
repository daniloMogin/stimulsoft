import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/map';

import { saveAs } from 'file-saver/FileSaver';

declare let Stimulsoft: any;

@Injectable()
export class ConfigService {
    private databaseUrl = 'http://localhost:52961/api/customers';
    options: any;
    designer: any;

    constructor(private http: HttpClient) { }

    async getCustomers() {
        let response = await this.http.get(this.databaseUrl).toPromise();
        return response;
    }

    loadDesigner(input) {

        console.log('input');
        console.log(input);

        console.log('Loading Designer view');
        this.options = new Stimulsoft.Designer.StiDesignerOptions();
        this.options.appearance.fullScreenMode = false;
        let report = new Stimulsoft.Report.StiReport();
        let dataSet = new Stimulsoft.System.Data.DataSet();

        console.log('Create the report designer with specified options');
        this.designer = new Stimulsoft.Designer.StiDesigner(this.options, 'StiDesigner', false);

        console.log('Adding json file as data source');
        let dataSource = { ['Customers']: input };
        // dataSet.readJsonFile("reports/Demo.json");
        dataSet.readJson(dataSource);
        report.regData("GeutebrueckDb", "Demo", dataSet);

        console.log('Synchronising dictonary');
        report.dictionary.synchronize();        

        console.log('Creating designer');
        this.designer.report = report;

        console.log('Rendering the designer to selected element');
        this.designer.renderHtml('designer');

        console.log('Loading completed successfully!');
    }
}
