using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;    //카메라가 보일 오브젝트 위치
    public Vector3 Offset;      //카메라 간격 좌표


    //카메라에서 고정 프레임으로 잡는게 더 편할수 있다.
    void FixedUpdate()
    {
        //카메라 위치 = 타겟 위치 + 간격 좌표
        transform.position = target.position + Offset;
    }
}
