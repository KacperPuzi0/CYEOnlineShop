﻿var dataTable;

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
                        <a  href="/Admin/Clth/Upsert?id=${data}" 
                        class="btn btn-primary mx-2"> <i class="bi bi-pencil-square"></i>Edit</a>
                        <a onClick=Delete('/Admin/Clth/Delete/${data}') 
                        class="btn btn-danger mx-2"> <i class="bi bi-x-circle"></i>Delete</a>
                    </div>
                    `
                },
            }
        ]
    });
}

function Delete(url) {
    Swal.fire({
        title: 'Jesteś pewny?',
        text: "Nie będzie możliwości powrotu!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Tak!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'Delete',
                success: function (data) {
                    if (data.success) {
                        dataTable.ajax.reload();
                        toastr.success(data.message);
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            })
        }
    })
}