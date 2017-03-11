$(document).ready(function () {
    /*
     * Search sliding and hiding function.
     */
    $(function () {
        $(".search").click(function () {
            $(".search-input").animate({ width: 'toggle' }, 400);
        })
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
        else if($(".side-catalog").hasClass("ui-accordion-header")) {
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
        
    $("#create").click(function (event) {
        event.preventDefault();
        var title = $("#title").val();
        var producer = $("#producer").val();
        var categoryType = $('#category-type option:selected').val();
        var price = $("#price").val();
        var sizeXs = $("#size-xs:checked").val();
        var countXs = $("#count-xs").val();
        var sizeS = $("#size-s:checked").val();
        var countS = $("#count-s").val();
        var sizeM = $("#size-m:checked").val();
        var countM = $("#count-m").val();
        var sizeL = $("#size-l:checked").val();
        var countL = $("#count-l").val();
        var sizeXl = $("#size-xl:checked").val();
        var counXl = $("#count-xl").val();
        var material = $("#material").val();
        var description = $("#description").val();

        var sizes = [{exist: sizeXs, name: "XS"}, {exist: sizeS, name: "S"},
            {exist: sizeM, name: "M"}, {exist: sizeL, name: "L"},
            {exist: sizeXl, name: "XL"}];

        $('#item-preview-modal').modal();

        $("#title-on-modal").text(title);
        $("#item-type-on-modal").text($('#category option:selected').text());
        $("#price-now-on-modal").text(price + " грн");
        $("#modal-radio").html(function () {
            console.log(sizes);
            return sizes.map(function (size) {
                if (size.exist === "true") {
                    return (
                          "<li>"
                        + "    <input type='checkbox' id="+(size.name+"-option")+" name='selector' />"
                        + "    <label htmlFor=" + (size.name + "-option") + ">"+size.name+"</label>"
                        + "    <div class='check'></div>"
                        + "</li>"
                    );
                }
            }.bind(this)); 
        });
        $(".details-modal-part").html("<button id='apply-posting' class='frequent-button'>Запустить товар</button>");
        //var queryString = $('#addUnitForm').formSerialize();
        //$("#apply-posting").click(function () {
        //    console.log("i am here!");
        //    $.post('', queryString, function (data) {
        //        alert("I appeared!")
        //    });
        //});
    });
});