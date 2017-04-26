import React, { Component } from 'react';

export default class Unit extends Component {
    constructor(props) {
        super(props);
        this.isSale = this.isSale.bind(this);
    }

    isSale() {
        if (this.props.priceWas) {
            return (
                <img className="sale-img" src="../Content/images/sale.png" alt="topsale" />
            );
        }
        else {
            return null;
        }
    }

    render() {
        return (
            <div className="col-md-6 col-lg-6 col-sm-6 col-xs-8 unit">
                    <a href={ this.props.link }>
                        <div style={ this.props.imgLink } className="col-md-10 col-md-offset-1 col-sm-12 col-xs-10 img-unit-div">
                            { this.isSale() }
                        </div>
                        <div className="col-md-8 col-md-offset-2 col-sm-10 col-sm-offset-1 col-xs-10 text-unit-part">
                            <div className="title-unit-part">
                                <p className="company-maker">{ this.props.companyMaker }</p>
                                <p className="item-type">{ this.props.itemType }</p>
                            </div>
                            <div className="price-unit-part">
                                <span className="price-now">{ this.props.priceNow }</span>
                                <span className="price-was">{ this.props.priceWas }</span>
                            </div>
                        </div>
                    </a>
            </div>
        );
    }
}