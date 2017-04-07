class IndexComponent extends React.Component {
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
                console.log(resList);
                let sizes = null;
                if (resList[2]) {
                    sizes = resList[2].split(",");
                }
                console.log(sizes);
                let request = {
                    typeId: resList[0],
                    category: resList[1],
                    sizes: sizes,
                    fromPrice: resList[3],
                    toPrice: resList[4],
                    page: this.state.page
                };

                let deleteChild = document.querySelector("#to-be-deleted");
                if (typeof (deleteChild) != 'undefined' && deleteChild != null) {
                    document.querySelector(".main").removeChild(deleteChild);
                }

                $.get("/Home/GetItemsByFilter", request, (response) => {
                    //console.log(response);
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

    render() {
        return (
            <div>
                <Sidebar />
                {
                    this.state.isSearched ? <Pagination pageInfo={ this.state.pageInfo } /> : null
                }
                <Units units={ this.state.units } />
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
            window.location.hash = "#" + this.state.currentTypeId + "#" + this.state.currentCategory + "#" + this.state.returnSizes
                            + "#" + this.state.fromPrice + "#" + this.state.toPrice;
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
                        }}>
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
                window.location.hash = "#" + this.state.currentTypeId + "#" + this.state.currentCategory + "#" + this.state.returnSizes
                            + "#" + this.state.fromPrice + "#" + this.state.toPrice;
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
                    <SideFiltersPrice TypeId={ this.state.currentTypeId } Category={ this.state.currentCategory }
                                      Sizes={ this.state.returnSizes } />
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

class Pagination extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            oldActiveA: null
        };
        this.renderPages = this.renderPages.bind(this);
        this.pageClick = this.pageClick.bind(this);
    }

    pageClick(event) {
        if (this.state.oldActiveA) {
            this.state.oldActiveA.classList = "";
        }
        let currentSibling = event.target;
        event.target.classList += "active";
        this.setState({
            oldActiveA: event.target
        });
        if (currentSibling.nextSibling.innerHTML == "...") {
            let number = parseInt(currentSibling.innerHTML) + 1;
            let newNode = currentSibling;
            let parentNode = currentSibling.parentNode;
            parentNode.removeChild(parentNode.childNodes[1]);
            newNode.innerHTML = parseInt(currentSibling.innerHTML) + 1;
            currentSibling.parentNode.insertBefore(newNode, currentSibling.nextSibling);
        }   
    }

    renderPages() {
        let total = this.props.pageInfo.TotalPages;
        let pages = [];
        if (total > 4) {
            for (let i = 1; i <= 4; i++) {
                if (i === 1) {
                    pages.push(<a key={ Math.random() } className="material-icons">keyboard_arrow_left</a>);
                }
                pages.push(<a onClick={ (event) => this.pageClick(event) } key={i} href="#">{ i }</a>);
                if (i === 4) {
                    pages.push(<a key={ Math.random() }>...</a>);
                    pages.push(<a key={ Math.random() } href="#">{ total }</a>);
                    pages.push(<a key={ Math.random() } className="material-icons">keyboard_arrow_right</a>);
                }
            }
        }
        else {
            for (let i = 1; i <= total; i++) {
                pages.push(<a key={i} href="#">{ i }</a>);
            }
        }
        return pages;
    }

    render() {
        return (
            <div className="pagination">
                <div className="pagination-wrapper">
                    { this.renderPages() }
                </div>
            </div>
        );
    }
}

class Units extends React.Component {
    constructor(props) {
        super(props);
        this.renderUnits = this.renderUnits.bind(this);
        this.priceCheck = this.priceCheck.bind(this);
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
                <Unit link={ "/Home/ItemPage/" + unit.Id } key={ Math.random() } imgLink={{ backgroundImage: "url('../Content/images/Units/" + unit.Image + "')" }} 
                 companyMaker={ unit.Title} itemType={ unit.Category} priceWas={ this.priceCheck(unit.OldPrice) } priceNow={ (unit.Price/100).toFixed(2) + " грн" } />
            );
        });
    }

    render() {
        return (
            <div className="col-md-9 col-sm-12 popular-units">
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

ReactDOM.render(
  <IndexComponent />,
  document.getElementById('index-component')
);
