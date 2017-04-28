import React, { Component } from 'react';

export default class Pagination extends Component {
    constructor(props) {
        super(props);
        this.renderPages = this.renderPages.bind(this);
        this.pageClick = this.pageClick.bind(this);
        this.arrowClick = this.arrowClick.bind(this);
        this.state = {
            oldActiveA: null,
            leftArrow: <a name="left" onClick={ this.arrowClick } key={ Math.random() } 
                          className="material-icons">keyboard_arrow_left</a>,
            rightArrow: <a name="right" onClick={ this.arrowClick } key={ Math.random() } 
                           className="material-icons right">keyboard_arrow_right</a>,
            right: 0
        };
    }

    pageClick(event) {
        if (this.state.oldActiveA) {
            let changedA = this.state.oldActiveA;
            changedA.classList.remove("active");
            this.setState({
                oldActiveA: changedA
            });
        }
        let currentSibling = event.target;
        currentSibling.classList.add("active");
        this.setState({
            oldActiveA: currentSibling
        });
    }

    arrowClick(event) {
        console.log(this.state.right);
        console.log(this.props.pageInfo.TotalPages * 40);
        if (event.target.name === "right" && this.state.right < ((this.props.pageInfo.TotalPages * 40) - 200)) {
            this.setState({
                right: (this.state.right + 40)
            });
        }
        else if(event.target.name === "left" && this.state.right >= 40) {
            this.setState({
                right: (this.state.right - 40)
            });
        }
    }

    renderPages() {
        let total = this.props.pageInfo.TotalPages;
        let pages = [];
        for (let i = 1; i <= total; i++) {
            pages.push(<a onClick={ this.pageClick } key={i} href="#">{ i }</a>);
            if(total < 4)
            {
                document.querySelector(".conditional-a2").classList.add("conditional-display");
            }
        }
        return pages;
    }

    render() {
        return (
            <div className="pagination">
                <div className="pagination-wrapper">
                    { this.state.leftArrow }
                    { this.state.rightArrow }
                    <div className="conditional-a">
                        <a href="#" className="first-pag">1</a>
                        <a href="#" className="dots">...</a>
                    </div>
                    <div className="pag-moving-part">
                        <div style={{
                                "right": (this.state.right + "px"),
                                "width": ((this.props.pageInfo.TotalPages * 40) + 40) + "px"
                            }} className="pag-inner-part">
                            { this.renderPages() }
                        </div>
                    </div>
                    <div className="conditional-a2">
                        <a href="#" className="dots">...</a>
                        <a href="#" className="last-pag">{ this.props.pageInfo.TotalPages }</a>
                    </div>
                </div>
            </div>
        );
    }
}