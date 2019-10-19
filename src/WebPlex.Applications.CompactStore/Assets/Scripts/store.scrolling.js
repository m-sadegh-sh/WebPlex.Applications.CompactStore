$(function() {
    if ($.fn.jScrollPane) {
        $(".WebPlex-Scrollable").each(function() {
            var $this = $(this);
            $this.jScrollPane({ autoReinitialise: $this.hasClass("WebPlex-AutoInitialise") });
            $this.on("jsp-scroll-y", function(event, scrollPositionY, isAtTop) {
                if (isAtTop || isNaN(scrollPositionY) || scrollPositionY < 10)
                    $this.children(".jspContainer").removeClass("WebPlex-Shadow");
                else
                    $this.children(".jspContainer").addClass("WebPlex-Shadow");
            });
        });
    }
})