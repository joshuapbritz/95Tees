var sliderParent = document.querySelector('.slider');
var navigatorBar = sliderParent.querySelector('.navigator');
var slides = sliderParent.querySelectorAll('.slide-item');

if (slides.length > 0) slides[0].style.right = 0;

if (slides.length > 1) {

    for (var i = 0; i < slides.length; i++) {
        navigatorBar.innerHTML += `<div class="bar ${i === 0 ? 'active' : ''}" index="${i}"></div>`;
    }

    var dots = navigatorBar.querySelectorAll('.bar');

    var i = 0, slideLength = slides.length - 1, running = false;

    function gotToSlide(exitingSlide, enteringSlide) {
        running = true;
        Velocity(slides[enteringSlide], { right: `0px` }, { duration: 680, easing: 'easeInOutSine' }).then(() => {});

        Velocity(slides[exitingSlide], { right: `${window.innerWidth}px` }, { duration: 700, easing: 'easeInOutSine' }).then(() => {
            slides[exitingSlide].style.right = `-100%`;
            running = false;
        });
    }

    function slideBack(exitingSlide, enteringSlide) {
        running = true;
        slides[enteringSlide].style.right = `100%`;
        Velocity(slides[enteringSlide], { right: `0px` }, { duration: 680, easing: 'easeInOutSine' });

        Velocity(slides[exitingSlide], { right: `-100%` }, { duration: 700, easing: 'easeInOutSine' }).then(() => {
            running = false;
        });
    }

    function nextSlide() {
        if (i < slideLength) {
            gotToSlide(i, i + 1);
            i++;
            setDots(i)
        } else {
            gotToSlide(slideLength, 0);
            i = 0;
            setDots(i)
        }
    }

    function previousSlide() {
        if (i > 0) {
            slideBack(i, i - 1);
            i--;
            setDots(i)
        } else {
            slideBack(0, slideLength);
            i = slideLength;
            setDots(i)
        }
    }

    function setDots(active) {
        dots.forEach(dot => {
            dot.classList.remove('active');
        })
        navigatorBar.querySelector(`.bar[index='${active}']`).classList.add('active')
    }

    var sliderinterval = setInterval(function () {
        nextSlide()
    }, 6000);

    var nextBtn = sliderParent.querySelector('.next'),
        prevBtn = sliderParent.querySelector('.previous');

    if (nextBtn) {
        nextBtn.addEventListener('click', function () {
            if (!running) {
                running = true;
                clearInterval(sliderinterval);
                nextSlide();
                sliderinterval = setInterval(nextSlide, 6000)
            }
        });
    }

    if (prevBtn) {
        prevBtn.addEventListener('click', function () {
            if (!running) {
                running = true;
                clearInterval(sliderinterval);
                previousSlide();
                sliderinterval = setInterval(nextSlide, 6000)
            }
        });
    }

    dots.forEach(dot => {
        dot.addEventListener('click', function () {
            var index = Number(dot.getAttribute('index'));
            var direction = index > i ? 'forwards' : 'backwards';
            if (!running) {
                running = true;
                clearInterval(sliderinterval);
                if (direction === 'forwards') {
                    gotToSlide(i, index);
                } else {
                    slideBack(i, index);
                }
                setDots(index);
                i = index;
                sliderinterval = setInterval(nextSlide, 6000);
            }
        })
    })
}


