let shapeitem = document.querySelectorAll('.shapes .shapes-item');

let btnrec = document.querySelector('.recbtn');
let btnsq = document.querySelector('.sqbtn');
let btnround = document.querySelector('.roundbtn');
let btnoval = document.querySelector('.ovalbtn');
let redirect = document.querySelector('.redirecturl');


let recmea = document.querySelector('#recmea');
let sqmea = document.querySelector('#sqmea');
let roundmea = document.querySelector('#roundmea');
let ovalmea = document.querySelector('#ovalmea');



btnrec.addEventListener('click', function(e) {
    e.preventDefault();
    shapeitem.forEach(x => x.classList.add('d-none'));
    recmea.classList.remove('d-none');
})
btnsq.addEventListener('click', function(e) {
    e.preventDefault();
    shapeitem.forEach(x => x.classList.add('d-none'));
    sqmea.classList.remove('d-none');
})
btnround.addEventListener('click', function(e) {
    e.preventDefault();
    shapeitem.forEach(x => x.classList.add('d-none'));
    roundmea.classList.remove('d-none');
})
btnoval.addEventListener('click', function(e) {
    e.preventDefault();
    shapeitem.forEach(x => x.classList.add('d-none'));
    ovalmea.classList.remove('d-none');
})

