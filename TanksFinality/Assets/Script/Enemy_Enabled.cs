using UnityEngine;
using UnityEngine.Networking;

public class Enemy_Enabled : NetworkBehaviour
{

	// Use this for initialization
	void Start () {
        {
            GetComponent<EnemyScript>().enabled = true;
            GetComponent<HealthAndArmor>().enabled = true;
        }
    }
}
