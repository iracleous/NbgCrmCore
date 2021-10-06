// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    console.log("ready");

}
);


function toggle() {
    $("#responseDiv").toggle();
}


function doWorkWithUser() {

    let Url = 'https://localhost:44369/api/user';
    let Method = 'GET';


    $.ajax({
        url: Url,
        method: Method
    }).done(response => {


        console = "<table  class='table'>"
            + " <thead><tr><th> firstName </th><th> lastName  </th>   <th> baskets  </th> </tr> </thead> <tbody>";
        $.each(response, function (key, value) {
            console += '<tr> <td>' + value.firstName + '</td><td>' + value.lastName + '</td>' +
                '<td>' + value.baskets + '</td> </tr>';
        });
        console += "</tbody></table>";

        $('#responseDiv').html(console);

    }).fail(failure => {

        $('#responseDiv').html('Error in the communication')
    }) ;
}



function doAddUser() {
    let Url = 'https://localhost:44369/api/user';
    let Method = 'POST';
    let Data = JSON.stringify( {
        firstName: $('#firstName').val(),
        lastName: $('#lastName').val(),
        username: $('#username').val(),
        email: $('#email').val(),
        password: $('#password').val(),
        address: $('#address').val()
    });

    $.ajax(
        {
            url: Url,
            method: Method,
            contentType: 'application/json',
            data: Data

        })
        .done(response => {
            $("#addResponseDiv").html(JSON.stringify(response.returnData));
        })
        .fail(failure => {
            $("#addResponseDiv").html(JSON.stringify(failure));
        });





}


