function processCartData(data) {
    var targetTr = $("#tr" + data.ProductId);
    var targetTotal= $("#total");
    
    if (data.Quantity < 1) {
        targetTr.empty();
    }

    targetTotal.text(data.CartTotalValue);
}