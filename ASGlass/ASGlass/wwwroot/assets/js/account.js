let tabpaneorder = document.getElementById("tab-pane-order");
let tabpaneaccount = document.getElementById("tab-pane-account");
let accountbtn = document.getElementById("account-btn");
let orderbtn = document.getElementById("account-order-btn");

orderbtn.addEventListener('click', function () {

    tabpaneorder.classList.add('show');
    tabpaneorder.classList.add('active');
    tabpaneorder.style.display = "block";
    tabpaneaccount.style.display = "none";
    tabpaneaccount.classList.remove('active');
    tabpaneaccount.classList.remove('show');

});

accountbtn.addEventListener('click', function () {
    tabpaneorder.classList.remove('show');
    tabpaneorder.classList.remove('active');
    tabpaneaccount.classList.add('show');
    tabpaneaccount.classList.add('active');

    tabpaneorder.style.display = "none";
    tabpaneaccount.style.display = "block";
})
