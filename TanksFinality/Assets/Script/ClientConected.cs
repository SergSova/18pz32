using UnityEngine;
using UnityEngine.Networking;

public class ClientConected : NetworkBehaviour
{

    void Start()
    {
        if (isLocalPlayer)
        {
            GameObject FPC = transform.FindChild("Camera").gameObject;
            FPC.GetComponent<Camera>().enabled = true;
            FPC.GetComponent<AudioListener>().enabled = true;
            GetComponent<Turret>().enabled = true;
            GetComponent<PlayerContol>().enabled = true;
            GetComponent<BulletShoot>().enabled = true;
            GetComponent<HealthAndArmor>().enabled = true;
            GetComponent<NetworkTransform>().enabled = true;

        }
    }
}
