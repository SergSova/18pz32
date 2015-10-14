using UnityEngine;
using System.Collections;

public class temp1 : MonoBehaviour 
{
	bool b = true;

	void Update () 
	{
		//float pos_y = gameObject.transform.position.y;

		if (Time.time % 10 >= 0 && Time.time % 10 < 1.25 
			|| Time.time % 10 >= 2.5 && Time.time % 10 < 3.75
		    || Time.time % 10 >= 5 && Time.time % 10 < 6.25
		    || Time.time % 10 >= 6.25 && Time.time % 10 < 7.5) {
			b = true;
		}
		else
			b = false;
		
		if(b == true)
			gameObject.transform.Translate (Vector3.up * Time.deltaTime);
		else if(b == false)		
			gameObject.transform.Translate (Vector3.down * Time.deltaTime);
	}
}
