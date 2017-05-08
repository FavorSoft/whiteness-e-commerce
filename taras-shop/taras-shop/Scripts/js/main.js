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
        if ($("#successAuth").length != 0) {
            window.location.reload();
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
    

    //$.ajax({
    //    method: "GET",
    //    url: "Home/GetItemsByFilter",
    //    success: function (data) {
    //        console.log(data);
    //    }
    //})
    //    .done(function (msg) {
    //        alert("Data Saved: " + msg);
    //    });


    // I'll be back. okay?
    //$("#create1").click(function (event) {
    //    event.preventDefault();
    //    var title = $("#title").val();
    //    var producer = $("#producer").val();
    //    var categoryType = $('#category-type option:selected').val();
    //    var price = $("#price").val();
    //    var sizeXs = $("#size-xs:checked").val();
    //    var countXs = $("#count-xs").val();
    //    var sizeS = $("#size-s:checked").val();
    //    var countS = $("#count-s").val();
    //    var sizeM = $("#size-m:checked").val();
    //    var countM = $("#count-m").val();
    //    var sizeL = $("#size-l:checked").val();
    //    var countL = $("#count-l").val();
    //    var sizeXl = $("#size-xl:checked").val();
    //    var counXl = $("#count-xl").val();
    //    var material = $("#material").val();
    //    var description = $("#description").val();

    //    var sizes = [{exist: sizeXs, name: "XS"}, {exist: sizeS, name: "S"},
    //        {exist: sizeM, name: "M"}, {exist: sizeL, name: "L"},
    //        {exist: sizeXl, name: "XL"}];

    //    $('#item-preview-modal').modal();

    //    $("#title-on-modal").text(title);
    //    $("#item-type-on-modal").text($('#category option:selected').text());
    //    $("#price-now-on-modal").text(price + " грн");
    //    $("#modal-radio").html(function () {
    //        console.log(sizes);
    //        return sizes.map(function (size) {
    //            if (size.exist === "true") {
    //                return (
    //                      "<li>"
    //                    + "    <input type='checkbox' id="+(size.name+"-option")+" name='selector' />"
    //                    + "    <label htmlFor=" + (size.name + "-option") + ">"+size.name+"</label>"
    //                    + "    <div class='check'></div>"
    //                    + "</li>"
    //                );
    //            }
    //        }.bind(this)); 
    //    });
    //    $(".details-modal-part").html("<button id='apply-posting' class='frequent-button'>Запустить товар</button>");
    //});
});

function addToBasket() {
    var id = $("#unitId").val();
    var size = $("#sizes-radio input:checked").val();
    $.ajax({
        method: "GET",
        url: "/Home/AddToBasket",
        data: { Id: id, size: size },
        success: function (data) {
            console.log(data);
        }
    })
        .done(function (msg) {
            alert("Data Saved: " + msg);
        });
}

function addToCart(item) {
    var items = JSON.parse(localStorage.getItem("items"));
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