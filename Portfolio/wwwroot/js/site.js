(function($) {
    //Comment text max length alert
    $("#characterLeft").text("140 characters left");
    $("#message").keyup(function() {
        var max = 140;
        var len = $(this).val().length;
        if (len >= max) {
            $("#characterLeft").text("You have reached the limit");
            $("#characterLeft").addClass("red");
            $("#btnSubmit").addClass("disabled");
        } else {
            var ch = max - len;
            $("#characterLeft").text(ch + " characters left");
            $("#btnSubmit").removeClass("disabled");
            $("#characterLeft").removeClass("red");
        }
    });

    $("#ctaButton").on("click", function () {
        $('html, body').animate({
            scrollTop: $("#mainContent").offset().top - 90
        }, 1500);
    })

    var resizeLead = function() {
        var display = $(".jumbotron>.container>h1");
        if ($(window).width() > 400) {
            display.addClass("display-3");
            display.removeClass("display-4");
            display.removeClass("display-5");

        } else if ($(window).width() > 300) {
            display.addClass("display-4");
            display.removeClass("display-3");
            display.removeClass("display-5");
        } else {
            display.addClass("display-5");
            display.removeClass("display-3");
            display.removeClass("display-4");
        }
    };


    resizeLead();
    //Lead Display size based class swap
    $(window).on("resize",
        function() {
            resizeLead();
        });

    $("button.navbar-toggler").addClass("collapsed");
    //Color transition on navbar collapse
    $("button.navbar-toggler").on("click",
        function() {
            console.log($(this).attr("class").split(" "));
            $("#mainNav").toggleClass("nav-open");
        });


    "use strict"; // Start of use strict
    // Smooth scrolling using jQuery easing
    $('a.js-scroll-trigger[href*="#"]:not([href="#"])').click(function() {
        if (location.pathname.replace(/^\//, "") == this.pathname.replace(/^\//, "") &&
            location.hostname == this.hostname) {
            var target = $(this.hash);
            target = target.length ? target : $("[name=" + this.hash.slice(1) + "]");
            if (target.length) {
                $("html, body").animate({
                        scrollTop: (target.offset().top - 54)
                    },
                    1000,
                    "easeInOutExpo");
                return false;
            }
        }
    });

    // Closes responsive menu when a scroll trigger link is clicked
    $(".js-scroll-trigger").click(function() {
        $(".navbar-collapse").collapse("hide");
    });

    // Activate scrollspy to add active class to navbar items on scroll
    $("body").scrollspy({
        target: "#mainNav",
        offset: 30
    });

    // Collapse Navbar
    var navbarCollapse = function() {
        if ($("#mainNav").offset().top > 50) {
            $("#mainNav").addClass("navbar-shrink");
        } else {
            $("#mainNav").removeClass("navbar-shrink");
        }
    };
    // Collapse now if page is not at top
    navbarCollapse();
    // Collapse the navbar when page is scrolled
    $(window).scroll(navbarCollapse);

    // Hide navbar when modals trigger
    $(".portfolio-modal").on("show.bs.modal",
        function(e) {
            $(".navbar").addClass("d-none");
        });
    $(".portfolio-modal").on("hidden.bs.modal",
        function(e) {
            $(".navbar").removeClass("d-none");
        });

})(jQuery); // End of use strict