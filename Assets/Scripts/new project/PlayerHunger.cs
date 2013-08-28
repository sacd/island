// Выводит бар, показывающий состояние здоровья игрока
using UnityEngine;
using System.Collections;

public class PlayerHunger : MonoBehaviour
{
	public int maxHealth = 100;
	int curHealth = 100;
	public int maxHunger = 100;
	int curHunger = 0;
	public   int maxSleep = 100;
	int curSleep = 0;
	
	public void OnGUI ()
	{
		GUI.Box (new Rect (10, 10, Screen.width / 8, 25), "Health " + curHealth + "/" + maxHealth);
		GUI.Box (new Rect (10, 36, Screen.width / 8, 25), "Hunger " + curHunger + "/" + maxHunger);
		GUI.Box (new Rect (10, 62, Screen.width / 8, 25), "Sleep " + curSleep + "/" + maxSleep);
	}
	
	public void ApplyDamage (int damage)
	{
		curHealth -= damage;

		if (curHealth <= 0) {
			Damage ();
		}
	}
	
	public void Hunger(){
	}
	public void Damage ()
	{
		Application.LoadLevel ("menu");
	}
}
