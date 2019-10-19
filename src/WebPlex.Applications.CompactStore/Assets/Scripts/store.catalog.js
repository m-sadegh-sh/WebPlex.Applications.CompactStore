var $itemsPlaceholder = null;

$(function() {
    $itemsPlaceholder = $("#WebPlex-ItemsPlaceholder");
});

function webPlexLoadItemsOnBegin() {
    $(this).parent().addClass("WebPlex-Removable");
}

function webPlexLoadItemsOnSuccess() {
    $(".WebPlex-LoadMore.WebPlex-Removable").remove();
    $(".WebPlex-LoadMore").addClass("WebPlex-Removable");

    var maxScrollAmount = 565;
    var scrollTimeout = 1;
    var scrollAmount = 5;
    var currentAmount = 0;

    var scrollMe = function() {
        window.scroll(window.screenX, window.scrollY + scrollAmount);
        currentAmount += scrollAmount;

        if (currentAmount <= maxScrollAmount)
            setTimeout(scrollMe, scrollTimeout);
    };

    scrollMe();

    var step = 250;
    var timeout = maxScrollAmount + (step / 2);

    var $products = $itemsPlaceholder.children(".WebPlex-Product").not(".WebPlex-Visible");
    var invisibleProductsCount = $products.length;

    $products.each(function(index) {
        var $this = $(this);

        setTimeout(function() {
            $this.addClass("WebPlex-Visible");

            if (index === invisibleProductsCount - 1)
                $(".WebPlex-LoadMore").removeClass("WebPlex-Removable");
        }, timeout);

        timeout += step;
    });
}

function webPlexLoadItemsOnFailure() {
    $(".WebPlex-LoadMore").removeClass("WebPlex-Removable");
    webPlexShowFailureAsyncIndicator();
}

function webPlexLoadItemsOnComplete() {
}