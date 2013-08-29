using UnityEngine;
using System.Collections;

public class MonsterAI1 : MonoBehaviour
{

	public Transform target;
	public int moveSpeed;
	public int rotationSpeed;
	public float maxDistance;
	public GameObject ObjPoint;
	public int ReactionDistance;
	private float curDistance;
	private Transform myTransform;
	private Transform Point;
	private float PointDistance;
	public AnimationClip a_Idle;
	public float a_IdleSpeed = 1;
	public AnimationClip a_Walk;
	public float a_WalkSpeed = 1;
	public AnimationClip a_Attack;
	public float a_AttackSpeed = 1;
		
	public enum MonsterStat
	{
		idle,
		walkPlayer,
		walkPoint,
		attack
	}
	
	private MonsterStat _monsterStat;
	
	private PlayerStats ps;
	
	void Awake ()
	{
		myTransform = transform;
		
	}

	// Use this for initialization
	void Start ()
	{
		GameObject go = GameObject.FindGameObjectWithTag ("Player");

		target = go.transform;
		Point = ObjPoint.transform;
		
		animation [a_Idle.name].speed = a_IdleSpeed;
		animation [a_Walk.name].speed = a_WalkSpeed;
		animation [a_Attack.name].speed = a_AttackSpeed;
		
		ps = go.GetComponent<PlayerStats> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		
		curDistance = Vector3.Distance (target.position, myTransform.position);
		PointDistance = Vector3.Distance (Point.position, myTransform.position);
		
		//если позволяет дистанция двигаемся к цели(проверка на минимальную дистанцию)
		if ((curDistance >= maxDistance) && (curDistance <= ReactionDistance)) {
			_monsterStat = MonsterStat.walkPlayer;
		} else if ((curDistance > ReactionDistance) && (PointDistance > 1)) {
			_monsterStat = MonsterStat.walkPoint;
		} else if (curDistance <= maxDistance) {
			_monsterStat = MonsterStat.attack;
		} else {
			_monsterStat = MonsterStat.idle;
		}
		
		switch (_monsterStat) {
		case MonsterStat.idle:
				//чертим линию
			Debug.DrawLine (target.position, myTransform.position, Color.yellow);
			animation.CrossFade (a_Idle.name);
			ps.AttackStats = false;
			break;
			
		case MonsterStat.walkPlayer:
				//чертим линию
			Debug.DrawLine (target.position, myTransform.position, Color.red);
			
				// Разворачиваемся в сторону игрока
			myTransform.rotation = Quaternion.Slerp (myTransform.rotation, Quaternion.LookRotation (target.position - myTransform.position), rotationSpeed * Time.deltaTime);
				//двигаемся к цели
			myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
			
			animation.CrossFade (a_Walk.name);
			ps.AttackStats = false;
			break;
			
		case MonsterStat.walkPoint:
				//чертим линию
			Debug.DrawLine (Point.position, myTransform.position, Color.green);
			Debug.DrawLine (target.position, myTransform.position, Color.yellow);
			
				// Разворачиваемся в сторону игрока
			myTransform.rotation = Quaternion.Slerp (myTransform.rotation, Quaternion.LookRotation (Point.position - myTransform.position), rotationSpeed * Time.deltaTime);
				//двигаемся к цели
			myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
			
			animation.CrossFade (a_Walk.name);
			ps.AttackStats = false;
			break;
			
		case MonsterStat.attack:
				//чертим линию
			Debug.DrawLine (target.position, myTransform.position, Color.red);
			
				// Разворачиваемся в сторону игрока
			myTransform.rotation = Quaternion.Slerp (myTransform.rotation, Quaternion.LookRotation (target.position - myTransform.position), rotationSpeed * Time.deltaTime);
			animation.CrossFade (a_Attack.name);
			ps.AttackStats = true;
			break;
		}
	}
}