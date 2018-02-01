//var ms = new Siema({
//    selector: '.siema',
//    duration: 400,
//    easing: 'linear',
//    perPage: 1,
//    startIndex: 0,
//    draggable: false,
//    multipleDrag: false,
//    threshold: 20,
//    loop: true,
//    onInit: () => { },
//    onChange: () => { },
//});

//setInterval(() => { ms.next() }, 7000)

function accordian(selector, $this) {
    var accordianWrapper = document.getElementById(selector);
    if (accordianWrapper.classList.contains('closed')) {
        accordianWrapper.style.height = 'auto';
        var h = accordianWrapper.clientHeight;
        accordianWrapper.style.height = 0;
        //alert(h);

        Velocity(accordianWrapper, { height: `${h}px` }, { duration: 500 });
        accordianWrapper.classList.remove('closed');
        $this.innerHTML = 'close'
    } else {
        Velocity(accordianWrapper, { height: `${0}px` }, { duration: 500 });
        accordianWrapper.classList.add('closed');
        $this.innerHTML = 'Modify Search'
    }
}