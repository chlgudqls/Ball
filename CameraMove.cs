using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    Transform playerTrs;
    Vector3 offSet;
    void Awake()
    {
        playerTrs = GameObject.FindGameObjectWithTag("Player").transform;
        offSet = transform.position - playerTrs.position;
    }

    void LateUpdate()
    {
        transform.position = playerTrs.position + offSet;
    }
}
