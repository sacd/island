using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class MiniMap : MonoBehaviour
{
	public float offset;

	void Update ()
	{
		transform.localPosition = new Vector3 (-Screen.width * 0.5f + offset, -Screen.height * 0.5f + offset, 0f);
		float mapSize = Screen.height * 0.3f;
		transform.localScale = new Vector3 (mapSize, mapSize, 0f);
	}
}
