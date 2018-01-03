import { Component, Input } from '@angular/core';

@Component({
    selector: "tip-evaluation",
    templateUrl: "./tipevaluation.component.html"
})

export class TipEvaluationComponent {
    _tip: number = 0;

    @Input()
    get tip() {
        return this._tip;
    }
    set tip(tip: number) {
        this._tip = tip;
        this.evaluationTip();
    }

    evaluation: string = "";

    evaluationTip() {
        if (this._tip > 15)
            this.evaluation = "your tip is too high";
        else if (this._tip <= 15 && this._tip >= 10)
            this.evaluation = "your tip is proper";
        else 
            this.evaluation = "your tip is too low";
    }

}