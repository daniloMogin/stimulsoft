import { Component } from '@angular/core';
import { ViewEncapsulation } from '@angular/core';
import { HttpClient } from '@angular/common/http';

declare var Stimulsoft: any;

@Component({
    selector: 'app-root',
    template: `<div>
                    <h2>Stimulsoft Reports Designer - Angular 4 DEMO</h2>
                    <div id="designer"></div>
              </div>`
})
export class AppComponent {
    options: any;
    designer: any;
    data: string;

    constructor(private http: HttpClient) {
    }

    ngOnInit() {
        console.log('Loading Designer view');

        console.log('Set full screen mode for the designer');
        this.options = new Stimulsoft.Designer.StiDesignerOptions();
        this.options.appearance.fullScreenMode = false;

        console.log('Create the report designer with specified options');
        this.designer = new Stimulsoft.Designer.StiDesigner(this.options, 'StiDesigner', false);

        console.log('Edit report template in the designer');
        this.designer.report = new Stimulsoft.Report.StiReport();

        var dataSet = new Stimulsoft.System.Data.DataSet("SimpleDataSet");
        dataSet.readJsonFile("reports/Demo.json");

        var report = new Stimulsoft.Report.StiReport();
        report.regData(dataSet.dataSetName, "", dataSet);

        this.designer.report = report;

        // this.designer.report.regData(dataSet.dataSetName, "", dataSet);

        // this.http.get('http://localhost:52961/api/customers')
        //     .subscribe(data => {
        //         console.log(`data`);
        //         console.log(data);
                
        //         dataSet.readJsonFile(data);
        //         this.designer.report.regData(dataSet.dataSetName, "", dataSet);
        //     });


        console.log('Load report from url');
        this.designer.report.loadFile('/reports/SimpleList.mrt');

        console.log('Rendering the designer to selected element');
        this.designer.renderHtml('designer');

        console.log('Loading completed successfully!');
    }
}
