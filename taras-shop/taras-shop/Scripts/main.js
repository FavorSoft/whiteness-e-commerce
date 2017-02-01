$( function() {
    $( "#accordion" ).accordion(
        {
            collapsible: true,
            animate: 150,
            heightStyle: "content"
        }
    );
} );

$(function () {
    $("#slider").slider({
        range: true,
        min: 0,
        max: 500,
        values: [75, 300],
        slide: function (event, ui) {
            $("#amount").val("$" + ui.values[0] + " - $" + ui.values[1]);
        }
    });
    $("#amount").val("$" + $("#slider").slider("values", 0) +
      " - $" + $("#slider").slider("values", 1));
    $("#amount").val("$" + $("#slider").slider("values", 0) +
      " - $" + $("#slider").slider("values", 1));
    $('#accordion').removeClass('ui-widget');
    $('#accordion').removeClass('ui-helper-reset');
    $('#accordion').removeClass('ui-accordion');
});

window.onload = function () {
    console.log("Hello111");
    function appendUl() {
        console.log("hello");
        var ulToAppend = "<h5>После регистрации:</h5>"
        + "<ul class='after-reg'>"
        + "<li>Вы используете привилегии (VIP-скидки, ночные распродажи и т.д.)</li>"
        + "<li>Для зарегистрированных Клиентов есть возможность бесплатной доставки</li>"
        + "<li>Вы имеете доступ к истории своих покупок и хранению избранных товаров</li>"
        + "</ul>";
        $(".why-reg-block").append(ulToAppend);
    }
    var el = document.querySelector(".why-reg");
    el.addEventListener("click", appendUl, false);
}

$(document).ready(function () {
    console.log("Hello1");
    $(".why-reg").click(function () {
        console.log("Hello");
        var ulToAppend = "<h5>После регистрации:</h5>"
            + "<ul class='after-reg'>"
                + "<li>Вы используете привилегии (VIP-скидки, ночные распродажи и т.д.)</li>"
                + "<li>Для зарегистрированных Клиентов есть возможность бесплатной доставки</li>"
                + "<li>Вы имеете доступ к истории своих покупок и хранению избранных товаров</li>"
            + "</ul>";

        $(ulToAppend).appendTo(".why-reg-block");
    });
});

var clickSpan = function(){
    console.log("Hello");
    var ulToAppend = "<h5>После регистрации:</h5>"
        + "<ul class='after-reg'>"
            + "<li>Вы используете привилегии (VIP-скидки, ночные распродажи и т.д.)</li>"
            + "<li>Для зарегистрированных Клиентов есть возможность бесплатной доставки</li>"
            + "<li>Вы имеете доступ к истории своих покупок и хранению избранных товаров</li>"
        + "</ul>";

    $(ulToAppend).appendTo(".why-reg-block");
}
