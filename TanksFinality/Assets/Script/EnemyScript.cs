using UnityEngine;
using System.Collections;
using System.Linq;

public class EnemyScript : MonoBehaviour
{
    public float DistanceFromPlayer = 30;
    public float DistanceFire = 10;

    public Transform turret;

    public int SpeedEnemy = 4;
    public int EnemyRotate = 4;

    public AnimationClip Idle;
    public AnimationClip Walk;
    public AnimationClip Run;

    public AnimationClip Attack_1;
    public AnimationClip Attack_2;

    private int Switch_Monstr;
    private int Switch_Attack;
    private float Time_delt;

    Animation animation;
    bool Switch_Player_Cube;

    public GameObject Cube_1;
    public GameObject Cube_2;
    public GameObject Cube_3;


    RaycastHit RCH_1;
    RaycastHit RCH_2;
    Vector3 Transf_Player_transf;
    Vector3 Transf_Cube_transf;

    private float nextFire;
    public GameObject bullet;
    public Transform shotSpawn;
    public float fireRate;
    AudioSource fire;

    void Start()
    {
        fire = FindObjectsOfType<AudioSource>().Where(w => w.name == "Fire").FirstOrDefault();
        animation = GetComponent<Animation>();
        Switch_Monstr = 0;
        Switch_Player_Cube = false;
    }


    void Update()
    {
        if (Switch_Player_Cube == false)
        {
            //находимся возле 1 куба едем к 2
            if (Vector3.Distance(transform.position, Cube_1.transform.position) <= 1f)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Cube_2.transform.position - transform.position), EnemyRotate * Time.deltaTime);
                Switch_Monstr = 1;
            }
            else if (Vector3.Distance(transform.position, Cube_2.transform.position) <= 1f)//находимся возле 2 куба едем к 3
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Cube_3.transform.position - transform.position), EnemyRotate * Time.deltaTime);
                Switch_Monstr = 1;
            }
            else if (Vector3.Distance(transform.position, Cube_3.transform.position) <= 1f)//находимся возле 3 куба едем к 1
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Cube_1.transform.position - transform.position), EnemyRotate * Time.deltaTime);
                Switch_Monstr = 1;
            }
            else if (RCH_1.collider == null)//если кубов поблизости нет
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Cube_1.transform.position - transform.position), EnemyRotate * Time.deltaTime);
                Switch_Monstr = 1;
            }

            //проверем если видно куб на расстоянии 200 тога едим к нему
            if (Physics.Raycast(transform.position, transform.forward, out RCH_1, 200.0f))
            {
                Debug.DrawLine(transform.position, RCH_1.collider.transform.position, Color.blue);
                if (RCH_1.collider.tag == "Cube")
                {
                    transform.position += transform.forward * SpeedEnemy * Time.deltaTime;
                }
            }
        }
        else
        {
            Switch_Monstr = 4;
            //
            turret.transform.rotation = Quaternion.Slerp(turret.transform.rotation, Quaternion.LookRotation(GameObject.FindGameObjectWithTag("Player").transform.position - turret.transform.position), (EnemyRotate * 2) * Time.deltaTime);
            if (Physics.Raycast(turret.transform.position, transform.forward, out RCH_2, DistanceFire * 10))
            {
                Debug.DrawLine(transform.position, RCH_2.collider.transform.position, Color.blue);
                if (RCH_2.collider.tag == "Player")
                {
                    if (Time.time > nextFire)
                    {
                        nextFire = Time.time + fireRate;
                        Instantiate(bullet, shotSpawn.position, shotSpawn.rotation);
                        fire.Play();
                    }
                }
            }
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(GameObject.FindGameObjectWithTag("Player").transform.position - transform.position), EnemyRotate * Time.deltaTime);
            transform.position += transform.forward * SpeedEnemy * Time.deltaTime;
        }

        if (GameObject.FindGameObjectWithTag("Player") != null)
            if (Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) <= DistanceFromPlayer)
            {
                Switch_Player_Cube = true;
            }

        if (Switch_Monstr == 0)
        {
            animation.Play(Idle.name);
        }


        if (Switch_Monstr == 1)
        {
            animation.Play(Walk.name);
        }


        if (Switch_Monstr == 2)
        {
            animation.Play(Run.name);
        }




    }
}
