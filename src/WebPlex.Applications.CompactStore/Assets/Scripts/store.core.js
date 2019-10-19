function getPlaceholder($element) {
    return $element.data("placeholder") ? $($element.data("placeholder")) : $element.next(".WebPlex-SubLinksPlaceholder");
}

function layoutVerticallyCentered($element, excludedHeight) {
    $element.css({ paddingTop: 0 + "px", paddingBottom: 0 + "px" });

    var $documentHeight = $(document).height() - excludedHeight;

    var $elementHeight = $element.outerHeight(true);
    var $marginAmount = ($documentHeight - $elementHeight) / 2;

    $element.css({ paddingTop: $marginAmount + "px", paddingBottom: $marginAmount + "px" });

    if (!$element.hasClass("WebPlex-Animatable"))
        $element.addClass("WebPlex-Animatable");
}

function refreshCentrableElements(delayExecution) {
    var $centerableElement = $("[data-vertically-centered=true]");
    if ($centerableElement.length) {
        var $excludedElements = $("[data-vertical-excluded=true]");
        var $excludedHeight = 0;

        $excludedElements.each(function (excludedElementIndex, excludedElement) {
            var $excludedElement = $(excludedElement);
            $excludedHeight += $excludedElement.outerHeight(true);
        });

        layoutVerticallyCentered($centerableElement, $excludedHeight);

        if (delayExecution)
            setTimeout(function () {
                layoutVerticallyCentered($centerableElement, $excludedHeight);
            }, 50);
    }
};

function refreshSwitch() {
    $(".WebPlex-Switch > div").each(function () {
        var $switch = $(this);
        var $inputs = $switch.children(".WebPlex-FormInput");
        var $checkedInput = $inputs.filter(":checked");
        var $labels = $switch.children(".WebPlex-FormLabel");
        var $selection = $switch.children(".WebPlex-Selection");

        function isReadOnly() {
            return $switch.hasClass("WebPlex-ReadOnly") || $switch.closest("form[disabled=disabled]").length;
        }

        function labelOnClick($label) {
            var $position = $label.position();

            $selection.css({
                top: $position.top,
                width: $label.width(),
                height: $label.height(),
                left: $position.left
            });

            $inputs.removeAttr("checked");
            $labels.removeClass("WebPlex-Active");
            $label.addClass("WebPlex-Active");
            $label.prev(".WebPlex-FormInput").attr("checked", "checked");
        }

        $labels.off("click").on("click", function () {
            if (isReadOnly())
                return;

            labelOnClick($(this));
        });

        $checkedInput.next(".WebPlex-FormLabel").trigger("click");
    });
}

$(".WebPlex-UserImage > .WebPlex-Avatar").on("error", function () {
    var $this = $(this);
    var $parent = $this.parent();

    $this.off("error").remove();

    $parent.append($("<span></span>", {
        "class": "WebPlex-Avatar WebPlex-Default"
    }));
});

$(function () {
    function setRequestVerificationToken(event, xhr) {
        xhr.setRequestHeader("__RequestVerificationToken", $("input[name=__RequestVerificationToken]").val());
    };

    $(document).ajaxSend(setRequestVerificationToken);

    refreshCentrableElements(true);
    $(window).on("resize", function () {
        refreshCentrableElements(false);
    });

    refreshSwitch();

    $("[data-auto-focus=True]").focus();

    var $elements = $(".WebPlex-ParentItem");
    $elements.each(function (idx, element) {
        var $element = $(element);
        var $placeholder = getPlaceholder($element);
        var stateFrozen = false;

        function changeElementState(forceClose) {
            if (stateFrozen)
                return false;

            var isAjax = typeof $element.data("ajax") !== "undefined";

            if (forceClose || ($placeholder.hasClass("WebPlex-Opened") && !isAjax)) {
                $placeholder.removeClass("WebPlex-Opened");
                $element.removeClass("WebPlex-Opened");
            } else if (!isAjax) {
                $placeholder.addClass("WebPlex-Opened");
                $element.addClass("WebPlex-Opened");
            }

            return isAjax;
        }

        $element.on("click", function () {
            return changeElementState(false);
        }).on("focusout", function () {
            changeElementState(true);
        });

        $placeholder.on("mousedown", function () {
            stateFrozen = true;
        }).on("mouseup mouseleave", function () {
            stateFrozen = false;
            $element.focus();
        });
    });

    $("#WebPlex-Search .WebPlex-Icon").on("click", function () {
        $("#WebPlex-Search .WebPlex-Query").focus();
    });
});