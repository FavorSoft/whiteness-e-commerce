jQuery('<div class="quantity-nav"><div class="quantity-button quantity-up">+</div><div class="quantity-button quantity-down">-</div></div>').insertAfter('.quantity input');
jQuery('.quantity').each(function () {
    var spinner = jQuery(this),
        input = spinner.find('input[type="number"]'),
        btnUp = spinner.find('.quantity-up'),
        btnDown = spinner.find('.quantity-down'),
        min = input.attr('min'),
        max = input.attr('max');

    btnUp.click(function () {
        var oldValue = parseFloat(input.val());
        if (oldValue >= max) {
            var newVal = oldValue;
        } else {
            var newVal = oldValue + 1;
        }
        spinner.find("input").val(newVal);
        spinner.find("input").trigger("change");
    });

    btnDown.click(function () {
        var oldValue = parseFloat(input.val());
        if (oldValue <= min) {
            var newVal = oldValue;
        } else {
            var newVal = oldValue - 1;
        }
        spinner.find("input").val(newVal);
        spinner.find("input").trigger("change");
    });
});

$(document).ready(function () {
    
    /*
     * Search sliding and hiding function.
     */
    $(function () {
        $(".search").click(function () {
            $(".search-input").animate({ width: 'toggle' }, 400);
        })
    });

    $(function () {
        $('#imageGallery').lightSlider({
            gallery: true,
            item: 1,
            loop: true,
            thumbItem: 9,
            slideMargin: 0,
            enableDrag: false,
            currentPagerPosition: 'right',
            onSliderLoad: function (el) {
                el.lightGallery({
                    selector: '#imageGallery .lslide'
                });
            }
        });
    });

    /*
     * History back on button click on 404 page.
     */
    (function () {
        $("#go-back").on("click", function () {
            window.history.back();
        });
    });

    /*
     * Provide jquery ui accordion on sidebar categories.
     */
    $(function () {
        $(".accordion").accordion(
            {
                collapsible: true,
                animate: 150,
                heightStyle: "content",
                active: false
            }
        );
        $('.accordion').removeClass('ui-widget');
        $('.accordion').removeClass('ui-helper-reset');
        $('.accordion').removeClass('ui-accordion');
    });

    /*
     * Provide jquery ui accordion on item page.
     */
    $(function () {
        $("#item-accordion").accordion(
            {
                collapsible: true,
                animate: 150,
                heightStyle: "content",
                active: false
            }
        );
        $('#item-accordion').removeClass('ui-widget');
        $('#item-accordion').removeClass('ui-helper-reset');
        $('#item-accordion').removeClass('ui-accordion');
    });

    /*
     * Contain accordion condition check and provide fucntionality or delete.
     */

    $("#male-radio").click(function () {
        $("#Sex").val($("#male-radio").attr("for"));
    });

    $("#female-radio").click(function () {
        $("#Sex").val($("#female-radio").attr("for"));
    });

    function accordionCondition(width) {
        if (width < 975) {
            $(".sidebar-mobile-accordion").accordion(
                {
                    collapsible: true,
                    animate: 150,
                    heightStyle: "content",
                    active: false
                }
            );
            $('.sidebar-mobile-accordion').removeClass('ui-widget');
            $('.sidebar-mobile-accordion').removeClass('ui-helper-reset');
            $('.sidebar-mobile-accordion').removeClass('ui-accordion');
            $('.sidebar-mobile-accordion h4').removeClass('ui-accordion-header');
            $('.sidebar-mobile-accordion h4').removeClass('ui-state-default');
            $('.sidebar-mobile-accordion h4').removeClass('ui-corner-all');
            $('.sidebar-mobile-accordion h4').removeClass('ui-accordion-icons');
        }
        else if ($(".side-catalog").hasClass("ui-accordion-header")) {
            $('.sidebar-mobile-accordion').accordion('destroy');
        }
    }

    /*
     * Adds jquery ui accordion to sidebar, when size of screen is small.
     */
    $(function isAccordion() {
        var $window = $(window);
        var width = $window.width();
        // Call func to check size and add or not accordion functionality when page loaded
        accordionCondition(width);
        // Call func to check size and add or not accordion functionality while resizing
        setInterval(function () {
            if ((width != $window.width())) {
                width = $window.width();
                accordionCondition(width);
            }
        }, 100);
    });

    /*
     * Show or hide radio buttons on item page or preview.
     */
    $("#size-toggle").click(function () {
        $(".append-radio").toggleClass("radio-show")
    });



    $("#login-result").bind("DOMSubtreeModified", function () {
        if ($("#successAuth").length != 0)
        {
            window.location.reload();
        }
    });
    
    $("#basket-result").bind("DOMSubtreeModified", function () {
        if ($("#successOrder").length != 0) {
            
        }
    });

    function getBasketInfo() {
        $.ajax({
            method: "GET",
            url: "Home/ItemOnBasket",
            success: function (data) {
                console.log(data);
            }
        })
            .done(function (msg) {
                alert("Data Saved: " + msg);
            });
    }
});

$("#shopping-local-items").ready(function () {
    renderLocalShoppingItems();
});

$("#shopping-global-items").ready(function () {
    renderGlobalShoppingItems();
});

function renderLocalShoppingItems() {
    $("#shopping-local-items").html("");
    var tmp = localStorage.getItem("items");
    
    $.get("/Home/GetItemsByBasket", { json: tmp }, (response) => {
        $("#shopping-local-items").html(response);
    });
}
function renderGlobalShoppingItems() {
    $("#shopping-global-items").html("");
    $.get("/Home/GetItemsFromBasket", { }, (response) => {
        $("#shopping-global-items").html(response);
    });
}


function changeAmount(unitId, size) {
    var str = "#" + size + unitId;
    var input = $(str);
    var amount = input.val();
    $.get("/Home/ChangeAmount", { unitId: unitId, size: size, amount: amount }, (response) => {
        renderGlobalShoppingItems();
    });

}
function changeLocalAmount(unitId, size) {
    var items = JSON.parse(localStorage.getItem("items"));
    var str = "#" + size + unitId;
    var input = $(str);
    var amount = input.val();

    for (var i = 0; i < items.length; i++) {
        if (items[i].Id === unitId && items[i].Size === size) {
            items[i].Amount = amount;
        }
    }
    localStorage.setItem("items", JSON.stringify(items));

    renderLocalShoppingItems();
}

function addToBasket() {
    var id = $("#unitId").val();
    var size = $("#sizes-radio input:checked").val();
    $.ajax({
        method: "POST",
        url: "/Home/AddToBasket",
        data: { Id: id, size: size },
        success: function (data) {
            $("#basket-result").html(data);
        }
    });
}
function deleteFromCart(id, size) {
    var items = JSON.parse(localStorage.getItem("items"));
    
    items = items.filter(x => x.Id !== id || x.Size !== size);
    
    localStorage.setItem("items", JSON.stringify(items));

    renderLocalShoppingItems();
}

function addToCart(unitId) {
    var items = JSON.parse(localStorage.getItem("items"));
    var id = unitId;
    var size = $("#sizes-radio input:checked").val();
    var amount = 1;
    var item = { Id: id, Size: size, Amount: amount };

    var done = document.createElement("div");
    var addButton = document.querySelector("#add-to-cart");
    var isEqual = true;
    
    if (items) {
        items.forEach(function (eachItem, i, arr) {
            if (_.isEqual(eachItem, item)) {
                isEqual = false
            }
        });

        if (isEqual) {
            var doneText = document.createTextNode("done");

            done.appendChild(doneText);
            addButton.parentNode.replaceChild(done, addButton);
            done.setAttribute("class", "material-icons done-icon");

            if (items) {
                items.push(item);
                localStorage.setItem("items", JSON.stringify(items));
            }
            else {
                items = [];
                items.push(item);
                localStorage.setItem("items", JSON.stringify(items));
            }
        }
        else {
            var doneTextFail = document.createTextNode("Такой товар уже добавлен в корзину");
            done.appendChild(doneTextFail);
            done.setAttribute("class", "material-icons done-fail");
            addButton.parentNode.replaceChild(done, addButton);
        }
    }
    else {
        var doneText = document.createTextNode("done");

        done.appendChild(doneText);
        addButton.parentNode.replaceChild(done, addButton);
        done.setAttribute("class", "material-icons done-icon");

        if (items) {
            items.push(item);
            localStorage.setItem("items", JSON.stringify(items));
        }
        else {
            items = [];
            items.push(item);
            localStorage.setItem("items", JSON.stringify(items));
        }
    }
}