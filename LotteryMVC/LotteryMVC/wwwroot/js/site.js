// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write yo

function addMoney(amount) {
    var el = document.getElementById("Money-Field");
    var now = parseInt(el.innerHTML);
    el.innerHTML = now + amount;
}
function setMoney(val) {
    var el = document.getElementById("Money-Field");
    el.innerHTML = val;
}
function getMoney() {
    var el = document.getElementById("Money-Field");
    if (el != null) {
        return parseInt(el.innerHTML);
    } else return -1;

}