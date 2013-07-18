$(function () {
    var categoryDropdown = $('#category');
    categoryDropdown.change(function (){
        var selectedOption = categoryDropdown.find('option:selected');
        var selectCategory = $(selectedOption).text();
        
        getProducts($(selectedOption).data('url'));
    });

    var getProducts = function (url) {
        $.ajax({
            url: url,
            type: 'GET',
            cache: false,
            success: function (result) {
                createProductDropdown(result);
            },
            error: function () {
                alert('error')
            }
        });
    }

    var createProductDropdown = function (products) {
        alert('aaa');
    }

    getProducts('products');
});