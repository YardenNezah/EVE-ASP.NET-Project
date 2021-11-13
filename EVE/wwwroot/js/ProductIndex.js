
$(function () {

    var hasMoreRecords = true;
    var mode = 0;
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
                    hasMoreRecords = false; 
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







