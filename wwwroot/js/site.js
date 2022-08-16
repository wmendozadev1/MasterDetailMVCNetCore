// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


var select = document.getElementsByClassName("select")[0];
    select.addEventListener("change", function (event) {

        //console.log(event);

        var table;
        table = document.getElementById('DetailTable');

        var value = event.target.value;
        if (value == 1) { //1	Numero
            table.rows[1].children[2].children[0].setAttribute("disabled", "disabled");
            table.rows[1].children[1].children[0].removeAttribute("disabled", "disabled");
        }
        else if (value == 2) //2	Cumple
        {
            table.rows[1].children[2].children[0].removeAttribute("disabled", "disabled");
            table.rows[1].children[1].children[0].setAttribute("disabled", "disabled");
        }

        //table.rows[1].children[4].children[0].setAttribute("disabled", "disabled");


    });


//Header_Detail[0].Header_Detail_Quantity

var input = document.getElementsByName("Header_Detail[0].Header_Detail_Quantity")[0];
input.addEventListener("change", function (event) {

    var selectOptNumber = document.getElementsByName("Header_Detail[0].Header_Detail_Number")[0];
    var OptNumberValue = selectOptNumber.value;



    var value = event.target.value;

    var selectOptEstimated = document.getElementsByName("Header_Detail[0].Header_Detail_Estimated")[0];
    selectOptEstimated.value = value * OptNumberValue;


})


