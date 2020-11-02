function TimerSetInfo(MainInfo, n) {
   
    if ((n != undefined)) {


        $('#timer').html(MainInfo + "<small> " + n + " </small>");
    }
    else {
        $('#timer').text(MainInfo);
    }

}


function GameSetInfo(MainInfo, n) {
   
    if ((n != undefined)) {


        $('#InfoMessageGameBlock').html(MainInfo + "<small> " + n + " </small>");
    }
    else {
        $('#InfoMessageGameBlock').text(MainInfo);
    }

}