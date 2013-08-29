var _gameMode: boolean = true;
var _menuMode: boolean = false;
var _optionsMode: boolean = false;

var resume: Rect;
var options: Rect;
var quit: Rect;

function Update() 
{

	if(Input.GetKeyDown(KeyCode.Escape))
	{
	_menuMode=true;
	_gameMode=false;
	_optionsMode=false;

	}
	
	if(!_gameMode && !_optionsMode && _menuMode)
	{

	Time.timeScale = 0;
	var m = GameObject.Find("Main Camera").GetComponent("MouseLook");
	m.enabled= false;
	
	var f = GameObject.Find("First Person Controller").GetComponent("MouseLook");
	f.enabled = false;
	
	}
	if(_gameMode && !_optionsMode && !_menuMode)
	{

	Time.timeScale = 1;
	var _m = GameObject.Find("Main Camera").GetComponent("MouseLook");
	m.enabled= true;
	
	var _f = GameObject.Find("First Person Controller").GetComponent("MouseLook");
	f.enabled = true;
	}
	
if(!_gameMode && _optionsMode && !_menuMode)
	{

	Time.timeScale = 0;
	var _2m = GameObject.Find("Main Camera").GetComponent("MouseLook");
	m.enabled= false;
	
	var _2f = GameObject.Find("First Person Controller").GetComponent("MouseLook");
	f.enabled = false;
	}
}

	
function OnGUI()
{
	if(_menuMode)
	{

	
	if(GUI.Button(resume,"Resume"))
	{
		_menuMode = false;
		_optionsMode = false;
		_gameMode = true;
		GameObject.Find("First Person Controller").GetComponent("MouseLook").enabled= true;
		
	
	}
	
		if(GUI.Button(options,"Options"))
	{
		_menuMode = false;
		_optionsMode = true;
		_gameMode = false;
	}
	
		if(GUI.Button(quit,"Quit"))
	{
		Application.Quit();
	}
	}	

/*if(_optionsMode)
{
	GUI.Label= new label(200,200,200,200);
	AudioListener.volume = GUI.HorizontalSlider(new Rect(40,200,200,20),AudioListener.volume,0,1);
}
}*/
}