import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/map';

declare var Stimulsoft: any;

@Injectable()
export class ConfigService {
    private databaseUrl = 'http://localhost:52961/api/customers';

    constructor(private http: HttpClient) { }

    async getCustomers() {
        let response = await this.http.get(this.databaseUrl);
        return response;
    }

    loadDesigner(input) {
        console.log('Loading Designer view');

        console.log('input');
        console.log(input);

        var report = new Stimulsoft.Report.StiReport();
        var dataSet = new Stimulsoft.System.Data.DataSet();

        dataSet.readJsonFile("reports/Demo.json");
        report.regData("Demo", "Demo", dataSet);

        report.dictionary.synchronize();
        var designer = new Stimulsoft.Designer.StiDesigner();

        designer.report = report;
    }
}
