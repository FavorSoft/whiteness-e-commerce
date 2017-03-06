class Sidebar extends React.Component {
    render() {
        return (
         <aside className="col-lg-2 col-md-2 sidebar-nav sidebar">
            <div className="sidebar-mobile-accordion mobile-sidebar">
                <SideCatalog />
                <SideFilters />
            </div>
         </aside>
      );
    }
};

class SideCatalog extends React.Component {
    render() {
        return (
            <div>
                <h3 className="side-catalog">Каталог товарів</h3>
                <div className="accordion" data-theme="none">
                    <h4>Жінки</h4>
                    <div>
                        <ul className="women">
                            <li>Білизна</li>
                            <li>Білизна</li>
                            <li>Білизна</li>
                            <li>Білизна</li>
                            <li>Білизна</li>
                        </ul>
                    </div>
                    <h4>Чоловіки</h4>
                    <div>
                        <ul className="men">
                            <li>Білизна</li>
                            <li>Білизна</li>
                            <li>Білизна</li>
                            <li>Білизна</li>
                        </ul>
                    </div>
                    <h4>Діти</h4>
                    <div>
                        <ul className="children">
                            <li>Білизна</li>
                            <li>Білизна</li>
                            <li>Білизна</li>
                            <li>Білизна</li>
                        </ul>
                    </div>
                </div>
            </div>
        );
    }
}

class SideFilters extends React.Component {
    render() {
        return (
            <div>
                <h3 className="filters-h">Фильтры</h3>
                <div className="filters">
                    <SideFiltersPrice/>
                    <SideFiltersSize />
                </div>
            </div>
        );
    }
}

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
    render() {
        return (
            <div>
                <h4 className="size-h">Розмір</h4>
                <ul className="radio-list">
                    <li>
                        <input type="checkbox" id="xs-option" name="selector" />
                        <label htmlFor="xs-option">Xs</label>
                        <div className="check"></div>
                    </li>

                    <li>
                        <input type="checkbox" id="s-option" name="selector" />
                        <label htmlFor="s-option">S</label>

                        <div className="check"><div className="inside"></div></div>
                    </li>

                    <li>
                        <input type="checkbox" id="m-option" name="selector" />
                        <label htmlFor="m-option">M</label>

                        <div className="check"><div className="inside"></div></div>
                    </li>

                    <li>
                        <input type="checkbox" id="l-option" name="selector" />
                        <label htmlFor="l-option">L</label>

                        <div className="check"><div className="inside"></div></div>
                    </li>

                    <li>
                        <input type="checkbox" id="xl-option" name="selector" />
                        <label htmlFor="xl-option">Xl</label>

                        <div className="check"><div className="inside"></div></div>
                    </li>
                </ul>
            </div>
        );
    }
}

ReactDOM.render(
  <Sidebar />,
  document.getElementById('sidebar-component')
);