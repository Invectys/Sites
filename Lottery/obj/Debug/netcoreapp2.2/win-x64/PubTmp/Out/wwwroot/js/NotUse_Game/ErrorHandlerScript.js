
var Joinerr_1 = "NoMailConfirmed";
var Joinerr_2 = "NoUser";
var Joinerr_3 = "UserAlreadyInGame";
var Joinerr_4 = "UsersLimit";
var Joinerr_5 = "NoMoney";
var Joinerr_6 = "GameStarted";
var Joinerr_7 = "NoMailConfirmed";
var Joinerr_8 = "NoMailConfirmed";
var Joinerr_9 = "GameMustBeupdated";

connection.on("Error", function (type, num) {

    console.log("Eror: ");
    console.log(type + " " + num);

    if (type == "JoinException") {
        switch (num) {
            case 1: GameSetInfo(Joinerr_1); break;
            case 2: GameSetInfo(Joinerr_2); break;
            case 3: GameSetInfo(Joinerr_3); break;
            case 4: GameSetInfo(Joinerr_4); break;
            case 5: GameSetInfo(Joinerr_5); break;
            case 6: GameSetInfo(Joinerr_6); break;
            case 7: GameSetInfo(Joinerr_7); break;
            case 8: GameSetInfo(Joinerr_8); break;
            case 9: GameSetInfo(Joinerr_9); break;
        }
    }
    
   
});

connection.on("Gameupdated", function (info) {
    switch (info) {
        case 0:
            TimerSetInfo("Game updated !");
            HideJoinButton();

            setTimeout(function () { connection.invoke("GameConfigure", GameID); ToggleJoinButton(); }, 5000);
            
            break;
        case 1:
            TimerSetInfo("Game Deleted !");

            break;
    }

});
