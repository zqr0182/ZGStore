function processCartData(data) {
    var targetTr = $("#tr" + data.ProductId);
    var targetTotal = $("#total");
    var summary = $("#summary");
    var checkoutLink = $("#checkout");
    
    if (data.Quantity < 1) {
        targetTr.empty();
    }

    targetTotal.text(data.CartTotalValue);

    summary.empty();
    if (data.NumberOfItems < 1) {
        summary.text("0 item(s)");
        checkoutLink.hide();
    } else{
        summary.text(data.NumberOfItems + " item(s), " + data.CartTotalValue);
        checkoutLink.show();
    }
}