class Sidebar extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            categoryTypes: [1, 2, 3],
            categories: [1, 2, 3],
            sizes: [1, 2, 3]
        };
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

    render() {
        /*
         * Create list of woman li, to use in our jsx
         */
        let womanList = this.state.categories.map(function (category) {
            if (category.TypeId === 1) {
                return (
                    <li key={ category.Id }>
                    <p>{ category.Category }</p>
                </li>
                );
            }
        });
        /*
         * Create list of man li, to use in our jsx
         */
        let manList = this.state.categories.map(function (category) {
            if (category.TypeId === 2) {
                return (
                    <li key={ category.Id }>
                    <p>{ category.Category }</p>
                </li>
                );
            }
        });
        /*
         * Create list of children li, to use in our jsx
         */
        let childrenList = this.state.categories.map(function (category) {
            if (category.TypeId === 3) {
                return (
                    <li key={ category.Id }>
                    <p>{ category.Category }</p>
                </li>
                );
            }
        });   
        return (
         <aside className="col-lg-2 col-md-2 sidebar-nav sidebar">
            <div className="sidebar-mobile-accordion mobile-sidebar">
                <h3 className="side-catalog">Каталог товарів</h3>
                <div className="accordion" data-theme="none">
                    <h4>Жінки</h4>
                    <div>
                        <ul className="women">
                            { womanList }
                        </ul>
                    </div>
                    <h4>Чоловіки</h4>
                    <div>
                        <ul className="men">
                            { manList }
                        </ul>
                    </div>
                    <h4>Діти</h4>
                    <div>
                        <ul className="children">
                            { childrenList }
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
        console.log(this.props.sizes);
        let sizeList = this.props.sizes.map(function (size) {
            return (
                <li key={'S' + size.Id }>
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

ReactDOM.render(
  <Sidebar />,
  document.getElementById('sidebar-component')
);