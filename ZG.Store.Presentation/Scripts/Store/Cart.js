function processCartData(data) {
    var targetTr = $("#tr" + data.ProductId);
    var targetTotal = $("#total");
    var summary = $("#summary");
    
    if (data.Quantity < 1) {
        targetTr.empty();
    }

    targetTotal.text(data.CartTotalValue);

    summary.empty();
    if (data.Quantity < 1) {
        summary.text("0 item(s)");
    } else{
        summary.text(data.Quantity + " item(s), " + data.CartTotalValue);
    }
}