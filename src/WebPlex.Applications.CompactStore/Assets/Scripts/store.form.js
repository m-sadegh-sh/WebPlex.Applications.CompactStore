function webPlexFormOnBegin() {
    var $this = $(this);
    if ($this.attr("disabled") === "disabled")
        return false;

    $this.attr("disabled", "disabled");

    $this.find(".WebPlex-Button").on("click", function() {
        return false;
    });

    return true;
}

function webPlexFormOnSuccess(data) {
    var $this = $(this);

    switch (data.Type) {
        case 0:
            webPlexShowFailureAsyncIndicator(data.Message);
            $this.removeAttr("disabled");

            break;

        case 1:
            webPlexShowSuccessAsyncIndicator(data.Message);

            break;
    }

    if (data.ReturnUrl) {
        setTimeout(function() {
            window.location = data.ReturnUrl;
        }, 2500);
    }
}

function webPlexFormOnFailure() {
    var $this = $(this);

    $this.removeAttr("disabled");
    $this.find(".WebPlex-Button").off("click");
    webPlexShowFailureAsyncIndicator();
}

function webPlexFormOnComplete() {
    refreshCentrableElements();
    refreshSwitch();
}