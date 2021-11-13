// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
//Made By: David Manshari! at 4am :(

// Write your JavaScript code.


$(function () {

    var skipCount = 0;
    var takeCount = 6;
    var hasMoreRecords = true;
    var mode = 0;
    var brand = 0;
    var category = 0;
    var sort = "newest";
    showProducts();



    function showProducts() {
        $.ajax({
            url: '/Products/getProducts',
            data: { modeId: mode, categoryId: category, sort: sort },
            success: function (data) {
                if (data == 0) {
                    $('#productInsertion').html("");
                    hasMoreRecords = false; // signal no more records to display
                    $('#ShowMoreProducts').text("No More Products To Show").css('background-color', 'red');
                }
                else {
                    $('#productInsertion').html("");
                    $('#resultsProdcuts').tmpl(data).appendTo('#productInsertion').hide().fadeIn(1000);
                }
            },
            error: function () {
                alert("error");
            }
        });
    }

    $(".select").on('change', function () {  //the dropbox select
        category = $("#CategoryId").val();
        sort = $("#Sort").val();
        hasMoreRecords = true;
        $(".col-xl-4").remove(); //remove other products
        showProducts();



    });


});







