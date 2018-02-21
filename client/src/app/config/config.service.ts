import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/map';

import { saveAs } from 'file-saver/FileSaver';

declare let Stimulsoft: any;

@Injectable()
export class ConfigService {
    private databaseUrl = 'http://localhost:52961/api/customers';
    private saveReportUrl = 'http://localhost:52961/api/reports';
    options: any;
    designer: any;

    constructor(private http: HttpClient) { }

    async getCustomers() {
        let response = await this.http.get(this.databaseUrl).toPromise();
        return response;
    }

    loadDesigner(input) {
        console.log('Loading Designer view');
        this.options = new Stimulsoft.Designer.StiDesignerOptions();
        // this.options.appearance.fullScreenMode = false;
        // this.options.defaultUnit = Stimulsoft.Report.StiReportUnitType.Inches;
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

        // Assign the onSaveReport event function
        this.designer.onSaveReport = e => {
            var data = e.report.saveToJsonString();
            const headers = new HttpHeaders().set('Content-Type', 'application/json; charset=utf-8');
            this.http.post(this.saveReportUrl, { 
                guid: JSON.parse(data).ReportGuid,
                name: JSON.parse(data).ReportFile,
                data: JSON.parse(data)
            }, { headers: headers })
                .subscribe(
                    res => {
                        console.log(res);
                    },
                    err => {
                        console.log("Error occured");
                        console.log(err);
                    }
                );
            console.log("Save to JSON string complete.")
        }

        // Assign the onSaveAsReport event function
        this.designer.onSaveAsReport = e => {
            var data = e.report.saveToJsonString();
            const headers = new HttpHeaders().set('Content-Type', 'application/json; charset=utf-8');
            this.http.post(this.saveReportUrl, { 
                guid: JSON.parse(data).ReportGuid,
                name: JSON.parse(data).ReportFile,
                data: JSON.parse(data)
            }, { headers: headers })
                .subscribe(
                    res => {
                        console.log(res);
                    },
                    err => {
                        console.log("Error occured");
                        console.log(err);
                    }
                );
            console.log("SaveAs to JSON string complete.")
        }

        // this.designer.onOpenReport = e => {
        //     console.log('USAO SAM U OPEN!!!!');
        //     console.log(e);
        //     var report = new Stimulsoft.Report.StiReport();
        //     var obj = JSON.parse(e);
        //     report.load(obj.report);
        //     this.designer.report = report;
        // }
    }
}
