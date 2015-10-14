using UnityEngine;
using System.Collections;

public class thenShoot : MonoBehaviour
{

    [SerializeField]
    public int wallSrenght = 1;
    public bool infinity = false;
    private Collider Bul;

    public GameObject destroy;
    public WindZone wz;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet" && other.tag != "GameZoneCollider" && tag == "Wall")
        {
            Instantiate(destroy, transform.position, transform.rotation);
            Bul = other;
            Debug.Log(string.Format("Destroy {0}", Bul.name));
            Destroy(Bul.gameObject);

            wallSrenght--;
            if (wallSrenght == 0)
            {
                Instantiate(destroy, transform.position, transform.rotation);   //destroy
                Instantiate(wz, transform.position, transform.rotation);    //wind
                if (!infinity)
                    Destroy(gameObject);
            }

        }
    }
}
