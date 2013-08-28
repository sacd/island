// Выводит бар, показывающий состояние здоровья игрока
using UnityEngine;
using System.Collections;

public class ZombieHealth : MonoBehaviour
{
	public int maxHealth = 100;
	public int _curHealth = 100;
	
	void Start ()
	{
		if (maxHealth < 1)
			maxHealth = 1;
		_curHealth = maxHealth;
	}
	
	public void AppleDamage (int damage)
	{
		_curHealth -= damage;
		
		if (_curHealth <= 0) {
			Damage ();
		}
	}

	public void Damage ()
	{
		Destroy (gameObject);
	}
}
