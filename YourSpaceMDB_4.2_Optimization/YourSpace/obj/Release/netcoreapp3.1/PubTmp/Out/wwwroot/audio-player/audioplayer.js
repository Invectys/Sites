
var aps_play = "play";
var aps_pause = "pause";

var playerClass = "audioplayer";

var playerStateBtnClass = "audioplayer-state";
var playerTimeClass = "audioplayer-time";

var progressBarMainClass = "player-bar-main";
var progressBarClass = "player-bar";

var audioPathClass = "audioplayer-path";
var audioIdClass = "audioplayer-Id";

var MainAudioPlayerClass = "app-pannel-music";

var MainAudioPlayer = {};



MainAudioPlayer.GetPlayerId = function (audioplayerElem) {
    return audioplayerElem.getElementsByClassName(audioIdClass)[0].innerHTML;
}
MainAudioPlayer.GetStateButton = function (audioplayerElem) {
    return audioplayerElem.getElementsByClassName(playerStateBtnClass)[0];
}
MainAudioPlayer.GetMainPlayer = function () {
    return document.getElementsByClassName(MainAudioPlayerClass)[0];
}
MainAudioPlayer.GetAllPlayers = function () {
    var list = document.getElementsByClassName(playerClass);
    for (var i = 0; i < list.length; i++) {
        var audioplayer = list[i];
        var audioPath = this.GetAudioPath(audioplayer);
        if (audioPath == "") {
            list.splice(i, 1);
        }
    }
    return list;
}
MainAudioPlayer.GetAllPlayersByMusicId = function (id) {
    return document.getElementsByClassName(id);
}
MainAudioPlayer.GetAudioPath = function (audioplayerElem) {
    var path = audioplayerElem.getElementsByClassName(audioPathClass)[0].innerHTML;
    return path;
}
MainAudioPlayer.UpdateTextAndProgress = function (audioplayer,audio) {
    var CallSeconds = Math.floor(audio.currentTime);
    var Cminutes = Math.floor(CallSeconds / 60);
    var Cseconds = CallSeconds % 60;

    var AallSeconds = audio.duration;
    var Aminutes = Math.floor(AallSeconds / 60);
    var Aseconds = Math.floor(AallSeconds % 60);

    var playerTimeElem = audioplayer.getElementsByClassName(playerTimeClass)[0];
    var progressBarElem = audioplayer.getElementsByClassName(progressBarClass)[0];

    //time text
    playerTimeElem.innerHTML = Cminutes + ":" + Cseconds + "/" + Aminutes + ":" + Aseconds;

    //progress bar
    progressBarElem.style.width = ((CallSeconds / AallSeconds) * 100) + "%";
}
MainAudioPlayer.GetCurrentMusicId = function () { return this.MusicId; }

MainAudioPlayer.GetAuthor = function (audioplayer) {
    var elem = audioplayer.getElementsByClassName("player-audio-author")[0];
    return elem.innerHTML;
}
MainAudioPlayer.GetName = function (audioplayer) {
    var elem = audioplayer.getElementsByClassName("player-audio-name")[0];
    return elem.innerHTML;
}
MainAudioPlayer.GetImage = function (audioplayer) {
    var src = audioplayer.getElementsByTagName("IMG")[0].getAttribute("src");
    return src;
}
MainAudioPlayer.SetAuthor = function (audioplayer,author) {
    var elem = audioplayer.getElementsByClassName("player-audio-author")[0];
    elem.innerHTML = author;
}
MainAudioPlayer.SetName = function (audioplayer,name) {
    var elem = audioplayer.getElementsByClassName("player-audio-name")[0];
    elem.innerHTML = name;
}
MainAudioPlayer.SetImage = function (audioplayer,image) {
    var elem = audioplayer.getElementsByTagName("IMG")[0];
    elem.setAttribute("src", image);
}

MainAudioPlayer.Pause = function () {
    if (this.audio != undefined) {
        this.audio.pause();
    }
}

MainAudioPlayer.IsMusicPlayThisId = function (id)
{
    if (this.MusicId == undefined) {
        return false;
    }
    return this.MusicId == id;
}
MainAudioPlayer.IsMainPlayer = function (audioplayer) {
    return audioplayer.classList.contains(MainAudioPlayerClass);
}
MainAudioPlayer.Valid = function () { return this.audio != undefined; }
MainAudioPlayer.Play = async function (audioplayer) {
    var musicId = this.GetPlayerId(audioplayer);
    if (this.IsMusicPlayThisId(musicId) || this.IsMainPlayer(audioplayer)) {
        this.audio.play();
    } else {
        this.ClearAll();
        await sleep(10);
        this.LunchNewMusic(audioplayer);
    }
}
MainAudioPlayer.ClearAll = function () {
    
    MainAudioPlayer.Pause();
}

MainAudioPlayer.LunchNewMusic = function(audioplayer,autostart = true)
{

    var musicId = this.GetPlayerId(audioplayer);
    var audioPath = this.GetAudioPath(audioplayer);


    this.MusicId = musicId;
    this.Image = this.GetImage(audioplayer);
    this.Name = this.GetName(audioplayer);
    this.Author = this.GetAuthor(audioplayer);
    this.audio = new Audio(audioPath);


    var main = this.GetMainPlayer();
    main.classList.remove("invisible");
    this.SetImage(main,this.Image);
    this.SetName(main, this.Name);
    this.SetAuthor(main, this.Author);

    MainAudioPlayer.InitAudioPlayer(main, this.audio);


    var players = this.GetAllPlayersByMusicId(musicId);
    for (var i = 0; i < players.length; i++) {
        var player = players[i];
        MainAudioPlayer.InitAudioPlayer(player, this.audio, main);
    }

    //console.log(audioplayer.PauseTime);
    if (audioplayer.PauseTime != undefined) {
        this.audio.currentTime = audioplayer.PauseTime;
    }

    if (autostart) {
        MainAudioPlayer.Play(audioplayer);
    }


    ShowSecondTab();
}



MainAudioPlayer.SetPlayState = function (audioplayer) {
    var icon = audioplayer.getElementsByClassName("player-icon")[0];
    audioplayer.State = aps_play;
    icon.classList.remove("player-icon-pause");
    icon.classList.add("player-icon-play");
}


MainAudioPlayer.SetPauseState = function (audioplayer) {
    var icon = audioplayer.getElementsByClassName("player-icon")[0];
    audioplayer.State = aps_pause;
    icon.classList.remove("player-icon-play");
    icon.classList.add("player-icon-pause");

    audioplayer.PauseTime = this.audio.currentTime;
    //console.log("seted ",audioplayer.PauseTime);
}



MainAudioPlayer.InitAudioPlayer = function (audioplayer, audio) {

    audioplayer.State = audio.paused ? aps_pause : aps_play;

    audio.addEventListener("loadedmetadata", function () {
        MainAudioPlayer.UpdateTextAndProgress(audioplayer, audio);
    });
    
    audio.addEventListener("timeupdate", function () {
        MainAudioPlayer.UpdateTextAndProgress(audioplayer, audio);
    });
    
    audio.addEventListener("play", function () {
        MainAudioPlayer.SetPlayState(audioplayer);
    });

    audio.addEventListener("pause", function () {
        MainAudioPlayer.SetPauseState(audioplayer);
    });

    audio.addEventListener("ended", function () {
        MainAudioPlayer.SetPauseState(audioplayer);
        MainAudioPlayer.audio.currentTime = 0;
    });

    var stateBtn = MainAudioPlayer.GetStateButton(audioplayer);
    stateBtn.onclick = function () {
        if (audioplayer.State == aps_pause) {
            MainAudioPlayer.SetPlayState(audioplayer);
            MainAudioPlayer.Play(audioplayer);
        } else {
            MainAudioPlayer.SetPauseState(audioplayer);
            MainAudioPlayer.Pause(audioplayer);
        }
    }

    var progressBarMainElem = audioplayer.getElementsByClassName(progressBarMainClass)[0];
    progressBarMainElem.onclick = async function (e) {
        var musicId = MainAudioPlayer.GetPlayerId(audioplayer);
        var isThisPlay = MainAudioPlayer.IsMusicPlayThisId(musicId);

        //console.log(isThisPlay);
        //console.log(musicId);

        if (!MainAudioPlayer.Valid() || !isThisPlay ) {
            //MainAudioPlayer.LunchNewMusic(audioplayer, false);
            await MainAudioPlayer.Play(audioplayer);
        }

        var kNewAudioProgress = e.offsetX / this.offsetWidth;
        var setedTime = audio.duration * kNewAudioProgress;

        MainAudioPlayer.audio.currentTime = setedTime;

    };

    var icon = audioplayer.getElementsByClassName("player-icon")[0];
    if (audioplayer.State == aps_pause) {
        icon.classList.remove("player-icon-play");
        icon.classList.add("player-icon-pause");
    } else {
        icon.classList.add("player-icon-play");
        icon.classList.remove("player-icon-pause");
    }

    this.UpdateTextAndProgress(audioplayer, audio);
}



function InitAudioPlayerDefaultPresentationById(Id) {
    var elem = document.getElementById(Id);
    var path = MainAudioPlayer.GetAudioPath(elem);
    var musicId = MainAudioPlayer.GetPlayerId(elem);
    var audio;
    if (MainAudioPlayer.MusicId != undefined && MainAudioPlayer.MusicId == musicId) {
        audio = MainAudioPlayer.audio;
    } else {
        audio = new Audio(path);
    }
    MainAudioPlayer.InitAudioPlayer(elem, audio);
}


