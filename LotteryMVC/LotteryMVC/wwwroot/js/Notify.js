let NotificationConnection = new signalR.HubConnectionBuilder().withUrl("/notificationHub").build();

NotificationConnection.start().then(function () {


}).catch(function (err) {
    return console.error(err.toString());
});

NotificationConnection.on("Notify", function (data) {
    console.log(data);
    let type = data.type;
    switch (type) {
        case 0:
            if (data.win) {
                addMoney(data.money);
                console.log("add Money");
                Notify(data.text + " Game#" + data.gameIdentifier, "alert-success");
            } else {
                Notify(data.text + " Game#" + data.gameIdentifier, "alert-danger");
            }
            
            break;
    }
});



let classNotify = "alert-success";
function Notify(text,cl="") {
    let el = document.getElementById("Notify_Text");
    el.innerHTML = text;
    el.style.display = 'inherit';
    
    let f = function () {
        let el = document.getElementById("Notify_Text");
        el.style.display = "none";
    }
    setTimeout(f, 4000);

    el.classList.remove(classNotify);
    el.classList.add(cl);
    classNotify = cl;


}
