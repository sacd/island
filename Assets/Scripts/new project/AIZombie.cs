// AI with using NavMesh
using UnityEngine;
using System.Collections;

public class AIZombie : MonoBehaviour
{
	public NavMeshAgent agent;
	public Transform target;
	float startAgentSpeed;
	public string AnimationEnemyAttackName;
	public int damage;
	
	void AttackZombie ()
	{
		animation.Play (AnimationEnemyAttackName);
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		if (Vector3.Distance (transform.position, player.transform.position) <= 2) {
			player.SendMessageUpwards ("ApplyDamage", damage);
		}
	}
	
	void Start ()
	{
		startAgentSpeed = agent.speed;
		agent = GetComponent<NavMeshAgent> ();

	}
	
	// Update is called once per frame
	void Update ()
	{
		GameObject player = GameObject.FindGameObjectWithTag ("Player");	
		agent.SetDestination (target.position);
	
	//	if (Vector3.Distance (transform.position, player.transform.position) <= 10) {
	//		target = player.transform;			 	
	//	}
		if (Vector3.Distance (transform.position, player.transform.position) <= 1) {
			if (!animation.IsPlaying(AnimationEnemyAttackName)) {
				AttackZombie();
			}
			agent.speed = 0;			 	
		} else {
			agent.speed = startAgentSpeed;
		}
	}
}