using UnityEngine;
using System.Collections;

public class WindOnWall : MonoBehaviour 
{	
	public int timeWind = 2;
	WindZone wz = new WindZone ();

	void Update () 
	{
		wz.windMain = 3;
		wz.windTurbulence = 5;
		wz.windPulseMagnitude = 0.1f;
		wz.windPulseFrequency = 1;

		Debug.Log (Time.time);
		if (Time.time >= timeWind) 
		{
			wz.windTurbulence = 0;
			wz.windMain = 0;
			Destroy(gameObject);
		}
	}
}
