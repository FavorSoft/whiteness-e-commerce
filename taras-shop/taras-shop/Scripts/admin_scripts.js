function AddNews() {
    alert($("#filecount").val())
    var $fileUpload = $("#filecount");
    if (parseInt($fileUpload.get(0).files.length) >= 10) {
        alert("Ви можете завантажити до 10 файлів");
    }
    $.ajax(
       {
           type: "Post",
           url: "/Admin/AddNews",
           data: {
               Title: $("#title").val(), Description: $("#description").val(), Images: $("#filecount").val()
           },
           success:
               function (data) {
                   if (data == "True") {
                       $(".add-block").append("<h2>Added news</h2>");
                       var carTag = $(".allCars");
                       carTag.html(data);
                   }
               }
       }
    );

}
