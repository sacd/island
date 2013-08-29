using UnityEngine;
using System.Collections;

public class example : MonoBehaviour
{
	public Transform target;
	private NavMeshAgent agent;

	void Start ()
	{
		
		agent = (NavMeshAgent)this.GetComponent ("NavMeshAgent");
	}

	void Update ()
	{ 
		animation.IsPlaying ("zombie_attack");
		agent.SetDestination (target.position);
	}
}
