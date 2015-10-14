using UnityEngine;
using System.Collections;

public class Wind : MonoBehaviour
{
    public int WindRadius = 10;
    void Update()
    {
        transform.Rotate(new Vector3(0, WindRadius, 0) * Time.deltaTime);
    }
}

