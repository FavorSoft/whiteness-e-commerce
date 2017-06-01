import React, { Component } from 'react';
import ReactDOM from 'react-dom';

import ReactPaginate from 'react-paginate';

//import ShoppingCart from './ShoppingCart.jsx';
import Sidebar from './Sidebar.jsx';
import Units from './Units.jsx';

class IndexComponent extends Component {
    constructor(props) {
        super(props);
        this.state = {
            units: [],
            page: 0,
            pageInfo: [],
            isSearched: false,
            currentTypeId: null,
            currentCategory: null,
            returnSizes: null,
            fromPrice: null,
            toPrice: null
        };
        this.hashControl = this.hashControl.bind(this);
        this.handlePageClick = this.handlePageClick.bind(this);
        this.unsetPage = this.unsetPage.bind(this);
        this.setHash = this.setHash.bind(this);
    }

    componentDidMount() {
        this.hashControl();
        window.addEventListener('hashchange', () => {
            this.hashControl();
        });
    }

    hashControl() {
        if (window.location.hash) {
            this.setState({
                isSearched: true
            }, () => {
                let resList = window.location.hash.substr(2).split("/");
                resList = resList.map((item) => {
                    if (item !== "null") {
                        return item;
                    }
                    else {
                        return null;
                    }
                });

                this.setState({
                    currentTypeId: resList[0],
                    currentCategory: resList[1],
                    returnSizes: resList[2],
                    fromPrice: resList[3],
                    toPrice: resList[4],
                    page: parseInt(resList[5]) - 1
                });

                let request = {
                    typeId: resList[0],
                    category: resList[1],
                    sizes: resList[2],
                    fromPrice: resList[3],
                    toPrice: resList[4],
                    page: resList[5]
                };

                console.log("------req");
                console.log(request);
                
                let deleteChild = document.querySelector("#to-be-deleted");
                if (typeof (deleteChild) != 'undefined' && deleteChild != null) {
                    document.querySelector(".main").removeChild(deleteChild);
                }

                $.get("/Home/GetItemsByFilter", request, (response) => {
                    console.log("-------res");
                    console.log(response);
                    this.setState({
                        units: response.Units,
                        pageInfo: response.PageInfo
                    });
                });
            });
        }
    }

    unsetPage() {
        this.setState({
            page: 0
        }, () => {
            this.setHash(this.state.currentTypeId,
            this.state.currentCategory,
            this.state.returnSizes,
            this.state.fromPrice,
            this.state.toPrice);
        });
    }

    setHash(currentTypeId, currentCategory, returnSizes, fromPrice, toPrice) {
        window.location.hash = "/" + currentTypeId + "/" + currentCategory + "/" + returnSizes
                            + "/" + fromPrice + "/" + toPrice + "/" + (this.state.page + 1);
        this.setState({
            currentTypeId,
            currentCategory,
            returnSizes,
            fromPrice,
            toPrice
        }, () => {
            this.hashControl();
        });
    }

    handlePageClick(currentPage) {
        this.setState({
           page: currentPage.selected
        }, () => {
            this.setHash(this.state.currentTypeId,
            this.state.currentCategory,
            this.state.returnSizes,
            this.state.fromPrice,
            this.state.toPrice);
        });
    }

    render() {
        return (
            <div>
                <Sidebar unsetPage={ this.unsetPage } setHash={ this.setHash } page={ this.state.page } />
                { this.state.isSearched ? 
                    <ReactPaginate previousLabel={"previous"}
                       nextLabel={"next"}
                       breakLabel={<a href="">...</a>}
                       forcePage={this.state.page}
                       breakClassName={"break-me"}
                       pageCount={this.state.pageInfo.TotalPages}
                       marginPagesDisplayed={2}
                       pageRangeDisplayed={5}
                       onPageChange={this.handlePageClick}
                       containerClassName={"pagination"}
                       subContainerClassName={"pages pagination"}
                       activeClassName={"active"} /> 
                       : null }
                <Units units={ this.state.units } />
            </div>
        );
    }
}

if(window.location.pathname === "/") {
    console.log("Index");
    ReactDOM.render(
        <IndexComponent />,
        document.getElementById('index-component')
    );
}


