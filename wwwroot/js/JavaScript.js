$(document).ready(function () {
    new WOW().init();

    $('.header-carousel').owlCarousel({
        autoplay: true,
        smartSpeed: 1000,
        margin: 30,
        loop: true,
        nav: true,
        dots: false,
        items: 1,
        navText: ['<i class="bi bi-arrow-left"></i>', '<i class="bi bi-arrow-right"></i>']
    });
});
