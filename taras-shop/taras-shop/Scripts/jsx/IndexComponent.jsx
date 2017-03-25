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
        //document.querySelector(".main").removeChild();
        
        $.get("/Home/GetItemsByFilter", request, (response) => {
            console.log(response);
        });
        console.log("change");
        this.setState({
            units: [{ name: category }]
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
            returnSizes: null,
            isGo: false
        };
        this.renderLists = this.renderLists.bind(this);
        this.handleChange = this.handleChange.bind(this);
        this.setCurrentCategory = this.setCurrentCategory.bind(this);
        this.pause = this.pause.bind(this);
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
                        }}>{ category.Category }
                    </p>
                </li>
            );
        }
    });
    }

    pause(milliseconds) {
        var dt = new Date();
        while ((new Date()) - dt <= milliseconds) { /* Do nothing */ }
    }

    handleGo(toPrice, fromPrice) {
        console.log("TOGGLE");
        if (this.state.isGo === false) {
            this.setState({
                isGo: true
            });
        }
        else if (this.state.isGo === true) {
            this.setState({
                isGo: false
            });
        }
    }

    //handlePriceChange(event) {
    //    let eventTarget = event.target;
    //    if (event.target.id === "from-price-input") {
    //        this.setState({
    //            fromPrice: event.target.value
    //        });
    //    }
    //    else if (event.target.id === "to-price-input") {
    //        this.setState({
    //            toPrice: event.target.value
    //        });
    //    }
        
    //    console.log("evenTarget");
    //    if (this.state.isGo) {
    //        console.log("evenTarget ISGO");
    //        this.props.getUnitInfo(this.state.currentCategory, this.state.currentTypeId, this.state.returnSizes,
    //            this.state.fromPrice, this.state.toPrice);
    //    }
    //}

    //handleSizesChange() {
    //    // Get changes of size filters
    //    this.setState({
    //        returnSizes: this.state.sizes.map((size) => {
    //            let unitSize = document.querySelector("#" + size.Size + "-option:checked");
    //            if (unitSize) {
    //                return size.Size
    //            }
    //        })
    //    }, () => {
    //        // Clean sizes array from undefined values
    //        let temp = [];
    //        for(let i of this.state.returnSizes)
    //            i && temp.push(i); // copy each non-empty value to the 'temp' array

    //        this.setState({
    //            returnSizes: temp
    //        }, () => {
    //            //if (eventTarget.id === "from-price-input" || eventTarget.id === "to-price-input") {
    //            //    console.log("evenTarget");
    //            //    if (this.state.isGo) {
    //            //        console.log("evenTarget ISGO");
    //            //        this.props.getUnitInfo(this.state.currentCategory, this.state.currentTypeId, this.state.returnSizes,
    //            //            this.state.fromPrice, this.state.toPrice);
    //            //    }
    //            //}
    //            //else {
    //                this.props.getUnitInfo(this.state.currentCategory, this.state.currentTypeId, this.state.returnSizes,
    //                    this.state.fromPrice, this.state.toPrice);
    //            //}
    //        });
    //    });
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
                    <SideFiltersPrice handleChange={ this.handleChange} fromValue={this.state.fromPrice} 
                        toValue={this.state.toPrice} />
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
                    <input value={this.props.fromValue } id="from-price-input" onChange={ this.props.handleChange } type="text" />
                    <span>грн</span>
                </div>
                <div>
                    <label htmlFor="to-price-input">До: </label>
                    <input value={ this.props.toValue }  id="to-price-input" onChange={ this.props.handleChange } type="text" />
                    <span>грн</span>
                </div>
                <button onClick={ this.props.handleGo } className="go-search-btn">Go</button>
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
    }

    renderUnits() {
        return unitList = this.props.units.map(function (unit) {
            return (
                <Unit key={ Math.random()} imgLink={{ backgroundImage: "url('../Content/images/mant.jpg')" }} 
                 companyMaker={unit.name} itemType="Tryci" priceWas="100.90" priceNow="23.78"/>
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