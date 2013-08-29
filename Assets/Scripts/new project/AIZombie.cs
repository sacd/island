// AI with using NavMesh
using UnityEngine;
using System.Collections;

public class AIZombie : MonoBehaviour
{
	public NavMeshAgent agent;
	public Transform target;
<<<<<<< HEAD
	float startAgentSpeed;
	public string AnimationEnemyAttackName;
	public int damage;
=======
	public  float startAgentSpeed;
	public string AnimationEnemyAttackName;
	public float damage;
>>>>>>> 262042335302a09be44edbe51ce12aa10240bf5f
	
	void AttackZombie ()
	{
		animation.Play (AnimationEnemyAttackName);
<<<<<<< HEAD
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		if (Vector3.Distance (transform.position, player.transform.position) <= 2) {
=======
		
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		if (Vector3.Distance (transform.position, player.transform.position) <= 3) {
>>>>>>> 262042335302a09be44edbe51ce12aa10240bf5f
			player.SendMessageUpwards ("ApplyDamage", damage);
		}
	}
	
	void Start ()
	{
		startAgentSpeed = agent.speed;
		agent = GetComponent<NavMeshAgent> ();
<<<<<<< HEAD

	}
	
	// Update is called once per frame
=======
	}
	
>>>>>>> 262042335302a09be44edbe51ce12aa10240bf5f
	void Update ()
	{
		GameObject player = GameObject.FindGameObjectWithTag ("Player");	
		agent.SetDestination (target.position);
	
<<<<<<< HEAD
	//	if (Vector3.Distance (transform.position, player.transform.position) <= 10) {
	//		target = player.transform;			 	
	//	}
		if (Vector3.Distance (transform.position, player.transform.position) <= 1) {
			if (!animation.IsPlaying(AnimationEnemyAttackName)) {
				AttackZombie();
=======
		if (Vector3.Distance (transform.position, player.transform.position) <= 10) {
			target = player.transform;			 	
		}
		if (Vector3.Distance (transform.position, player.transform.position) <= 2) {
			if (!animation.IsPlaying (AnimationEnemyAttackName)) {
				AttackZombie ();
>>>>>>> 262042335302a09be44edbe51ce12aa10240bf5f
			}
			agent.speed = 0;			 	
		} else {
			agent.speed = startAgentSpeed;
		}
	}
}