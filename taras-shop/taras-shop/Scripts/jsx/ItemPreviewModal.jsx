class ItemPreviewModal extends React.Component {
    constructor(props) {
        super(props);
        this.state = {};
    }

    render() {
        return (
            <div className="modal fade" id="item-preview-modal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel3">
                <div className="container">
                    <div className="row">
                        <div className="col-md-10 col-md-offset-1">
                            <div className="modal-dialog" role="document">
                                <div className="modal-content">
                                    <div className="modal-header">
                                        <div type="button" className="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></div>
                                    </div>
                                    <div className="modal-body">
                                        <Carouel />
                                        <Details />
                                    </div>
                                    <div className="modal-footer"></div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        );
    }
}

class Carousel extends React.Component {
    constructor(props) {
        super(props);
        this.state = {};
    }

    render() {
        return (
           null
        );
    }
}

class Details extends React.Component {
    constructor(props) {
        super(props);
        this.state = {};
        this.renderModalSizes = this.renderModalSizes.bind(this);
    }

    renderModalSizes() {
        return this.props.sizes.map(function (size) {
            return (
                <li key={ size.Id || Math.random() }>
                    <input type="checkbox" id={ size.Size + '-option' } name="selector" />
                    <label htmlFor={ size.Size + '-option' }>{ size.Size }</label>
                    <div className="check"></div>
                </li>
            );
        }); 
    }

    render() {
        return (
            <div className="col-md-4 details-modal-part">
                <div className="col-md-12 text-details-part">
                    <div className="title-unit-part">
                        <p id="title-on-modal" className="company-maker">{ this.props.name }</p>
                        <p id="item-type-on-modal" className="item-type"></p>
                    </div>
                    <div className="price-unit-part">
                        <span id="price-now-on-modal" className="price-now"></span>
                        <span className="price-was"></span>
                    </div>
                    <div className="line"></div>
                </div>
                <div className="colors"></div>
                <div className="choose-size">
                    <h4 id="size-toggle"></h4>
                    <div className="append-radio">
                        <ul className="radio-list">
                            { this.renderModalSizes() }
                        </ul>
                    </div>
                </div>

                <button className="frequent-button">Добавить в корзину</button>
                <a href="/Home/ItemPage"><button className="frequent-button">Смотреть товар</button></a>
            </div>
        );
    }
}