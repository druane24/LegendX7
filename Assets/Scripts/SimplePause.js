#pragma strict

public var pauseGame : boolean = false;
private var showGUI : boolean = false;

function Update()
{
	if(Input.GetKeyDown("p"))
	{
		pauseGame = true;
		
    	if(pauseGame == true)
    	{
    		Time.timeScale = 0;
    		showGUI = true;
    	}
    }
    
    if(pauseGame == false)
    {
    	Time.timeScale = 1;
    	showGUI = false;
    }
    
    if(showGUI == true)
    {
    	  gameObject.Find("PauseGUI").GetComponent.<GUITexture>().enabled = true;  
    }
    
    else
    {
    	gameObject.Find("PauseGUI").GetComponent.<GUITexture>().enabled = false;  
    }
}