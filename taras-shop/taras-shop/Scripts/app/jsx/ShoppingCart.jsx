import React, { Component } from 'react';

export default class ShoppingCart extends Component {
    constructor(props) {
        super(props);
        this.state = {
            emptyLocalStorage: false,
            cartUnits: null
        };
        this.renderCartUnits = this.renderCartUnits.bind(this);
    }

    componentDidMount() {
        console.log(localStorage.units);
        let cartUnits = JSON.parse(localStorage.getItem("items"));
        console.log(cartUnits);
        if(cartUnits) {
            this.setState({ cartUnits });
        }
        else {
            this.setState({ emptyLocalStorage: true });
        }
    }

    renderCartUnits() {
        if(!this.state.emptyLocalStorage && this.state.cartUnits) {
            let unitList;
            return unitList = this.state.cartUnits.map((unit) => {
                return (
                    <CartUnit key={ Math.random() } title={ unit.Title } color={ unit.Color } price={ unit.Price }/>
                );
            });
        }
        else {
            return null;
        }
    }

    render() {
        return (
            <div className="container">
                <div className="row">
                    <h2 className="admin-header">Ваша Корзина</h2>
                    <div className="table-responsive">
                        <table className="table cart-table">
                            <thead>
                                <tr>
                                    <th>Товар</th>
                                    <th>Подробности</th>
                                    <th>Количество</th>
                                    <th>Цена</th>
                                    <th>Сумма</th>
                                </tr>
                            </thead>
                            <tbody>
                                { this.renderCartUnits() }
                            </tbody>
                        </table>
                    </div> 
                    <Summary/>
                </div>
            </div>
        );
    }
}

class CartUnit extends React.Component  {
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
                        <h4>{ this.props.title }</h4>
                        <span>Цвет: { this.props.color }</span>
                        {/*<a>Изменить</a>*/}
                        <span>Размер:</span>
                        <span>S</span>
                        {/*<a>Изменить</a>*/}
                    </div>
                </td>
                <td>
                    <input onChange={ this.handleChange } type="number" className="form-control cart-number-input" min="1" value={ this.state.number } />
                </td>
                <td>
                    <p className="cart-price-p">{ this.priceCheck(this.props.price) } грн</p>
                </td>
                <td>
                    <p className="cart-sum-p">{ (this.state.number * this.priceCheck(this.props.price)).toFixed(2) } грн</p>
                </td>
            </tr>
        );
    }
}

const Summary = (summaryCost, deliveryPrice) => {
    return (
        <div className="text-basket-preview-right">
            <div className="col-md-4 col-md-offset-4 cart-sum-block">
                <div className="overall-cost">
                    <span>Общая стоимость товаров: </span>
                    <span className="basket-preview-prices">234.85 грн</span>
                </div>
                <div className="delivery-cost">
                    <span>Доставка: </span>
                    <span className="basket-preview-prices">30.00 грн</span>
                </div>
                <div className="main-prices">
                    <h4 className="basket-sum">Сумма: </h4>
                    <span className="basket-preview-prices">264.85 грн</span>
                </div>
                <button className="frequent-button buy-button">Оформить заказ</button>
                <button className="frequent-button">Продолжить покупки</button>
            </div>
        </div>
    );
}