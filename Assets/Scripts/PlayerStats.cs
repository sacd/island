using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour
{
	
	public int MaxHealth; 
	public int CurHealth; 
	
	public bool AttackStats = false;
	
	// Update is called once per frame
	void Update ()
	{
		if (MaxHealth < CurHealth)
			CurHealth = MaxHealth;
		if (CurHealth < 0)
			CurHealth = 0;
	}
	
	void OnCollisionEnter (Collision myCollision)
	{
		if (AttackStats) {
			if (myCollision.gameObject.tag == "zombie") {
				CurHealth = CurHealth - 5;
			}
		}
	}
	
}
