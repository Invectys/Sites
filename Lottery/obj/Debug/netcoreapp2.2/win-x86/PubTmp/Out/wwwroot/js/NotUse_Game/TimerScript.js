

function getTimeRemaining(endtime) {
    var now = new Date()
    var t = endtime.getTime() - now.getTime();
   
    var seconds = Math.floor((t / 1000) % 60);
    var minutes = Math.floor((t / 1000 / 60) % 60);
    var hours = Math.floor((t / (1000 * 60 * 60)) % 24);
    var days = Math.floor(t / (1000 * 60 * 60 * 24));
    return {
        'total': t,
        'days': days,
        'hours': hours,
        'minutes': minutes,
        'seconds': seconds
    };
}

function StartTimer(time_seconds) {
    var deadline = new Date();
    deadline = new Date(deadline.getTime() + (time_seconds + 1) * 1000);
    console.log('start');

    var timerId = setInterval(function () {
        
        var str = "" + getTimeRemaining(deadline).seconds;
        if (getTimeRemaining(deadline).minutes > 0) str = getTimeRemaining(deadline).minutes + ":" + str;
        if (getTimeRemaining(deadline).hours > 0) str = getTimeRemaining(deadline).hours + "hours :" + str;
        if (getTimeRemaining(deadline).days > 0) str = getTimeRemaining(deadline).days + "days :" + str;
        if (GameStarted) TimerSetInfo(WaitResultStr,str);
       
    }, 1000);

    
   setTimeout(function () {
        clearInterval(timerId);
        console.log("stop");
    }, (time_seconds + 0.5) * 1000 );

   
}


