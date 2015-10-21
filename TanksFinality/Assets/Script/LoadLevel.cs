using System.Linq;
using UnityEngine;
using UnityEngine.Networking;


public class LoadLevel : MonoBehaviour
{
    static public GameObject playerPref;

    void Awake()
    {
        NetworkManager nm = GameObject.FindObjectOfType<NetworkManager>();
        if (playerPref != null)
            nm.playerPrefab = playerPref;
        else
            nm.playerPrefab = Resources.FindObjectsOfTypeAll(typeof(GameObject)).Where(w => w.name == "Panzer_II").FirstOrDefault() as GameObject;
    }
}
