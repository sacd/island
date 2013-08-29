using UnityEngine;
using System.Collections;

public class anim : MonoBehaviour {
	
	public AnimationClip attack;
	
	void Start () {	
	}
	
	
	void Update () {
		if(Input.GetMouseButton(0)){
			animation.Play(attack.name);
		}
	}
}
