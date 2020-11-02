

let DeltaTimeConnection = 3000;


let connection = new signalR.HubConnectionBuilder().withUrl("/gameHub").build();

connection.start().then(function () {

    connection.invoke("AddToGroup", Identifier).catch(function (err) {
        return console.error(err.toString());
    });
    }).catch (function (err) {
    return console.error(err.toString());
});





function Join() {
    var data = {
        Identifier: Identifier
    };
    $.ajax({
        url: UrlJoin,
        type: 'POST',
        data: data,
        success: function (data) {
            console.log("Join succes", data);
            HandleJoinError(data);
        },
        error: function (data) {
            console.log("Join faile",data);
           // location.reload();
        }   

    });
}

function Exit() {
    var data = {
        Identifier: Identifier
};
$.ajax({
    url: UrlExit,
    type: 'POST',
    data: data,
    success: function (data) {
        console.log("Exit succes");
        HandleExitError(data)
    },
    error: function () {
        console.log("Exit faile");
        //location.reload();
    }

});
    }

document.getElementById('Join_Button').onclick = function () { Join(); };
document.getElementById('Exit_Button').onclick = function () { Exit(); };

let Delta = 100;
let timeout, intervalid;

function Anim() {
    var progress = (TimeGameProcess - TimeToEnd) / TimeGameProcess;
    //console.log(progress);
    TimeToEnd -= Delta;
    SetProgressBar(progress);
}
function StopAnim() {
    SetProgressBar(1);
    clearInterval(intervalid);
    clearTimeout(timeout);
    TimeToEnd = TimeGameProcess;
    ProgressWaitGame();
}
function startAnim() {
    if (InProcess) {
        intervalid = setInterval(Anim, Delta);
        timeout = setTimeout(StopAnim, TimeToEnd);
    }
    
}



//Game Events
connection.on("PlayerJoin", function (user) {
    console.log("new player : " + user);
    AddPlayerToTable(user);

    if (user == UserName) {
        addMoney(-1 * Rate);
    }

    PlayersCounterUpdate();
    
});

connection.on("PlayerExit", function (user) {
    console.log("player exit: " + user);
    RemovePlayerFromTable(user);
    if (user == UserName) {
        addMoney(Rate);
    }

    PlayersCounterUpdate()
});

connection.on("GameStart", function () {
    console.log("GameStart");
    InProcess = true;

    ShowInfo("Game soon start!  Wait!");

    let func = function () {
        startAnim();
        ShowInfo("Game In Process");
    }
    let timeout = setTimeout(func, DeltaTimeConnection);
});
connection.on("GameEnd", function (winner) {
    console.log("GameEnd winner = " + winner);
    ShowWinner("Winner " + winner);
   


    let end = function () {
        InProcess = false;
        //StopAnim();
        ClearPlayersTable();
        PlayersCounterUpdate();
    }
    
    let timeout = setTimeout(end, DeltaTimeConnection);
});
connection.on("GameDelete", function () {
    console.log("Game deleted!");
    InProcess = false;
    ClearPlayersTable();
    ShowWinner("Game deleted!");
    
});

function HideJoinButton() {
    var el = document.getElementById("Join_Button");
    el.style.display = "none";
}
function HideExitButton() {
    var el = document.getElementById("Exit_Button");
    el.style.display = "none";
}
function ShowJoinButton() {
    var el = document.getElementById("Join_Button");
    el.style.display = "block";
}
function ShowExitButton() {
    var el = document.getElementById("Exit_Button");
    el.style.display = "block";
}
function PlayerTableRowCount() {
    var rowCount = $('#Players_Table tr').length;
    return rowCount;
}
function AddPlayerToTable(name) {
    
    var el = $("<tr id='" + name + "'><th scope='row'>" + (PlayerTableRowCount()+1) + "</th><td>" + name + "</td></tr>");
    $("#Players_Table").append(el);
}
function RemovePlayerFromTable(name) {
    console.log(name);
    var elem = document.getElementById(name);
    elem.remove(); 
}
function ClearPlayersTable() {
    document.getElementById("Players_Table").innerHTML = "";
}

function PlayersCounterUpdate() {

    let text = "Players : ";
    let num = PlayerTableRowCount();
    if (num >= NeedPlayers) {
        text = "MAX Players : "
    }
    document.getElementById('PlayersInRoomCounter_Text').innerHTML = text + num + "/" + NeedPlayers;
}


function ShowWinner(text) {
    $("#Winner_Text").html(text);
    var clearFunc = function () {
        $("#Winner_Text").html("");
    }
    setTimeout(clearFunc, 5000);
}
function ShowInfo(text) {
    

    $("#ErrorMessage_Text").html(text);
    var clearFunc = function () {
        $("#ErrorMessage_Text").html("");
    }
    setTimeout(clearFunc, 5000);
}
function SetProgressBar(val) {
    //val = val * 1.1;
    document.getElementById("GameEnd_ProgressBar").style.width = (val * 100) + "%";
    document.getElementById("GameEnd_ProgressBar").innerHTML = parseInt(val * 100) + "%";
}
function ProgressWaitGame()
{
    var func = function f() {
        document.getElementById("GameEnd_ProgressBar").innerHTML = "Game not started!";
        document.getElementById("GameEnd_ProgressBar").style.width = "0%";
    }
    setTimeout(func, 1000);
}

function HandleJoinError(code) {
    switch (code) {
        case -1: break;
        case 0: break;
        case 1: ShowInfo("Max Players !");  break;
        case 2: ShowInfo("Started !");break;
        case 3: ShowInfo("No Money !");break;
        case 4: ShowInfo("In Game !");break;
        case 5: ShowInfo("Need Phone confirmed !");break;
        case 6: ShowInfo("Auth please !");break;
    }
}

function HandleExitError(code) {
    switch (code) {
        case -1: break;
        case 0: break;
        case 1: ShowInfo("Started !"); break;
        case 2: ShowInfo("Not in game"); break;
        case 3: ShowInfo("Auth please !"); break;
    }
}

if (!isAuth) {
    HideExitButton();
    HideJoinButton();
}


startAnim();


if (InProcess) {
    
} else {
    ProgressWaitGame();
}


PlayersCounterUpdate();