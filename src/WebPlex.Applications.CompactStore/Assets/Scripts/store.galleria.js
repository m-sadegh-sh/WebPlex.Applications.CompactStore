$(function() {
    if ($("#galleria").length) {
        Galleria.loadTheme("/Assets/Scripts/galleria.classic.js");

        Galleria.run("#galleria", {
            height: 309,
            width: 302,
            autoplay: 5000,
            pauseOnInteraction: false,
            showInfo: true,
            direction: "rtl"
        });

        Galleria.ready(function() {
            var gallery = this;
            this.addElement("fullscreen");
            this.appendChild("info", "fullscreen");
            this.$("fullscreen")
                .click(function() {
                    gallery.toggleFullscreen();
                });

            this.bind("image", function(e) {
                $(e.imageTarget).on("click", function() {
                    gallery.toggleFullscreen();
                });
            });

            this.addIdleState(this.get("fullscreen"), { opacity: 0 });

            $("#galleria").addClass("Parnian-Loaded");
        });
    }
});