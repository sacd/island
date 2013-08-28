using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour
{
	public Transform startPoint;
	public float force;
	public string AnimationAttackName;
	public int damage;
	
	void AttackMethod ()
	{			
		animation.Play (AnimationAttackName);
		
		RaycastHit hit;
		Vector3 direct = startPoint.TransformDirection (Vector3.forward * force);
		
		Debug.DrawRay (startPoint.position, direct, Color.red);
		if (Physics.Raycast (startPoint.position, direct, out hit, force)) {
			if (hit.rigidbody) {
				hit.rigidbody.AddForceAtPosition (direct, startPoint.position);
			}
			if (hit.transform.tag == "zombie") {
 				hit.transform.SendMessageUpwards ("ApplyDamage", damage);
			}
		}
	}
	
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Mouse0) && !animation.IsPlaying (AnimationAttackName)) {
			AttackMethod ();
		}
	}
}