import React, { Component } from 'react';
import ReactDOM from 'react-dom';

import ReactPaginate from 'react-paginate';

import Sidebar from './Sidebar.jsx';
import Units from './Units.jsx';

class IndexComponent extends Component {
    constructor(props) {
        super(props);
        this.state = {
            units: [],
            page: 1,
            route: window.location.hash.substr(1),
            pageInfo: [],
            isSearched: false
        };
        this.hashControl = this.hashControl.bind(this);
        this.handlePageClick = this.handlePageClick.bind(this);
    }

    hashControl() {
        if (window.location.hash) {
            this.setState({
                route: window.location.hash.substr(1),
                isSearched: true
            }, () => {
                let resList = this.state.route.split("#");
                resList = resList.map((item) => {
                    if (item !== "null") {
                        return item;
                    }
                    else {
                        return null;
                    }
                });
                
                let request = {
                    typeId: resList[0],
                    category: resList[1],
                    sizes: resList[2],
                    fromPrice: resList[3],
                    toPrice: resList[4],
                    page: this.state.page
                };
                
                let deleteChild = document.querySelector("#to-be-deleted");
                if (typeof (deleteChild) != 'undefined' && deleteChild != null) {
                    document.querySelector(".main").removeChild(deleteChild);
                }

                $.get("/Home/GetItemsByFilter", request, (response) => {
                    console.log(response);
                    this.setState({
                        units: response.Units,
                        pageInfo: response.PageInfo
                    });
                });
                
            });
        }
    }

    componentDidMount() {
        this.hashControl();
        window.addEventListener('hashchange', () => {
            this.hashControl();
        });
    }

    handlePageClick(currentPage) {
        console.log(currentPage);
        console.log("page clickk!!!");
    }

    render() {
        return (
            <div>
                <Sidebar />
                { this.state.isSearched ? 
                    <ReactPaginate previousLabel={"previous"}
                       nextLabel={"next"}
                       breakLabel={<a href="">...</a>}
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

ReactDOM.render(
  <IndexComponent />,
  document.getElementById('index-component')
);
