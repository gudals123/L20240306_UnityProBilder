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
        float h = Input.GetAxisRaw("Horizontal");   //-1 ,0 , 1 (����)
        float v = Input.GetAxisRaw("Vertical");     //����

        Vector3 dir = new Vector3(h, 0, v).normalized;   //����ȭ( ��� �������� ����)

        rbody.velocity = dir * speed;

        transform.LookAt(transform.position+dir);   //��� ��ġ �Ǵ� Ʈ���� ���� ���ϵ��� ������Ʈ�� ȸ��

    }
}
