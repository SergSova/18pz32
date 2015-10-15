using UnityEngine;
using System.Collections;

public class HealthAndArmor : MonoBehaviour
{
    //BatleClass batle;
    public float PlayerHealth = 100;
    public float PlayerArmor = 0f;
    public GameObject DestroyPlayer;
    public GameObject DestroyedPlayer;

    string stringHealth = "PlayerHealth = 0";
    string stringArmor = "PlayerArmor = 0";


    void OnTriggerEnter(Collider other)
    {
        if (tag == "Player" || tag == "Respawn")
            if (other.tag == "Bullet")
            {
                if (PlayerArmor <= 0)
                {
                    PlayerHealth -= other.GetComponent<Rigidbody>().velocity.magnitude / 10;
                    stringHealth = "PlayerHealth = " + PlayerHealth.ToString();
                }
                else
                {
                    PlayerArmor -= other.GetComponent<Rigidbody>().velocity.magnitude / 10;
                    stringArmor = "PlayerArmor = " + PlayerArmor.ToString();
                }
                Destroy(other.gameObject);
                Instantiate(DestroyPlayer, transform.position, transform.rotation);
                
            }
    }

    void OnGUI()
    {
        stringHealth = GUI.TextField(new Rect(10, 10, 200, 20), stringHealth, 25);
        stringArmor = GUI.TextField(new Rect(10, 30, 200, 20), stringArmor, 25);
    }

    void Update()
    {
        if (PlayerHealth <= 0)
        {
            GameObject g = (GameObject)Instantiate(DestroyedPlayer, transform.position, transform.rotation);
            g.name = name;
            Instantiate(DestroyPlayer, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }


}
