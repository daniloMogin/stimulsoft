import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DesignerRoutingModule } from './designer-routing.module';
import { DesignerComponent } from './designer-logic/designer.component';

@NgModule({
    imports: [
        CommonModule,
        DesignerRoutingModule
    ],
    declarations: [DesignerComponent]
})
export class DesignerModule {}