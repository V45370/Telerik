function nextSlide() {
    currentSlideIndex++;

    if (currentSlideIndex >= slides.length) {
        currentSlideIndex = 0;
    }

    clearInterval(auto);
    clearTimeout(timeout);
    auto = setInterval(nextSlide, INTERVAL_TIME);
    render(currentSlideIndex);
}

function previousSlide() {
    currentSlideIndex--;

    if (currentSlideIndex < 0) {
        currentSlideIndex = slides.length - 1;
    }

    clearInterval(auto);
    clearTimeout(timeout);
    auto = setInterval(nextSlide, INTERVAL_TIME);
    render(currentSlideIndex);
}

function render() {
    slider.fadeOut(500);

    timeout = setTimeout(function () {
        slider.html(slides[currentSlideIndex]);
        slider.fadeIn(700)
    }, 500);
}

var cat = '<h3>Cat</h3><img src="img/home-cat.jpg">';
var view = '<h3>Beautiful View</h3><img src="img/Bachalpseeflowers.jpg">';
var articleWithDiv = '<article><h2>Article</h2><div>Lorem ipsum dolor sit amet, consectetur...</div></article>';

var slides = [cat, articleWithDiv, view];
var INTERVAL_TIME = 5000;

$('#previous').on('click', previousSlide);
$('#next').on('click', nextSlide);

var slider = $('#slider');

var currentSlideIndex = 0;
var auto = setInterval(nextSlide, INTERVAL_TIME);
var timeout = 0;

render();
