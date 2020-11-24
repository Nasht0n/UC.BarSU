$('#Faculty').change(function () {
    var selectedFaculty = $("#Faculty").val();
    var departmentsSelect = $('#Department');
    departmentsSelect.empty();
    if (selectedFaculty != null && selectedFaculty != '') {
        console.log(selectedFaculty);
        let url = '@Url.Action("GetDepartments", "SP")';
        $.getJSON("/SP/GetDepartments", { faculty: selectedFaculty }, function (departments) {
            if (departments != null && !jQuery.isEmptyObject(departments)) {
                console.log("into Json");
                departmentsSelect.append($('<option/>', {
                    value: null,
                    text: ""
                }));
                $.each(departments, function (index, department) {
                    departmentsSelect.append($('<option/>', {
                        value: department.Value,
                        text: department.Text
                    }));
                });
            };
        });
    }
});