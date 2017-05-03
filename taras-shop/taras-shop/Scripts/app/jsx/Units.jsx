import React, { Component } from 'react';

import Unit from './Unit.jsx';

export default class Units extends Component {
    constructor(props) {
        super(props);
        this.renderUnits = this.renderUnits.bind(this);
        this.priceCheck = this.priceCheck.bind(this);
    }

    priceCheck(price) {
        if (price) {
            let formatedPrice = (price / 100).toFixed(2) + " грн";
            return formatedPrice;
        }
        else {
            return "";
        }
    }

    renderUnits() {
        let unitList;
        return unitList = this.props.units.map((unit) => {
            return (
                <Unit link={ "/Home/ItemPage/" + unit.Id } key={ Math.random() } imgLink={{ backgroundImage: "url('../Content/images/Units/" + unit.Image + "')" }} 
                 companyMaker={ unit.Title} itemType={ unit.Category} priceWas={ this.priceCheck(unit.OldPrice) } priceNow={ this.priceCheck(unit.Price) } />
            );
        });
    }

    render() {
        return (
            <div className="col-md-9 col-sm-12 popular-units">
                { this.renderUnits() }
            </div>
        );
    }
}