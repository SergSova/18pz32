using UnityEngine;
using System.Collections;

public class PlayerContol : MonoBehaviour
{
    Rigidbody body;
    public float speed = 10;
    public float rotate = 3;

    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float r = Input.GetAxis("Horizontal");
        float d = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        this.transform.Translate(0, 0, d, Space.Self);
        body.AddForce(Vector3.forward, ForceMode.Force);
        this.transform.Rotate(0f, r * rotate, 0f);
    }
}
