var LoadFile, LoadImage, LoadVideo, SlideBar;

//saving
var Global_UpdateBlockInformation = {};
var Global_UpdateAdditionInfo = {};
var Global_SavePageForm = {};

var NewBlockStartinfo =
{
    left: document.documentElement.clientWidth / 2, top: document.documentElement.clientHeight / 2, height: '200', width: '200', 
    effect: 'none', rotate: '0', skew: { x: '0', y: '0' }, translate: { x: '0', y: '0' }, bgcolor: "#0003", scale: "1", img:'http://thefalcon.kinkaid.org/wp-content/uploads/2015/10/avatar3.jpg'
};//начальная позиция блока при создании

//pools
var EffectsPool = {};

var TransformPool = {};
