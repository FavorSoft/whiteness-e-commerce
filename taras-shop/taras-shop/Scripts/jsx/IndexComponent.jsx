class IndexComponent extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            units: []
        };
        this.getUnitInfo = this.getUnitInfo.bind(this);
    }

    getUnitInfo(typeId, category, sizes = false, fromPrice = false, toPrice = false) {
        document.querySelector(".main").classList.add("nondisplay");
        console.log("-------------------------");
        console.log(typeId);
        console.log(category);
        console.log(fromPrice);
        console.log(toPrice);
        //запит
        this.setState({
            units: [{name: category}]
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
            toPrice: 0
        };
        this.renderWomanList = this.renderWomanList.bind(this);
        this.handleChange = this.handleChange.bind(this);
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
                currentTypeId: null,
                currentCategory: null
            });
        }.bind(this));
    }

    setCurrentCategory(TypeId, Category) {
        this.setState({
            currentTypeId: TypeId,
            currentCategory: Category
        });
    }

    renderWomanList() {
        /*
         * Create list of woman li, to use in our jsx
         */
        return this.state.categories.map(category => {
            if (category.TypeId === 1) {
                return (
                    <li key={ category.Id }>
                        <p onClick={ () => 
                        {
                            this.props.getUnitInfo(category.TypeId, category.Category);
                            this.setCurrentCategory(category.TypeId, category.Category);
                        }}>
                        { category.Category }
                        </p>
                    </li>
                );
            }
        });
    }

    renderManList() {
        /*
         * Create list of man li, to use in our jsx
         */
        return this.state.categories.map(category => {
            if (category.TypeId === 2) {
                return (
                    <li key={ category.Id }>
                        <p onClick={ () => this.props.getUnitInfo(category.TypeId, category.Category) }>{ category.Category }</p>
                    </li>
                );
        }
    });
    }

    renderChildrenList() {
        /*
         * Create list of children li, to use in our jsx
         */
        return this.state.categories.map(category => {
            if (category.TypeId === 3) {
                return (
                    <li key={ category.Id }>
                        <p onClick={ () => this.props.getUnitInfo(category.TypeId, category.Category) }>{ category.Category }</p>
                    </li>
                );
            }
        });
    }

    handleChange(event) {
        console.log("fire");
        let fromPrice = null;
        let toPrice = null;
        if (event.target.id === "from-price-input")
        {
                fromPrice = event.target.value
        }
        else if (event.target.id === "to-price-input")
        {
                toPrice = event.target.value
        }
        // Get changes of filters
        let sizes = this.state.sizes.map((size) => {
            let unitSize = document.querySelector("#" + size.Size + "-option:checked");
            if (unitSize) {
                return size.Size
            }
        });
        // Clean sizes array from undefined values
        temp = [];
        for(let i of sizes)
            i && temp.push(i); // copy each non-empty value to the 'temp' array

        sizes = temp;
        this.props.getUnitInfo(this.state.currentCategory, this.currentTypeId, sizes, fromPrice, toPrice);
    }

    //handleSearchClick() {
    //    /*
    //     * If filters change - get changes and send them to the server
    //     */
    //    // Get changes of filters
    //    let sizes = this.state.sizes.map((size) => {
    //        let unitSize = document.querySelector("#" + size.Size + "-option:checked");
    //        if (unitSize) {
    //            return size.Size
    //        }
    //    });
    //    // Clean sizes array from undefined values
    //    temp = [];
    //    for(let i of sizes)
    //        i && temp.push(i); // copy each non-empty value to the 'temp' array

    //    sizes = temp;
    //    // Do ajax response to server for unit filtering
    //    /*$.get('/Home/GetItemsByFilter', {sizes: sizes, fromPrice: this.state.fromPrice, toPrice: this.state.toPrice}, (response) => {
    //        console.log(response);
    //    });*/
    //    console.log("Sent!");
    //}

    render() {
        return (
         <aside className="col-lg-2 col-md-2 sidebar-nav sidebar">
            <div className="sidebar-mobile-accordion mobile-sidebar">
                <h3 className="side-catalog">Каталог товарів</h3>
                <div className="accordion" data-theme="none">
                    <h4>Жінки</h4>
                    <div>
                        <ul className="women">
                            { this.renderWomanList() }
                        </ul>
                    </div>
                    <h4>Чоловіки</h4>
                    <div>
                        <ul className="men">
                            { this.renderManList() }
                        </ul>
                    </div>
                    <h4>Діти</h4>
                    <div>
                        <ul className="children">
                            { this.renderChildrenList() }
                        </ul>
                    </div>
                </div>
                <h3 className="filters-h">Фильтры</h3>
                <div className="filters">
                    <SideFiltersPrice handleChange={ this.handleChange } />
                    <SideFiltersSize handleChange={ this.handleChange } sizes={this.state.sizes}/>
                </div>
            </div>
         </aside>
      );
    }
};

class SideFiltersPrice extends React.Component {
    constructor(props) {
        super(props);
    }

    render() {
        return (
            <div>
                <h4 className="price-h">Цена</h4>
                <div>
                    <label htmlFor="from-price-input">От: </label>
                    <input id="from-price-input" onChange={ this.props.handleChange } type="text" />
                    <span>грн</span>
                </div>
                <div>
                    <label htmlFor="to-price-input">До: </label>
                    <input id="to-price-input" onChange={ this.props.handleChange } type="text" />
                    <span>грн</span>
                </div>
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
                    <input value="true" onChange={ this.props.handleChange } type="checkbox" id={ size.Size + '-option' } name="selector" />
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
    }

    renderUnits() {
        return unitList = this.props.units.map(function (unit) {
            console.log(unit.name);
            return (
                <Unit key={ Math.random()} imgLink={{ backgroundImage: "url('../Content/images/mant.jpg')" }} companyMaker={unit.name} itemType="Tryci" priceWas="100.90" priceNow="23.78"/>
            );
        });
    }

    render() {
        return (
            <div className="col-md-9 popular-units">
                {this.renderUnits()}
            </div>
        );
    }
}

class Unit extends React.Component {
    render() {
        return (
            <div className="col-md-6 col-lg-6 col-sm-6 col-xs-8 unit">
                    <a href="/Home/ItemPage">
                        <div style={ this.props.imgLink } className="col-md-10 col-md-offset-1 col-sm-12 col-xs-10 img-unit-div">
                            {/*<img className="sale-img" src={this.props.sale} alt="topsale" />*/}
                            <div className="quick-view" data-target="#item-preview-modal" data-toggle="modal">
                                <img src="../Content/images/eye.png" alt="eye" />
                                <span>Быстрый просмотр</span>
                            </div>
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