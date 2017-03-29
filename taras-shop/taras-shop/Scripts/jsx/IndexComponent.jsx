class IndexComponent extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            units: []
        };
        this.getUnitInfo = this.getUnitInfo.bind(this);
    }

    getUnitInfo(typeId, category, sizes, fromPrice, toPrice) {
        sizes = typeof sizes !== false ? sizes : null;
        fromPrice = typeof fromPrice !== false ? fromPrice : null;
        toPrice = typeof toPrice !== false ? toPrice : null;
        let request = {
            typeId: typeId,
            category: category,
            sizes: sizes,
            fromPrice: fromPrice,
            toPrice: toPrice
        };                  

        let deleteChild = document.querySelector("#to-be-deleted");
        if (typeof (deleteChild) != 'undefined' && deleteChild != null) {
            document.querySelector(".main").removeChild(deleteChild);
        }

        $.get("/Home/GetItemsByFilter", request, (response) => {
            console.log(response);
            this.setState({
                units: response.Units,
                pageInfo: response.PageUnfo
            });
        });
    }

    render() {
        return (
            <div>
                <Sidebar getUnitInfo={this.getUnitInfo }/>
                <Units units={ this.state.units }/>
            </div>
        );
    }
}

class Sidebar extends React.Component {
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
            returnSizes: null
        };
        this.renderLists = this.renderLists.bind(this);
        this.handleSizesChange = this.handleSizesChange.bind(this);
        this.setCurrentCategory = this.setCurrentCategory.bind(this);
        this.handleGo = this.handleGo.bind(this);
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
        });
    }

    renderLists(type_id) {
        /*
        * Create list of man, woman or children li, to use in our jsx
        */
        return this.state.categories.map(category => {
            if (category.TypeId === type_id) {
                return (
                    <li key={ category.Id }>
                        <p onClick={ () =>
                        {
                            this.setCurrentCategory(category.TypeId, category.Category);
                            this.props.getUnitInfo(category.TypeId, category.Category,
                                this.state.returnSizes, this.state.fromPrice,
                                this.state.toPrice);
                        }}>
                        { category.Category }
                        </p>
                </li>
            );
        }
    });
    }

    handleGo(fromPrice, toPrice) {
        this.props.getUnitInfo(this.state.currentTypeId, this.state.currentCategory, this.state.returnSizes,
            fromPrice, toPrice);

        this.setState({
            fromPrice: fromPrice,
            toPrice: toPrice
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
                this.props.getUnitInfo(this.state.currentTypeId, this.state.currentCategory, this.state.returnSizes,
                    this.state.fromPrice, this.state.toPrice);
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
                    <SideFiltersPrice handleGo={ this.handleGo } />
                    <SideFiltersSize handleChange={ this.handleSizesChange } sizes={this.state.sizes}/>
                </div>
            </div>
         </aside>
      );
    }
};

class SideFiltersPrice extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            fromValue: 0,
            toValue: 5000
        };
        this.handleChange = this.handleChange.bind(this);
    }
    
    handleChange(event) {
        if (event.target.id === "from-price-input") {
            this.setState({
                fromValue: event.target.value
            });
        }
        else if (event.target.id === "to-price-input") {
            this.setState({
                toValue: event.target.value
            });
        }
    }

    render() {
        return (
            <div>
                <h4 className="price-h">Цена</h4>
                <div>
                    <label htmlFor="from-price-input">От: </label>
                    <input value={this.state.fromValue } id="from-price-input" onChange={ this.handleChange } type="text" />
                    <span>грн</span>
                </div>
                <div>
                    <label htmlFor="to-price-input">До: </label>
                    <input value={ this.state.toValue} id="to-price-input" onChange={ this.handleChange } type="text" />
                    <span>грн</span>
                </div>
                <button onClick={ () => this.props.handleGo(this.state.fromValue, this.state.toValue) }
                 className="go-search-btn">Go</button>
            </div>
        );
    }
}

class SideFiltersSize extends React.Component {
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

class Units extends React.Component {
    constructor(props) {
        super(props);
        this.renderUnits = this.renderUnits.bind(this);
        this.priceCheck = this.priceCheck.bind(this);
        this.renderPagination = this.renderPagination.bind(this);
        this.state = {
        };
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
        return unitList = this.props.units.map((unit) => {
            console.log(unit);
            return (
                <Unit link={ "/Home/ItemPage/" + unit.Id } key={ Math.random() } imgLink={{ backgroundImage: "url('../Content/images/" + unit.Image + "')" }} 
                 companyMaker={ unit.Title} itemType={ unit.Category} priceWas={ this.priceCheck(unit.OldPrice) } priceNow={ (unit.Price/100).toFixed(2) + " грн" } />
            );
        });
    }

    renderPagination() {
        return (
            <div className="pagination">
                <div className="pagination-wrapper">
                    <a className="material-icons">keyboard_arrow_left</a>
                    <a href="#">1</a>
                    <a className="active" href="#">2</a>
                    <a href="#">3</a>
                    <a href="#">4</a>
                    <a href="#">5</a>
                    <a href="#">6</a>
                    <a className="material-icons">keyboard_arrow_right</a>
                </div>
            </div>
            );
    }

    render() {
        return (
            <div className="col-md-9 col-sm-12 popular-units">
                { this.renderPagination() }
                { this.renderUnits() }
            </div>
        );
    }
}

class Unit extends React.Component {
    constructor(props) {
        super(props);
        this.isSale = this.isSale.bind(this);
    }

    isSale() {
        if(this.props.priceWas) {
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

ReactDOM.render(
  <IndexComponent />,
  document.getElementById('index-component')
);