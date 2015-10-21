using UnityEngine;
using System.Collections;

public class TextDemageFly : MonoBehaviour {

    void Start()
    {
        Destroy(gameObject, 10);
    }
	// Update is called once per frame
	void Update () {
        transform.Translate(0,0.3f,0);
	}
}
