using UnityEngine;
using System.Collections;

public class HealthAndArmor : MonoBehaviour
{
    public float PlayerHealth = 100;
    public float PlayerArmor = 0f;
    public GameObject DestroyPlayer;
    public GameObject DestroyedPlayer;
    public GameObject Text;
    public GameObject Texthealth;
    TextMesh tm;
    TextMesh thealth;

    public float maxPlayerHealth = 100;

    void Start()
    {
        tm = Text.GetComponent<TextMesh>();
        thealth = Texthealth.GetComponent<TextMesh>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (tag == "Player" || tag == "Respawn")
            if (other.tag == "Bullet")
            {
                var demage = other.GetComponent<Rigidbody>().velocity.magnitude / 10;
                if (PlayerArmor == 0)
                {
                    if ((PlayerHealth - demage) < 0)
                        PlayerHealth = 0;
                    else
                        PlayerHealth -= demage;
                }
                else
                {
                    if ((PlayerArmor - demage) < 0)
                    {
                        PlayerHealth = demage - PlayerArmor;
                        PlayerArmor = 0;
                    }
                    else
                        PlayerArmor -= demage;
                }

                tm.text = "-" + demage.ToString();

                Destroy(other.gameObject);
                Instantiate(tm, transform.position, other.transform.rotation);
                Instantiate(DestroyPlayer, transform.position, transform.rotation);
                
            }
    }

    //void OnGUI()
    //{
    //    stringHealth = GUI.TextField(new Rect(10, 10, 200, 20), stringHealth, 25);
    //    stringArmor = GUI.TextField(new Rect(10, 30, 200, 20), stringArmor, 25);
    //}

    void Update()
    {
        thealth.text = "Arm " + PlayerArmor.ToString() + "/ Health " + PlayerHealth.ToString();
        if (PlayerHealth <= 0)
        {
            GameObject g = (GameObject)Instantiate(DestroyedPlayer, transform.position, transform.rotation);
            g.name = name;
            Instantiate(DestroyPlayer, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }


}
