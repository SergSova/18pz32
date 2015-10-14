using UnityEngine;
using System.Collections;

public class BulletDistanseDestroy : MonoBehaviour {

	void OnTriggerExit(Collider other)
    {
        if(other.tag=="Bullet")
        {
            Destroy(other.gameObject);
        }
    }
}
