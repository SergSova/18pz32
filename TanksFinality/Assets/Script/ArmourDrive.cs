﻿using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class ArmourDrive : NetworkBehaviour
{

    float veloMyMax = 10, veloMyCurr = 0; //переменные, которые использую я. Максимальная доступная и желаемая скорости, м/с.
    float veloSvrMax = 10, veloSvrCurr = 0; //переменные, которые использует мой дух. Максимально доступная и требуемая скорости, м/с.
    float SpeedRotate = 3, veloMyCurrRot = 0;
    private float veloSvrCurrRot;
    float periodSvrRpc = 0.02f; //как часто сервер шлёт обновление картинки клиентам, с.
    float timeSvrRpcLast = 0; //когда последний раз сервер слал обновление картинки

    void Awake()
    {
        //Костыль: приподнять игрока на 110см выше, чтобы не проваливался в ландшафт
        //TODO разобраться с координатами респавнинга игроков.
        this.transform.position = new Vector3(0, 1.1f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isLocalPlayer)
        //Код исполняется только у меня
        {
           
            //Формируем новое требование по скорости
            float veloMyNew = 0;
            veloMyNew += Input.GetKey(KeyCode.W) ? veloMyMax : 0;
            veloMyNew += Input.GetKey(KeyCode.S) ? -veloMyMax : 0;
            if (veloMyCurr != veloMyNew)
            //Если требование по скорости изменилось, то шлём на сервер новое требование
            {
                CmdDrive(veloMyCurr = veloMyNew);
            }

            veloMyCurrRot = Input.GetAxis("Horizontal") * SpeedRotate;
            if (veloMyCurrRot != 0)
                CmdRotate(veloMyCurrRot);
            //
        }
    }

    [Command(channel = 0)]
    void CmdDrive(float veloSvrNew)
    {
        if (this.isServer)
        //Мой дух принимает и проверяет команду.
        {
            //Проверяем моё требование на валидность.
            veloSvrNew = Mathf.Clamp(veloSvrNew, -veloSvrMax, veloSvrMax);
            //Устанавливаем текущее значение требуемой мною скорости для духа.
            veloSvrCurr = veloSvrNew;
            //Исполнять будет дух позже.
        }
    }

    [Command(channel = 0)]
    void CmdRotate(float veloSvrNew)
    {
        if (this.isServer)
        //Мой дух принимает и проверяет команду.
        {
            //Устанавливаем текущее значение угла для духа.
            veloSvrCurrRot = veloSvrNew;
            //Исполнять будет дух позже.
        }
    }

    void FixedUpdate()
    {
        if (this.isServer)
        //Код исполняется только у духа
        {
            //Обработать мои команды
            this.transform.Translate(0, 0, veloSvrCurr * Time.deltaTime, Space.Self);
            this.transform.Rotate(0f, veloSvrCurrRot, 0f);
            if (timeSvrRpcLast + periodSvrRpc < Time.time)
            //Если пора, то выслать координаты всем моим аватарам
            {
                RpcUpdateUnitPosition(this.transform.position);
                RpcUpdateUnitOrientation(this.transform.rotation);
                timeSvrRpcLast = Time.time;
            }
        }
    }

    [ClientRpc(channel = 0)]
    void RpcUpdateUnitPosition(Vector3 posNew)
    {
        if (this.isClient)
        //Мои аватары копируют состояние моего духа.
        {
            this.transform.position = posNew;
        }
    }

    [ClientRpc(channel = 0)]
    void RpcUpdateUnitOrientation(Quaternion oriNew)
    {
        if (this.isClient)
        //Мои аватары копируют состояние моего духа.
        {
            this.transform.rotation = oriNew;
        }
    }


}
