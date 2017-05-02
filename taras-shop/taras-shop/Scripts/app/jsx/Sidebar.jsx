import React, { Component } from 'react';

import SideFiltersPrice from './SideFiltersPrice.jsx';
import SideFiltersSize from './SideFiltersSize.jsx';

export default class Sidebar extends Component {
    constructor(props) {
        super(props);
        this.state = {
            categoryTypes: [1, 2, 3],
            categories: [1, 2, 3],
            sizes: [1, 2, 3],
            fromPrice: 0,
            toPrice: 5000,
            currentTypeId: null,
            currentCategory: null,
            returnSizes: null,
            oldP: null
        };
        this.renderLists = this.renderLists.bind(this);
        this.handleSizesChange = this.handleSizesChange.bind(this);
        this.setCurrentCategory = this.setCurrentCategory.bind(this);
        this.handleCategoryClick = this.handleCategoryClick.bind(this);
    }

    componentWillMount() {
        /*
         * Before component will start mounting, get categries and sizes from server
         */
        $.get("/Home/LoadSideBar", function (response) {
            this.setState({
                categoryTypes: response.category_types,
                categories: response.categories,
                sizes: response.sizes,
            });
        }.bind(this));
    }

    setCurrentCategory(TypeId, Category) {
        this.setState({
            currentTypeId: TypeId,
            currentCategory: Category
        }, () => {
            this.props.unsetPage();
            this.props.setHash(this.state.currentTypeId, this.state.currentCategory, 
                               this.state.returnSizes, this.state.fromPrice, this.state.toPrice);
        });
    }

    handleCategoryClick(event) {
        if(this.state.oldP) {
            let oldPRef = this.state.oldP;
            oldPRef.style = "";
            event.target.style.fontWeight = "bold";
            this.setState({
                oldP: event.target
            });
        }
        else {
            event.target.style.fontWeight = "bold";
            this.setState({
                oldP: event.target
            });
        }
    }

    renderLists(type_id) {
        /*
        * Create list of man, woman or children li, to use in our jsx
        */
        return this.state.categories.map(category => {
            if (category.TypeId === type_id) {
                return (
                    <li key={ category.Id }>                    
                        <p onClick={ (event) =>
                            {
                                this.setCurrentCategory(category.TypeId, category.Category);
                                this.handleCategoryClick(event);
                            }
                        }>
                            { category.Category }
                        </p>
                    </li>
            );
        }
    });
    }

    handleSizesChange() {
        // Get changes of size filters
        this.setState({
            returnSizes: this.state.sizes.map((size) => {
                let unitSize = document.querySelector("#" + size.Size + "-option:checked");
                if (unitSize) {
                    return size.Size
                }
            })
        }, () => {
            // Clean sizes array from undefined values
            let temp = [];
            for(let i of this.state.returnSizes)
                i && temp.push(i); // copy each non-empty value to the 'temp' array

            this.setState({
                returnSizes: temp
            }, () => {
                this.props.unsetPage();
                this.props.setHash(this.state.currentTypeId, this.state.currentCategory, 
                               this.state.returnSizes, this.state.fromPrice, this.state.toPrice);
            });
        });
    }

    render() {
        return (
         <aside className="col-lg-2 col-md-2 sidebar-nav sidebar">
            <div className="sidebar-mobile-accordion mobile-sidebar">
                <h3 className="side-catalog">Каталог товарів</h3>
                <div className="accordion" data-theme="none">
                    <h4>Жінки</h4>
                    <div>
                        <ul className="women">
                            { this.renderLists(1) }
                        </ul>
                    </div>
                    <h4>Чоловіки</h4>
                    <div>
                        <ul className="men">
                            { this.renderLists(2) }
                        </ul>
                    </div>
                    <h4>Діти</h4>
                    <div>
                        <ul className="children">
                            { this.renderLists(3) }
                        </ul>
                    </div>
                </div>
                <h3 className="filters-h">Фильтры</h3>
                <div className="filters">
                    <SideFiltersPrice unsetPage={ this.props.unsetPage } setHash={ this.props.setHash } page={ this.props.page } TypeId={ this.state.currentTypeId } Category={ this.state.currentCategory }
                                      Sizes={ this.state.returnSizes } />
                    <SideFiltersSize handleChange={ this.handleSizesChange } sizes={this.state.sizes}/>
                </div>
            </div>
         </aside>
      );
    }
};