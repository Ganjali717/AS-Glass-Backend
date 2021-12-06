let typeitem = document.querySelector('.gl-type-item');
let thickitem = document.querySelectorAll('.gl-thick-item');


typeitem.addEventListener('click', function (e)
{
    e.preventDefault();
    let inputs = document.querySelectorAll('.gl-type-item #checkitem');

    inputs.toggleAttribute("checked");
     
})


thickitem.forEach(x => x.addEventListener('click', function (e) {
    e.preventDefault();
    let inputs2 = document.querySelector('.gl-thick-item #checkitem2');
    console.log("salam");
    inputs2.toggleAttribute("checked");

}))