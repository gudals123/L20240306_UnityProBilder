using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    public float speed;
    Rigidbody rbody;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();  
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");   //-1 ,0 , 1 (수평)
        float v = Input.GetAxisRaw("Vertical");     //수직

        Vector3 dir = new Vector3(h, 0, v).normalized;   //정규화( 모든 각도에서 동일)

        rbody.velocity = dir * speed;

        transform.LookAt(transform.position+dir);   //대상 위치 또는 트랜스 폼을 향하도록 오브젝트를 회전

    }
}
