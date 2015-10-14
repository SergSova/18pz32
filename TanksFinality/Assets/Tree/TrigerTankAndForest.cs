using UnityEngine;
using System.Collections;

public class TrigerTankAndForest : MonoBehaviour
{
    void Start()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log(other.name + "Enter in Forrest");
        }
    }
}
