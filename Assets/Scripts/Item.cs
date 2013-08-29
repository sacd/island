/// <summary>
/// Item.
/// Отвечает за хранение информации о предмете который можно поместить в инвентарь
/// Вешать на предмет
/// </summary>
using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour
{
	public string Sname;		// Имя для отображения
	public int Hunger;			// Количество регенирируемых очков
	GameObject player;
	
	private bool visable = false;	// Информация

	void Start ()
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	void OnMouseOver ()
	{
		visable = true;
	}
	
	void OnMouseExit ()
	{
		visable = false;
	}
	
	void OnGUI ()
	{
		// Показ информации
		if (visable == true) {
			GUI.Label (new Rect (Input.mousePosition.x + 15, Screen.height - Input.mousePosition.y, 200, 80), "Name: " + Sname);
			GUI.Label (new Rect (Input.mousePosition.x + 15, Screen.height - Input.mousePosition.y + 15, 200, 80), "Food: " + Hunger);
		}
	}
	
	void OnMouseDown ()
	{
		player.SendMessageUpwards ("ApplyHunger", Hunger);
		Destroy (gameObject);

	}
}