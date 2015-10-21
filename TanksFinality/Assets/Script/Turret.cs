using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour
{
    public enum AimingMode
    {
        Object, Point, Mouse, Camera
    }

    public AimingMode AimMode;

    public Transform Hull;
    public Transform Turret_;
    public Transform MainGun;
    public float AngleY = 5;
    public float AngleX = 45;

    public Vector3 targetPoint;
    public string targetName;
    private Vector3 localTargetPoint;

    public Transform target;
    Camera cam;
    private Ray camRay;
    private RaycastHit hit;
    public float ySpeed = 15f;
    public float xSpeed = 15f;

    public Texture aim;
    Quaternion q;
    Quaternion t;

    Rect r;

    Vector3 aimpos;

    void Start()
    {
        if (Hull == null)
            Hull = transform.FindChild("Hull").transform;
        if (Turret_ == null)
            Turret_ = transform.FindChild("Turret").transform;
        if (MainGun == null)
            MainGun = transform.FindChild("Turret").transform.FindChild("MainGun").transform;
        cam = transform.FindChild("Camera").gameObject.GetComponent<Camera>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            AimMode = AimingMode.Object;
            camRay = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(camRay, out hit))
            {
                target = hit.transform;
                targetName = target.name;
            }
        }

        if (!target)
            AimMode = AimingMode.Mouse;

        switch (AimMode)
        {
            case AimingMode.Object:
                if (!target) break;
                targetPoint = target.position;
                break;
            case AimingMode.Mouse:
                if (!cam) break;
                camRay = cam.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(camRay, out hit))
                {
                    targetPoint = hit.point;
                }
                else
                    targetPoint = camRay.GetPoint(100000f);
                break;
            case AimingMode.Camera:
                if (!cam) break;
                if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit))
                    targetPoint = hit.point;
                else
                    targetPoint = cam.transform.forward * 10000f;
                break;
        }

        localTargetPoint = Hull.InverseTransformPoint(targetPoint);
        localTargetPoint.y = 0f;
        t = Quaternion.LookRotation(localTargetPoint);
        Turret_.localRotation = Quaternion.RotateTowards(Turret_.localRotation, t, ySpeed * Time.deltaTime);


        localTargetPoint = Turret_.InverseTransformPoint(targetPoint + (Hull.position - MainGun.position));
        localTargetPoint.x = 0f;

        if (localTargetPoint.z > 0f)
        {
            q = Quaternion.LookRotation(localTargetPoint);
            if (q.x <= AngleY / 180 && q.x >= -AngleY / 360)
                MainGun.localRotation = Quaternion.RotateTowards(MainGun.localRotation, q, xSpeed * Time.deltaTime);
        }



    }
}