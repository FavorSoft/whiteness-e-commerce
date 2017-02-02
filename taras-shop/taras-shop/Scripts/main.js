$(function () {
    $("#accordion").accordion(
        {
            collapsible: true,
            animate: 150,
            heightStyle: "content"
        }
    );
});

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

$(document).ready(function () {
    $(".why-reg").click(function () {
        if ($(".why-reg-content").html() == "") {
            var ulToAppend = "<h5>После регистрации:</h5>"
                + "<ul class='after-reg'>"
                    + "<li>Вы используете привилегии (VIP-скидки, ночные распродажи и т.д.)</li>"
                    + "<li>Для зарегистрированных Клиентов есть возможность бесплатной доставки</li>"
                    + "<li>Вы имеете доступ к истории своих покупок и хранению избранных товаров</li>"
                + "</ul>";
            $(ulToAppend).appendTo(".why-reg-content");
        }
        else {
            $(".why-reg-content").html("");
        }
    });

});