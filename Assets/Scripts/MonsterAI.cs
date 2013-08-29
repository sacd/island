using UnityEngine;
using System.Collections;

public class MonsterAI : MonoBehaviour {
	
	public Transform target;    // Цель
	public int moveSpeed;       // Скорость перемещения
	public int rotationSpeed;   // Скорость поворота
	public float maxDistance;      // Максимальное приближение к игроку
	private float curDistance; // Текущая дистанция
	public int ReactionDistance; // Дистанция на которой монстр реагирует
	private float PointDistance; // Дистанция до поинта
	public GameObject ObjPoint; // Объект поинта
	private Transform Point; // Трансформ поинта для возвращения
	
	private Transform myTransform;  // Временная переменная для хранения ссылки на свойство transform
	
	// Анимации
	public AnimationClip a_Idle;
	public float a_IdleSpeed = 1;
	public AnimationClip a_Walk;
	public float a_WalkSpeed = 1;
	
	public enum MonsterStat //перечисление всех состояний курсора
   	{
    	idle,
		walkPlayer,
		walkPoint
   	}
	
	private MonsterStat _monsterStat;


	
	void Awake(){
		//ссылка на transform чтоб сократить время обращения его в теле скрипта
		myTransform = transform;
		
	}

	// Use this for initialization
	void Start () {
		//ищем по тегу player
		GameObject go = GameObject.FindGameObjectWithTag("Player");
		//поставить на него прицел
		target = go.transform;
		Point = ObjPoint.transform;
		
		animation[a_Idle.name].speed = a_IdleSpeed;
		animation[a_Walk.name].speed = a_WalkSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		
		curDistance = Vector3.Distance(target.position, myTransform.position);
		PointDistance = Vector3.Distance(Point.position, myTransform.position);
		
		//если позволяет дистанция двигаемся к цели(проверка на минимальную дистанцию)
		if((curDistance >= maxDistance) && (curDistance <= ReactionDistance)){
			_monsterStat = MonsterStat.walkPlayer;
		}
		else if((curDistance > ReactionDistance) && (PointDistance > 1))
		{
			_monsterStat = MonsterStat.walkPoint;
		}
		else 
		{
			_monsterStat = MonsterStat.idle;
		}
		
		switch(_monsterStat){
			case MonsterStat.idle:
				animation.CrossFade(a_Idle.name);
			break;
			
			case MonsterStat.walkPlayer:
				// Разворачиваемся в сторону игрока
				myTransform.rotation = Quaternion.Slerp(myTransform.rotation,Quaternion.LookRotation(target.position - myTransform.position),rotationSpeed*Time.deltaTime);
				//двигаемся к цели
				myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
			
				animation.CrossFade(a_Walk.name);
			break;
			
			case MonsterStat.walkPoint:
				// Разворачиваемся в сторону игрока
				myTransform.rotation = Quaternion.Slerp(myTransform.rotation,Quaternion.LookRotation(Point.position - myTransform.position),rotationSpeed*Time.deltaTime);
				//двигаемся к цели
				myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
			
				animation.CrossFade(a_Walk.name);
			break;
		}
	}
}