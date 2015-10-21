using UnityEngine;
using System.Collections;
using System.Linq;

public class SpawnStatic : MonoBehaviour
{

    public float SpawnTime = 3;
    //float nextSpawn;
    public GameObject[] st;
    GameObject[] dead;
    //string[] resp;


    // Update is called once per frame
    void Update()
    {
        dead = GameObject.FindGameObjectsWithTag("EditorOnly");

        if (dead.Length > 0)
        {
            //resp = dead.Select(s=>s.name).ToArray();
            //nextSpawn = Time.time + SpawnTime;
            foreach (GameObject item in dead)
            {
                GameObject ds = st.Where(w => w.name == item.name).FirstOrDefault();
                ds.transform.position = item.transform.position;
                ds.transform.rotation = item.transform.rotation;
                Destroy(item, SpawnTime);
                string[] c = GameObject.FindGameObjectsWithTag("Respawn").Select(s => s.name).ToArray();
                if (!c.Contains(ds.name))
                {
                    Instantiate(ds).name = ds.name;
                }
            }
        }
    }

}
