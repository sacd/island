/// <summary>
/// Main inv.
/// Отвечает за показ инвентаря и блокировку камеры
/// Вешать на игрока
/// </summary>
using UnityEngine;
using System.Collections;

//using System.Collections.Generic;

public class MainInv : MonoBehaviour
{
	
	private GameObject goA;	// Броня 
	private GameObject goS;	// Меч
	private GameObject goM; // Амулет

	public GameObject[] all_items = new GameObject[41];	// Элементы инвентаря
	
	public GameObject cm;	// Ссылка на камеру игрока
	
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		if (Input.GetKeyDown (KeyCode.I)) {
			if (Global.visable) {
				Global.visable = false;
				gameObject.GetComponent<MouseLook>().enabled = true;
				cm.GetComponent<MouseLook>().enabled = true;
			} else {
				Global.visable = true;
				gameObject.GetComponent<MouseLook>().enabled = false;
				cm.GetComponent<MouseLook>().enabled = false;
			}
		}	
	}
}