let typeitem = document.querySelector('.gl-type-item');
let thickitem = document.querySelectorAll('.gl-thick-item');

let submitform = document.querySelector('#submitform');

typeitem.addEventListener('click', function (e) {
    e.preventDefault();
    let inputs = document.querySelectorAll('.gl-type-item #checkitem');

    inputs.toggleAttribute("checked");

});


thickitem.forEach(x => x.addEventListener('click', function (e) {
    e.preventDefault();
    let inputs2 = document.querySelector('.gl-thick-item #checkitem2');
    console.log("salam");
    inputs2.toggleAttribute("checked");

}));


submitform.addEventListener('click', function (e) {
   
    document.querySelector(".form1").submit();

});
