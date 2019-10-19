var $asyncIndicator = null;

$(function() {
    $asyncIndicator = $("#WebPlex-AsyncIndicator");

    if (typeof window.webPlexMessages !== "undefined")
        webPlexShowAllMessages(window.webPlexMessages);
});

function webPlexShowAllMessages(messages) {
    var delay = 2000;

    $.each(messages, function(idx, message) {
        switch (message.Type) {
            case 0:
                setTimeout(function() {
                    webPlexShowFailureAsyncIndicator(message.Message);
                }, idx * delay);
                break;

            case 1:
                setTimeout(function() {
                    webPlexShowSuccessAsyncIndicator(message.Message);
                }, idx * delay);
                break;
        }
    });
}

function webPlexShowFailureAsyncIndicator(message) {
    webPlexShowAsyncIndicator("Error", message != null ? message : $asyncIndicator.data("failure-message"), true, 4000);
}

function webPlexShowSuccessAsyncIndicator(message) {
    webPlexShowAsyncIndicator("Success", message != null ? message : $asyncIndicator.data("success-message"), true, 2500);
}

var messages = [];
var messagesCount = 0;

function webPlexShowAsyncIndicator(type, messageText, autoClose, timeout) {
    var $message = $("<span></span>");

    messages.push($message);
    messagesCount++;

    $message.addClass("WebPlex-Message WebPlex-Clearfix");
    if (type != null)
        $message.addClass("WebPlex-" + type);
    $message.text(messageText);

    $asyncIndicator.append($message);
    $asyncIndicator.addClass("WebPlex-Visible");

    if ($asyncIndicator.last().text() !== messageText) {
        setTimeout(function() {
            $message.addClass("WebPlex-In");
        }, 1);
    } else
        $message.addClass("WebPlex-In");

    if (autoClose) {
        var index = messagesCount - 1;

        setTimeout(function() {
            webPlexHideAsyncIndicator(index);
        }, timeout || 1000);
    }

    return messagesCount - 1;
}

function webPlexHideAsyncIndicator(index) {
    var $message = messages[index];

    $message.addClass("WebPlex-Out");

    setTimeout(function() {
        $message.remove();
        messagesCount--;

        if (!messagesCount) {
            $asyncIndicator.removeClass("WebPlex-Visible");
            $asyncIndicator.children(".WebPlex-Message").remove();
        }
    }, 200);
}