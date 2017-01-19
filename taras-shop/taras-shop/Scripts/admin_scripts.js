
function AddNews() {
    var $filesUpload = $("#filecount");
    if (parseInt($filesUpload.get(0).files.length) > 10) {
        alert("Ви можете завантажити до 10 файлів");
    }
    else {
        $.ajax(
           {
               type: "Post",
               url: "/Admin/AddNewsInfo",
               data: {
                   title: $("#title").val(), description: $("#description").val()
               },
               success:
                   function (data) {

                       alert("data ok: " + data);
                       //$("#myModal").modal({ backdrop: true });

                   },
               error: function (xhr, status, error) {
                   console.log(status);
                   console.log(error);
                   $("#myModal").modal({ backdrop: true });
               }
           }
        );
        var filesData = new FormData();

        for (var i = 0; i < $filesUpload.get(0).files.length; i++) {
            filesData.append("file" + i, $filesUpload[i]);
        }
        $.ajax(
                   {
                       type: "Post",
                       url: '@Url.Action("AddNewsFoto", "Admin")',
                       data: filesData,
                       success:
                           function (data) {
                               alert("foto ok: " + data);
                           },
                       error: function (xhr, status, error) {
                           console.log(status);
                           console.log(error);
                           $("#myModal").modal({ backdrop: true });
                       }
                   }
                );

    }
}
