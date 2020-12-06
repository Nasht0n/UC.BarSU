$("body").on("click", "#btnIARLifeCycleAdd", function () {

    var model = {
        ActId: $("#ActId").val(),
        Title: $("#Title").val(),
        Message: $("#Message").val()
    };

    var json = JSON.stringify(model);
    $.ajax({
        type: "POST",
        url: "/IAR/Message",
        data: json,
        contentType: 'application/json; charset=utf-8',
        dataType: "json",
        traditional: true,
        success: function (data) {
            location.reload();
        }
    });
});