using UnityEngine;
using System.Collections;

public class zombieAI : MonoBehaviour
{

	private int Damage; //урон, наносимый цели(вам) 
	public float moveSpeed;//скорость передвижения  
	private float rotationSpeed;//скорость вращения, не трагоем ее. 
	public float rotationSpeedBase;//базовое значение скорости вращения, дальше расскажу для чего понадобится. 
	public int Health = 50;//здровье  
	public Transform Target;//цель(мы) 
	public float timerBaseTime = 0.5f;//базовое значение таймера 
	private float timer;//понадобится для создания задержки во время атаки 
	private float distToTarget;//дистанция до цели(нас) 

	void Start ()
	{ 
		rotationSpeed = rotationSpeedBase;//значение скорости поворота 
		GameObject g = GameObject.FindGameObjectWithTag ("Player");//ищем объект с тэгом Player, для этого нужно добавить тэг к игроку 
		Target = g.transform;//цель установлена 
	}
 
	void Update ()
	{ 
		Damage = Random.Range (1, 10);//задаем рандомный урон от 1 до 10 (Значение меняется каждую миллисекунду) 
		distToTarget = Vector3.Distance (Target.position, transform.position);//тут все и так понятно 
		if (distToTarget < 25) { 
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (Target.position - transform.position), rotationSpeed * Time.deltaTime);//поворачиваем ИИ на нас 
			transform.position += transform.forward * moveSpeed * Time.deltaTime;//теперь ИИ будет двигатся за нами 
		} 
		if (timer > 0) 
			timer -= Time.deltaTime; 
		if (timer < 0) 
			timer = 0;//создали работу таймера(Позаимствовано из урока romaan27 :) ) 
		if (distToTarget < 1) {//дистанция до цели, значение может быть любым 
			rotationSpeed = 0;//дабы ИИ не дергался при нахождении нас рядом с ним отключаем ему возможность поворачиваться. 
			if (timer == 0) { 
				Target.GetComponent<PlayerStats> ().MaxHealth -= Damage;//а вот тут в <..> вбиваем название скрипта в котором имеется переменная отвечающая за здоровье игрока. У меня переменная называется Health, а скрипт playerMoving 
				timer = timerBaseTime;//восстановили работу таймера 
			} 
		} 
		if (distToTarget > 1) { 
			rotationSpeed = rotationSpeedBase;//теперь ИИ может снова поворачиваться 
		} 
		if (Health < 1) { 
			DestroyObject (gameObject);//и если же здоровье на исходе, уничтожаем объект. (Я прописал отнятие ХП в другом скрипте с помощью GetComponent) 
		} 
	} 
}
