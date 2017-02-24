$(document).ready(function () {

    /*
     * Privide main page carousel functionality.
     */
    $('.owl-carousel').owlCarousel({
        items: 1,
        margin: 10,
        autoHeight: true,
        nav: true,
        loop: true,
        autoplay: true,
        autoplayTimeout: 5000,
        autoplaySpeed: 1000,
        navSpeed: 1000,
        dotsSpeed: 1000
    });

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
    //(function () {
    //    $("#go-back").on("click", function () {
    //        window.history.back();
    //    });
    //});

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
        console.log("Item accordin");
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

    //Getting data of Home/Index
    $.ajax({
        method: "get",
        url: "Home/Load"
    }).done(function (data) {
        console.log(data);
    });
    



    /*
    * Function for send unit to server
    */
    $("#create").click(function AddUnit() {
        //  variable for saving photo names
        
        
        if (window.FormData !== undefined) {
            // Getting files from form
            var files = document.getElementById('images').files;
            var sendData= new FormData();
            for (var x = 0; x < files.length; x++) {
                sendData.append("file" + x, files[x]);
            }
            // ajax for upload photos
            $.ajax({
                type: "POST",
                url: "UploadPhoto",
                contentType: false,
                processData: false,
                data: sendData,
                success: function (result) {
                    //this result - photo names, that was uploaded
                    for (var i in result) {
                        $("#calousel-indicators-on-modal").append('<li data-target=\'#carousel-custom\' data-slide-to=\'0\' class=\'active\'><img src=\'../Content/images/Units/' + result[i] + '.png\' alt=\'1\' /></li>');
                    }
                    console.log(images);

                    for (var i in result) {
                        $("#carousel-on-modal").append('<div class=\'item active\'><img src=\'../Content/images/Units/' + result[i] + '.png\' alt=\'\' /></div>');
                    }
                    $('#item-preview-modal').modal();

                    //getting values other parameters of unit from form
                    var title = $("#title").val();
                    var producer = $("#producer").val();
                    var categoryType = $('#category-type option:selected').val();
                    var category = $('#category option:selected').val();
                    var price = $("#price").val();
                    var amount = $("#count").val();
                    var size = $("#size").val();
                    var material = $("#material").val();
                    var description = $("#description").val();


                    //work with modal window
                    $("#title-on-modal").text(title);
                    $("#item-type-on-modal").text($('#category option:selected').text());
                    $("#price-now-on-modal").text(price + " грн");
                    $("#carousel-on-modal").html("");   

                    //sending all data to server
                    console.log("hello ajax");
                    $.ajax({
                        method: "POST",
                        url: "AddUnit",
                        contentType: 'application/json',
                        data: JSON.stringify({
                            title: title,
                            producer: producer,
                            categoryType: categoryType,
                            category: category,
                            price: price,
                            amount: amount,
                            size: size,
                            material: material,
                            description: description,
                            images: result
                        }),
                        success:function(data){
                            console.log(data);
                        }
                    }).done(function (data) {
                        console.log(data);
                    });
                    console.log("good bye ajax");
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
    });
});