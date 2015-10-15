using UnityEngine;
using System.Collections;

public class Shuting : MonoBehaviour
{
    [SerializeField]
    private int bulletForce = 5000;
    public GameObject ShootSpalsh;


    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * bulletForce;
    }

    void Update()
    {
        Instantiate(ShootSpalsh, transform.position, transform.rotation);
    }
}
