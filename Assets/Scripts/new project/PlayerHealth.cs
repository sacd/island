// Выводит бар, показывающий состояние здоровья игрока

using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public int maxHealth = 100;
	public int _curHealth = 100;	
	
	void Start () {
		
		if(maxHealth<1) maxHealth=1;
		_curHealth = maxHealth;
	}
	void OnGUI(){
		GUI.Box(new Rect(10,10,Screen.width /8,20),"Health " + _curHealth + "/" + maxHealth);
	}
	
	public void ApplyDamage(int damage){
		_curHealth -= damage;

		if(_curHealth <= 0){
			Damage();
		}
	}
	public void Damage(){
		Application.LoadLevel("menu");
}
}
