import React, { Component } from 'react';

export default class SideFiltersSize extends React.Component {
    constructor(props) {
        super(props);
        this.renderSizes = this.renderSizes.bind(this);
    }

    renderSizes() {
        return this.props.sizes.map(size => {
            return (
                <li key={ size.Id || Math.random() }>
                    <input value="true" onChange={ this.props.handleChange }
                     type="checkbox" id={ size.Size + '-option' } name="selector" />
                    <label htmlFor={ size.Size + '-option' }>{ size.Size }</label>
                    <div className="check"></div>
                </li>
            );
        }); 
    }

    render() {
         
        return (
            <div>
                <h4 className="size-h">Розмір</h4>
                <ul className="radio-list">
                    { this.renderSizes() }
                </ul>
            </div>
        );
    }
}