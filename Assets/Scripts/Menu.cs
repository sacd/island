﻿using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
  
   private void OnGUI()
   {      
      if(GUI.Button(new Rect((Screen.width / 2) - 100, (Screen.height / 2) - 50, 200,30) , "First Scene"))
      {
         Application.LoadLevel("islandFirst");
      }

		if(GUI.Button(new Rect((Screen.width / 2) - 100, (Screen.height / 2) + 50, 200,30) , "Quit"))
      {
         Application.Quit();
      }
   }
}