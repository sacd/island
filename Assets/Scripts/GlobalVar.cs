/// <summary>
/// Global variable.
/// Хранит глобальные переменные
/// Вещать на любой неизменяемый объект
/// </summary>
using UnityEngine;
using System.Collections;

public class GlobalVar : MonoBehaviour {
	
	void Awake () {
		Global.stats = 40;
	}

}

public static class Global {
	
	public static bool visable;	// Показывать инвентарь?
	public static int stats;	// Номер ячейки подбираемого предмета
	
}