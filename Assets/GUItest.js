@script ExecuteInEditMode
#pragma strict


var button: Rect;
var label: Rect;
var window: Rect;
var guiSkin: GUISkin;
var text: String = "Name";
var _field : Rect;
var simb: int;
function OnGUI() {

GUI.skin = guiSkin;


GUI.Label(label,"Player Name");

text = GUI.TextField(_field,text,simb);

window = GUI.Window (0, window, SetWindow, "");
}

function SetWindow(myId: int) {

if(GUI.Button(new Rect(5,30,200,40), "Start")){
Debug.Log("Srating...");
Application.LoadLevel("islandFirst");
}
if(GUI.Button(new Rect(5,90,200,40), "Options")){
/*	if(GUI.Label("Volume"));
	AudioListener.volume = GUI.HorizontalSlider(new Rect(40,200,200,20),AudioListener.volume,0,1);*/
}

if(GUI.Button(new Rect(5,150,200,40), "Exit")){
Application.Quit();
}


GUI.DragWindow(new Rect(0,0, Screen.width, Screen.height));
}