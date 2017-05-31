import React, { Component } from 'react';

export default class ShoppingCart extends Component {
    constructor(props) {
        super(props);
        this.state = {
            auth: props["auth"],
            emptyLocalStorage: false,
            cartUnits: null
        };
        this.renderCartUnits = this.renderCartUnits.bind(this);
    }

    componentDidMount() {
        let cartUnits;
        if (this.state.auth == "true") {
            var request;
            $.get("/Home/GetItemsFromBasket", request, (response) => {
                cartUnits = response;
                if (cartUnits) {
                    this.setState({ cartUnits });
                }
                else {
                    this.setState({ emptyLocalStorage: true });
                }
            });
        }
        else {
            let tmp = localStorage.getItem("items");

            $.get("/Home/GetItemsByBasket", { json: tmp }, (response) => {
                cartUnits = response;
                if (cartUnits) {
                    this.setState({ cartUnits });
                }
                else {
                    this.setState({ emptyLocalStorage: true });
                }
            });
        }
    }

    renderCartUnits() {
        if (!this.state.emptyLocalStorage && this.state.cartUnits) {

            return this.state.cartUnits;
            //unitList = this.state.cartUnits.map((unit) => {
            //    console.log(unit.Price);
            //    return (
            //        <CartUnit key={unit.Id} props={unit} title={unit.Title} color={unit.Color} price={unit.Price} />
            //    );
            //});
        }
        else {
            return null;
        }
    }

    render() {
        return (
            <div className="container">
                <div className="row">
                    <h2 className="admin-header">Ваша корзина</h2>
                    <div className="table-responsive" dangerouslySetInnerHTML={{
                        __html: this.renderCartUnits()
                    }}>
                    </div>
                    <div className="col-md-4 col-md-offset-4">
                        <div >
                            <div id="basket-result" ></div>
                            <form action="/Home/ToOrder" data-ajax="true" data-ajax-method="Post" data-ajax-mode="replace" data-ajax-update="#basket-result" id="form0" method="post">
                                <button className="frequent-button buy-button">Оформить заказ</button>
                            </form>
                            <a href="/">
                                <button className="frequent-button">Продолжить покупки</button>
                            </a>
                        </div>
                    </div>
                </div>
            </div>
        );
    }
}

class CartUnit extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            number: 1
        }
        this.priceCheck = this.priceCheck.bind(this);
        this.handleChange = this.handleChange.bind(this);
    }

    priceCheck(price) {
        price = parseInt(price);
        if (price) {
            let formatedPrice = parseFloat(price / 100).toFixed(2);
            return formatedPrice;
        }
        else {
            return "";
        }
    }

    handleChange(event) {
        this.setState({
            number: parseInt(event.target.value)
        });
    }

    render() {
        return (
            <tr>
                <td className="image-td">
                    <a className="material-icons">clear</a>
                    <img src="../../Content/images/woman.png" />
                </td>
                <td>
                    <div className="text-basket-preview">
                        <h4>{this.props.title}</h4>
                        <span>????: {this.props.color}</span>
                        <span>??????:</span>
                        <span>S</span>
                    </div>
                </td>
                <td>
                    <input onChange={this.handleChange} type="number" className="form-control cart-number-input" min="1" value={this.state.number} />
                </td>
                <td>
                    <p className="cart-price-p">{this.priceCheck(this.props.price)} ???</p>
                </td>
                <td>
                    <p className="cart-sum-p">{(this.state.number * this.priceCheck(this.props.price)).toFixed(2)} ???</p>
                </td>
            </tr>
        );
    }
}

const Summary = (summaryCost, deliveryPrice) => {
    return (""
        //<div className="text-basket-preview-right">
        //    <div className="col-md-4 col-md-offset-4 cart-sum-block">
        //        <div className="overall-cost">
        //            <span>????? ????????? ???????: </span>
        //            <span className="basket-preview-prices">234.85 ???</span>
        //        </div>
        //        <div className="delivery-cost">
        //            <span>????????: </span>
        //            <span className="basket-preview-prices">30.00 ???</span>
        //        </div>
        //        <div className="main-prices">
        //            <h4 className="basket-sum">?????: </h4>
        //            <span className="basket-preview-prices">264.85 ???</span>
        //        </div>
        //        <button className="frequent-button buy-button">???????? ?????</button>
        //        <button className="frequent-button">?????????? ???????</button>
        //    </div>
        //</div>
    );
}