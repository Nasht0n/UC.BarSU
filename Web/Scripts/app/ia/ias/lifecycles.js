$("body").on("click", "#btnIASLifeCycleAdd", function () {

    var model = {
        ActId: $("#ActId").val(),
        Title: $("#Title").val(),
        Message: $("#Message").val()
    };

    var json = JSON.stringify(model);
    $.ajax({
        type: "POST",
        url: "/IAS/Message",
        data: json,
        contentType: 'application/json; charset=utf-8',
        dataType: "json",
        traditional: true,
        success: function (data) {
            location.reload();
        }
    });
});