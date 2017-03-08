﻿class IndexComponent extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            units: []
        };
        this.getUnitInfo = this.getUnitInfo.bind(this);
    }

    getUnitInfo(typeId, category) {
        document.querySelector(".main").classList.add("nondisplay");
        console.log(typeId);
        console.log(category);
        this.setState({
            units: [{name: category}]
        });
        return null;
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
            sizes: [1, 2, 3]
        };
        this.renderWomanList = this.renderWomanList.bind(this);
    }

    componentWillMount() {
        /*
         * Before component will start mounting, get categries and sizes from server
         */
        $.get("/Home/LoadSideBar", function (response) {
            this.setState({
                categoryTypes: response.category_types,
                categories: response.categories,
                sizes: response.sizes
            });
        }.bind(this));
    }

    renderWomanList() {
        /*
         * Create list of woman li, to use in our jsx
         */
        return womanList = this.state.categories.map(category => {
            if (category.TypeId === 1) {
                return (
                    <li key={ category.Id }>
                        <p onClick={ () => this.props.getUnitInfo(category.TypeId, category.Category) }>{ category.Category }</p>
                    </li>
                );
            }
        });
    }

    renderManList() {
        /*
         * Create list of woman li, to use in our jsx
         */
        return womanList = this.state.categories.map(category => {
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
         * Create list of woman li, to use in our jsx
         */
        return womanList = this.state.categories.map(category => {
            if (category.TypeId === 3) {
                return (
                    <li key={ category.Id }>
                        <p onClick={ () => this.props.getUnitInfo(category.TypeId, category.Category) }>{ category.Category }</p>
                    </li>
                );
        }
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
                            <li>
                                <p onClick={ this.showCategoryItems }>Custom</p>
                            </li>
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
                    <SideFiltersPrice />
                    <SideFiltersSize sizes={this.state.sizes}/>
                </div>
            </div>
         </aside>
      );
    }
};

class SideFiltersPrice extends React.Component {
    render() {
        return (
            <div>
                <h4 className="price-h">Цена</h4>
                <p>
                    <input type="text" readOnly id="amount" />
                </p>
                <div id="slider"></div>
            </div>
        );
    }
}

class SideFiltersSize extends React.Component {
    constructor(props) {
        super(props);
    }

    render() {
        let sizeList = this.props.sizes.map(function (size) {
            return (
                <li key={ size.Id || Math.random() }>
                    <input type="checkbox" id={ size.Size + '-option' } name="selector" />
                    <label htmlFor={ size.Size + '-option' }>{ size.Size }</label>
                    <div className="check"></div>
                </li>
            );
        });  
        return (
            <div>
                <h4 className="size-h">Розмір</h4>
                <ul className="radio-list">
                    { sizeList }
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