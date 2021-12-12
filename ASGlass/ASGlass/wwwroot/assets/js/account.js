let tabpaneorder = document.querySelector("#tab-pane-order");
let orderbtn = document.querySelector("#account-order-btn");
let tabpaneaccount = document.querySelector("#tab-pane-account");
let accountbtn = document.querySelector("#account-btn");

orderbtn.addEventListener('click', function () {

    tabpaneorder.classList.add('show');
    tabpaneorder.classList.add('active');
    tabpaneaccount.classList.remove('active');
    tabpaneaccount.classList.remove('show');

});

accountbtn.addEventListener('click', function () {
    tabpaneorder.classList.remove('show');
    tabpaneorder.classList.remove('active');
    tabpaneaccount.classList.add('show');
    tabpaneaccount.classList.add('active');
})
