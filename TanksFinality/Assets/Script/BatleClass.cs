using UnityEngine;
using UnityEngine.Networking;

public class BatleClass : NetworkBehaviour
{
    public delegate void TakeDamageDelegate(int side, int damage);
    public delegate void DieDelegate();
    public delegate void RespawnDelegate();

    float deathTimer;
    bool alive;
    int health;

    [SyncEvent(channel = 1)]
    public event TakeDamageDelegate EventTakeDamage;

    [SyncEvent]
    public event DieDelegate EventDie;

    [SyncEvent]
    public event RespawnDelegate EventRespawn;

    [Server]
    void TakeDamage(int amount)
    {
        if (!alive)
            return;

        if (health > amount)
        {
            health -= amount;
        }
        else
        {
            health = 0;
            alive = false;
            // send die event to all clients
            EventDie();
            deathTimer = Time.time + 5.0f;
        }
    }

    [ServerCallback]
    void Update()
    {
        if (!alive)
        {
            if (Time.time > deathTimer)
            {
                Respawn();
            }
            return;
        }
    }

    [Server]
    void Respawn()
    {
        alive = true;
        // send respawn event to all clients
        EventRespawn();
    }
}
