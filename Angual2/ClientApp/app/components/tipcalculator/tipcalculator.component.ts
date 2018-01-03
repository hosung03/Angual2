import { Component } from '@angular/core';

@Component({
    selector: "tip-calculator",
    templateUrl: "./tipcalculator.component.html"
})

export class TipCalculatorComponent {
    price: number = 0;
    tip: number = 15;
    msg: string = "";
    onCount(): void {
       var tipprice = Number((this.tip / 100) * this.price);
       var payrprice = Number(this.price) + tipprice;
       //console.log("payrprice:" + payrprice);
       this.msg = "your pay price is " + payrprice + "";
    }
}
