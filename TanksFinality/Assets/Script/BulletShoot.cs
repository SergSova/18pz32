using UnityEngine;
using System.Collections;
using System.Linq;

public class BulletShoot : MonoBehaviour
{
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate = 1;
    private float nextFire;
    AudioSource fire;


    void Start()
    {
        fire = FindObjectsOfType<AudioSource>().Where(w => w.name == "Fire").FirstOrDefault();
        if (shotSpawn == null)
            shotSpawn = transform.FindChild("Turret").transform.FindChild("MainGun").transform.FindChild("SpawnBullet").transform;
    }

    void Update()
    {
        if (Input.GetButton("Fire1"))
            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                fire.Play();
            }
    }
}
