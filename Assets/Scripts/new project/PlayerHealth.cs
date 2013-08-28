// Выводит бар, показывающий состояние здоровья игрока
using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
	public float maxHealth = 100;
	float curHealth = 100;
	public float maxHunger = 100;
	public float curHunger = 100;
	public float maxSleep = 100;
	float curSleep = 100;
	
	public void OnGUI ()
	{
		GUI.Box (new Rect (10, 10, Screen.width / 8, 25), "Health " + (int)curHealth + "/" + maxHealth);
		GUI.Box (new Rect (10, 36, Screen.width / 8, 25), "Hunger " + (int)curHunger + "/" + maxHunger);
		GUI.Box (new Rect (10, 62, Screen.width / 8, 25), "Sleep " + (int)curSleep + "/" + maxSleep);
	}
	
	public void ApplyDamage (int damage)
	{
		curHealth -= damage;

		if (curHealth <= 0) {
			Damage ();
		}
	}
	
	public void ApplyHunger (int Hunger)
	{
		curHunger += Hunger;
	}
	
	public void Damage ()
	{
		Application.LoadLevel ("menu");
	}
	
	void Update ()
	{
		curHunger -= 0.001f;
		curSleep -= 0.001f;
	}
}
