$(document).ready(function () {

    /*
     * Provide jquery ui accordion on sidebar categories.
     */
    $(function () {
        $("#accordion").accordion(
            {
                collapsible: true,
                animate: 150,
                heightStyle: "content"
            }
        );
        $('#accordion').removeClass('ui-widget');
        $('#accordion').removeClass('ui-helper-reset');
        $('#accordion').removeClass('ui-accordion');
    });

    /*
     * Provide jquery ui accordion on item page.
     */
    $(function () {
        $("#item-accordion").accordion(
            {
                collapsible: true,
                animate: 150,
                heightStyle: "content"
            }
        );
        $('#item-accordion').removeClass('ui-widget');
        $('#item-accordion').removeClass('ui-helper-reset');
        $('#item-accordion').removeClass('ui-accordion');
    });

    /*
     * Adds jquery ui accordion to sidebar, when size of screen is small.
     */
    $(function () {
        var $window = $(window);
        var width = $window.width();

        setInterval(function () {
            if ((width != $window.width())) {
                width = $window.width();
                console.log("resized!");
                if (width < 994) {
                    $(".sidebar-mobile-accordion").accordion(
                        {
                            collapsible: true,
                            animate: 150,
                            heightStyle: "content"
                        }
                    );
                    $('.sidebar-mobile-accordion').removeClass('ui-widget');
                    $('.sidebar-mobile-accordion').removeClass('ui-helper-reset');
                    $('.sidebar-mobile-accordion').removeClass('ui-accordion');
                }
                else {
                    $('.sidebar-mobile-accordion').accordion('destroy');
                }
            }
        }, 100);
    });

    /*
     * Function provide jquery ui range slider.
     */
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
    });

    /*
     * Show or hide radio buttons on item page or preview.
     */
    $("#size-toggle").click(function () {
        $(".append-radio").toggleClass("radio-show")
    });

    /*
     * Andrew? write comments!!!!
     */


    $.get("home/load", function (data, status) {
        console.log(status);
        console.log(data);
    });

    $.ajax({
        method: "get",
        url: "Load"
    }).done(function (data) {
        console.log(data);
    });

    $("#create").click(function AddUnit() {
        var title = $("#title").val();
        var producer = $("#producer").val();
        var categoryType = $('#category-type option:selected').val();
        var category = $('#category option:selected').val();
        var price = $("#price").val();
        var amount = $("#count").val();
        var size = $("#size").val();
        var material = $("#material").val();
        var description = $("#description").val();

        
        if (window.FormData !== undefined) {
            var files = document.getElementById('images').files;
            var data = new FormData();
            for (var x = 0; x < files.length; x++) {
                data.append("file" + x, files[x]);
            }
            $.ajax({
                type: "POST",
                url: "UploadPhoto",
                contentType: false,
                processData: false,
                data: data,
                success: function (result) {
                    console.log(result);
                },
                error: function (xhr, status, p3, p4) {
                    var err = "Error " + " " + status + " " + p3 + " " + p4;
                    if (xhr.responseText && xhr.responseText[0] == "{")
                        err = JSON.parse(xhr.responseText).Message;
                    console.log(err);
                }
            });
        } else {
            alert("This browser doesn't support HTML5 file uploads!");

        }


        $.ajax({
            method: "post",
            processData: false,
            url: "AddUnit",
            data: {
                title: title,
                producer: producer,
                categoryType: categoryType,
                category: category,
                price: price,
                amount: amount,
                size: size,
                material: material,
                description: description
            }

        }).done(function (data) {
            console.log(data);
        });
    });
});