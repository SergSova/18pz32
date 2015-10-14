using UnityEngine;
using System.Collections;

public class TimeWindZoneWall : MonoBehaviour 
{
	public int TimeWall;
	void Update () 
	{
		//Debug.Log (Time.time);
		if (Time.time >= TimeWall) 
		{
			Destroy(gameObject);
		}
	}
}
