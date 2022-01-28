var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url":"/Admin/Clth/GetAll"
        },
        "columns": [
            { "data": "designer", "width": "15%" },
            { "data": "description", "width": "15%" },
            { "data": "composition", "width": "15%" },
            { "data": "size", "width": "15%" },
            { "data": "isAvailable", "width": "15%" },
            { "data": "listPrice", "width": "15%" },
            { "data": "price", "width": "15%" },
            { "data": "category.name", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                                            <div class="w-75 btn-group" role="group">
                        <a  href="/Admin/Product/Upsert?id=${data}"
                        class="btn btn-primary mx-2"> <i class="bi bi-pencil-square"></i>Edit</a>
                        <a
                        class="btn btn-danger mx-2"> <i class="bi bi-x-circle"></i>Delete</a>
                    </div>
                    `
                },
            }
        ]
    });
}