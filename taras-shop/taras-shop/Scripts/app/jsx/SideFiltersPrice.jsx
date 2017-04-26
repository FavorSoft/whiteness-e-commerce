import React, { Component } from 'react';

export default class SideFiltersPrice extends Component {
    constructor(props) {
        super(props);
        this.state = {
            fromPrice: 0,
            toPrice: 5000
        };
        this.handleChange = this.handleChange.bind(this);
        this.handleGo = this.handleGo.bind(this)
    }
    
    handleChange(event) {
        if (event.target.id === "from-price-input") {
            this.setState({
                fromPrice: event.target.value
            });
        }
        else if (event.target.id === "to-price-input") {
            this.setState({
                toPrice: event.target.value
            });
        }
    }

    handleGo() {
        window.location.hash = "#" + this.props.TypeId + "#" + this.props.Category + "#" + this.props.Sizes
                   + "#" + this.state.fromPrice + "#" + this.state.toPrice;
    }

    render() {
        return (
            <div>
                <h4 className="price-h">Цена</h4>
                <div>
                    <label htmlFor="from-price-input">От: </label>
                    <input value={this.state.fromPrice } id="from-price-input" onChange={ this.handleChange } type="text" />
                    <span>грн</span>
                </div>
                <div>
                    <label htmlFor="to-price-input">До: </label>
                    <input value={ this.state.toPrice } id="to-price-input" onChange={ this.handleChange } type="text" />
                    <span>грн</span>
                </div>
                <button onClick={ this.handleGo } className="go-search-btn">
                    Go
                </button>
            </div>
        );
    }
}