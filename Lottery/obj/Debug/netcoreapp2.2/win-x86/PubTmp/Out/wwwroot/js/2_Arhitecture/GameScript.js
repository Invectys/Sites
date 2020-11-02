var MinPlayers = 1;
var Rate=0, Time=0,TimeRemaining = 0;
var GameStarted = false;
var WinnerShowTime = 4;
var NeedMailConfirmed = false;
var Cash = 0;


BlockJoinButton();

connection.start().then(function () {

    UnBlockJoinButton();
    connection.invoke("GameConfigure",GameID);

}).catch(function (err) {
    return console.error(err.toString());
});



if (document.getElementById("Join") != undefined)
document.getElementById("Join").addEventListener("click", function (event) {
    connection.invoke("Join", GameID);

});


connection.on("PlayerJoined", function (user) {
    table.Add(user, Rate);

    if (user == UserName) {
        var is = $('#money').text();
        $('#money').text(is - Rate);
        HideJoinButton();
    }
    SetCash(Cash + Rate);
    updateNeedPlayersToStartGame();
});

connection.on("GameConfigure", function (data) {
    console.log(data);

    TimeRemaining = data.timeRemaining;
    SetRate(data.rate);
    SetTime(data.time);
    MinPlayers = data.minPlayers;
    NeedMailConfirmed = data.needMailConfirmed;
    

    if (data.gameStarted) {
        StartGame();
    }
    else {
        updateNeedPlayersToStartGame()
        
    }
});



connection.on("StartGame", function () {
    
    StartGame();
    
});
connection.on("EndGame", function (WinnerName) {
   
    if (WinnerName == UserName) {
        
        var is = $('#money').text();
        console.log(is);
        $('#money').text(parseFloat(is) + table.getCash());
        WinAnimation();
    }

    GameStarted = false;
    TimerSetInfo("Winner !", WinnerName);
    
    setTimeout(function () {
        if (GameStarted == false) {
            var n = MinPlayers - table.getLenght();
            TimerSetInfo(GameNotStartedText, n);
        }

    }, WinnerShowTime  * 1000);
    table.RemoveAll();
    ToggleJoinButton();
    SetCash(0);
});

function SetRate(newRate) {
    Rate = newRate;
    $('.rate').text(Rate);
}
function SetTime(newTime) {
    Time = newTime;
   
}
function SetCash(nCash) {
    Cash = nCash;
    $('.cash').text(Cash);
}
function StartGame() {
    StartTimer(Time - TimeRemaining);
    TimeRemaining = 0;
    GameStarted = true;
}
function BlockJoinButton() {
    if (document.getElementById("Join") != undefined)
    document.getElementById("Join").disabled = true;
}
function UnBlockJoinButton() {
    if (document.getElementById("Join") != undefined)
    document.getElementById("Join").disabled = false;
}
function HideJoinButton() {
    $("#Join").css({"visibility":"hidden"});
}
function ToggleJoinButton() {
    $("#Join").css({ "visibility": "visible" });
}
function updateNeedPlayersToStartGame() {
    var n = MinPlayers - table.getLenght();
    TimerSetInfo(GameNotStartedText, n);
}

Object.maxCount = 200;
Object.speed = 3;

function WinAnimation() {
    var StopTime = 2000;
    if (Rate > 600) {
        Object.maxCount = 250;
        StopTime = StopTime + 3000;
    }

    Object.maxCount = Rate;
    Object.start();
    setTimeout(Object.stop, StopTime);
    $("#Object-canvas").css({ 'position': 'fixed', 'margin': '-50vh 0px 0px 0px' });
}

