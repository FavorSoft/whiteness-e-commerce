class MainPageCenter extends React.Component {
    render() {
        return (
         <section className="main">
             <LinkImages />
             <PopularUnits />
             <RecommendUnits />
             <About />
         </section>
      );
    }
};

class LinkImages extends React.Component {
    render() {
        return (
            <div>
                <a href="#" className="her-a">
                    <div className="col-md-4 col-md-offset-1 col-sm-offset-4 her">
                        <div className="her-img">
                            <div className="her-text">
                                <h3>Для Нее</h3>
                                <h5>Комфортная женственность</h5>
                            </div>
                        </div>
                    </div>
                </a>
                <a href="#" className="he-a">
                    <div className="col-md-4 col-md-offset-1 col-sm-offset-4 he">
                        <div className="he-img">
                            <div className="he-text">
                                <h3>Для Него</h3>
                                <h5>Практичность на каждый день</h5>
                            </div>
                        </div>
                    </div>
                </a>
                <a href="#" className="news-a">
                    <div className="col-md-9 col-md-offset-1 news">
                        <div className="text-news">
                            <h1>Новинки</h1>
                            <h3>Весна 2017</h3>
                        </div>
                    </div>
                </a>
            </div>
        );
    }
}

class PopularUnits extends React.Component {
    render() {
        return (
            <div className="col-md-9 popular-units">
                <div className="title-lines">
                    <div className="col-md-4 left-line"></div>
                    <h4 className="title-lines-h">Популярные товары</h4>
                    <div className="col-md-4 right-line"></div>
                </div>
                <Unit сompanyMaker="Anbelichka" itemType="Tryci" priceWas="100.90" priceNow="23.78" />
            </div>
        );
    }
}

class RecommendUnits extends React.Component {
    render() {
        return (
            <div className="col-md-12 recommend-units">
                <div className="title-lines">
                    <div className="col-md-4 left-line"></div>
                    <h4 className="title-lines-h">Рекомендуем</h4>
                    <div className="col-md-4 right-line"></div>
                </div>
                <SmallUnit сompanyMaker="Anbelichka" itemType="Tryci" priceWas="100.90" priceNow="23.78" />
                <SmallUnit сompanyMaker="Anbelichka" itemType="Tryci" priceWas="100.90" priceNow="23.78" />
                <SmallUnit сompanyMaker="Anbelichka" itemType="Tryci" priceWas="100.90" priceNow="23.78" />    
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
                            <img className="sale-img" src="~/Content/images/sale.png" alt="topsale" />
                            <div className="quick-view" data-target="#item-preview-modal" data-toggle="modal">
                                <img src="~/Content/images/eye.png" alt="eye" />
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

class SmallUnit extends React.Component {
    render() {
        return (
            <div className="col-md-4 col-lg-4 col-sm-6 col-xs-8 unit">
                <div style={ this.props.imgLink } className="col-md-10 col-md-offset-1 col-sm-12 col-xs-10 img-unit-div">
                    <div className="quick-view">
                        <img src="/Content/images/eye.png" alt="eye" />
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
            </div>
        );
    }
}

class About extends React.Component {
    render() {
        return (
            <div className="col-md-12 about">
                <div className="title-lines">
                    <div className="col-md-4 left-line"></div>
                    <h4 className="title-lines-h">О нас</h4>
                    <div className="col-md-4 right-line"></div>
                </div>
                <div className="about-text-block">
                    <h4 className="first-about-h3">Большой выбор товаров</h4>
                    <p className="first-about-p">
                        Lorem.ua — крупнейший онлайн-магазин модной одежды, обуви и аксессуаров в Украине.
                        Здесь Вы можете купить все модные новинки с доставкой на дом.
                        В каталоге интернет-магазина Lorem.ua более 1000 брендов мужской,
                        женской и детской обуви и одежды разных ценовых категорий, всего более 2 000 000 товаров.
                        Наш ассортимент постоянно пополняется новыми товарами и брендами, в числе которых есть как
                        всемирно известные производители (Mango, Incity, SAVAGE, Tom Tailor, Adidas и другие),
                        так и дизайнерские марки, эксклюзивно представленные на Lorem.ua.
                        Мы сотрудничаем только с официальными представителями марок. Все товары,
                        поступающие к нам, имеют необходимые сертификаты.
                    </p>
                    <h4 className="second-about-h3">Доставка по всей Украине</h4>
                    <p className="second-about-p">
                        Lorem.ua — это европейский уровень сервиса.
                        Мы обеспечиваем быструю доставку товаров по всей стране.
                        Ваш заказ будет доставлен в любую точку Украины в течение 4-6 рабочих дней.
                        Вместе с ведущими логистическими операторами по доставке товаров в Украине
                                        — Meest Express и Нова Пошта— мы постоянно улучшаем наш сервис и делаем
                        все возможное, чтобы Вы получили Ваш заказ как можно скорее.
                        Доставка по всей Украине бесплатная при сумме заказа от 750 гривен.
                        Если сумма заказа менее 750 гривен, стоимость доставки составит 49
                        гривен при заказе через Meest Express и 39 грн при заказе на отделение службы доставки Нова Пошта.
                        Подпишитесь на нашу рассылку, чтобы первыми узнавать о новостях доставки,
                        а также о скидках и акциях на сайте Lorem.ua.
                    </p>
                    <h4 className="third-about-h3">Оплата и возврат</h4>
                    <p className="third-about-p">
                        Мы развиваемся и улучшаем наш сервис. На данный момент оплатить заказ можно наличными в момент доставки или банковской картой.
                        В ближайшее время мы представим и другие способы оплаты заказов.
                        Если доставленный товар вам не подошел, не понравился или имеет заводской брак, в течение 14 дней
                        (Все товары, купленные до 10 мая 2016 года,
                        можно вернуть в течение 60 дней с момента покупки) после доставки заказа вы можете вернуть его по почте.
                        Мы перечислим вам деньги в минимально возможные сроки после получения вашей посылки.
                        Благодаря Lamoda.ua покупать модные вещи стало проще, быстрее и комфортнее. Приятного шопинга!
                    </p>
                </div>
            </div>
        );
    }
}

ReactDOM.render(
  <MainPageCenter />,
  document.getElementById('main-page-center-component')
);