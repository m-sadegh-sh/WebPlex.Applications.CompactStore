var $cartSwitcher = null;
var $cartButton = null;
var $cartItemsCount = null;
var $cartPlaceholder = null;
var ignoreCartOpenValidation = false;

$(function() {
    $cartSwitcher = $("#WebPlex-Cart");
    $cartButton = $cartSwitcher.children(".WebPlex-CartButton");
    $cartItemsCount = $cartSwitcher.find("#WebPlex-CartItemsCount");
    $cartPlaceholder = $("#WebPlex-CartPlaceholder");
});

function webPlexOpenCartOnBegin() {
    if (ignoreCartOpenValidation) {
        ignoreCartOpenValidation = false;
        return true;
    }

    if ($cartSwitcher.attr("disabled") === "disabled")
        return false;

    var notOpenedYet = !$cartSwitcher.data("cart-opened");
    webPlexResetCartState(notOpenedYet);

    if (notOpenedYet)
        $cartSwitcher.attr("disabled", "disabled");

    return notOpenedYet;
}

function webPlexOpenCartOnSuccess() {
    $cartSwitcher.data("cart-opened", true);

    if ($cartSwitcher.is(":focus")) {
        $cartSwitcher.addClass("WebPlex-Opened");
        $cartButton.addClass("WebPlex-Hide");
        $cartPlaceholder.addClass("WebPlex-Opened");
    }
}

function webPlexOpenCartOnFailure() {
    webPlexShowFailureAsyncIndicator();
}

function webPlexOpenCartOnComplete() {
    $cartSwitcher.removeAttr("disabled");
}

function webPlexAddToCartOnBegin() {
    if ($(this).attr("disabled") === "disabled")
        return false;

    $(this).attr("disabled", "disabled");

    return true;
}

function webPlexAddToCartOnSuccess(data) {
    switch (data.Type) {
        case 0:
            webPlexShowFailureAsyncIndicator(data.Message);

            break;

        case 1:
            webPlexShowSuccessAsyncIndicator(data.Message);
            webPlexUpdateCartState(data.CartItemsCount);

            break;
    }
}

function webPlexAddToCartOnFailure() {
    webPlexShowFailureAsyncIndicator();
}

function webPlexAddToCartOnComplete() {
    $(this).removeAttr("disabled");

    if (!$cartSwitcher.hasClass("WebPlex-Opened")) {
        $cartButton.removeClass("WebPlex-Hide");
        $cartPlaceholder.removeClass("WebPlex-Opened");
    }
}

function webPlexRemoveFromCartOnBegin() {
    if ($(this).attr("disabled") === "disabled")
        return false;

    $(this).attr("disabled", "disabled");

    return true;
}

function webPlexRemoveFromCartOnSuccess(data) {
    switch (data.Type) {
        case 0:
            webPlexShowFailureAsyncIndicator(data.Message);

            break;

        case 1:
            webPlexShowSuccessAsyncIndicator(data.Message);
            webPlexUpdateCartState(data.CartItemsCount);

            break;
    }
}

function webPlexRemoveFromCartOnFailure() {
    webPlexShowFailureAsyncIndicator();
}

function webPlexRemoveFromCartOnComplete() {
    $(this).removeAttr("disabled");
}

function webPlexSubmitOrderOnBegin() {
    var $this = $(this);
    if ($this.attr("disabled") === "disabled")
        return false;

    $this.attr("disabled", "disabled");

    return true;
}

function webPlexSubmitOrderOnSuccess(data) {
    switch (data.Type) {
        case 0:
            $(this).removeAttr("disabled");
            webPlexShowFailureAsyncIndicator(data.Message);

            if (data.ReturnUrl) {
                setTimeout(function() {
                    window.location = data.ReturnUrl;
                }, 2500);
            }

            break;

        case 1:
            webPlexShowSuccessAsyncIndicator(data.Message);

            setTimeout(function() {
                window.location = data.ReturnUrl;
            }, 2500);

            break;
    }
}

function webPlexSubmitOrderOnFailure() {
    $(this).removeAttr("disabled");
    webPlexShowFailureAsyncIndicator();
}

function webPlexSubmitOrderOnComplete() {
}

function webPlexResetCartState(hardReset) {
    if (hardReset) {
        $cartSwitcher.data("cart-opened", false);
        $cartSwitcher.removeClass("WebPlex-Opened");
        $cartButton.removeClass("WebPlex-Hide");
        $cartPlaceholder.removeClass("WebPlex-Opened");
    } else {
        $cartSwitcher.toggleClass("WebPlex-Opened");
        $cartButton.toggleClass("WebPlex-Hide");
        $cartPlaceholder.toggleClass("WebPlex-Opened");
    }
}

function webPlexUpdateCartState(cartItemsCount) {
    setTimeout(function() {
        $cartItemsCount.text(cartItemsCount);

        if ($cartSwitcher.hasClass("WebPlex-Opened")) {
            ignoreCartOpenValidation = true;
            $cartSwitcher.trigger("click");
        } else
            webPlexResetCartState(true);
    }, 1000);
}