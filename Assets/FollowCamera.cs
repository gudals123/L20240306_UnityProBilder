using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;    //ī�޶� ���� ������Ʈ ��ġ
    public Vector3 Offset;      //ī�޶� ���� ��ǥ


    //ī�޶󿡼� ���� ���������� ��°� �� ���Ҽ� �ִ�.
    void FixedUpdate()
    {
        //ī�޶� ��ġ = Ÿ�� ��ġ + ���� ��ǥ
        transform.position = target.position + Offset;
    }
}
