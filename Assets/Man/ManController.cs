using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManController : MonoBehaviour
{
    public enum ManStates
    {
        Idle, Walk, Run, Jump
    }


    [Range(3,5)]
    public float speed;
    public int jump;        //점프기능을 위해 변수 추가


    //Vector3 movenment = new Vector3();
    Rigidbody rd;
    Animator animator;
    public ManStates state;
    float h, v;


    

    //public AudioClip FBX_step;s

    private void Start()
    {
        rd = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {

        Move();
        Jump();
    }
    public void OnState()
    {
        switch (state)
        {
            case ManStates.Idle:
                animator.SetBool("IsWalk", false);
                break;
            case ManStates.Walk:
                animator.SetBool("IsWalk", true);
                break;
            case ManStates.Run:
                animator.SetBool("IsRun", true);
                break;
            case ManStates.Jump:
                animator.SetBool("IsJump", true);
                break;
        }
    }
    public void Move()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
       
        Vector3 vector3 = new Vector3(h, 0, v).normalized;

        transform.position += vector3 * speed * Time.deltaTime;
        transform.LookAt(transform.position + vector3);

        if (Input.GetKeyDown(KeyCode.R))
        {
            //Run이 비활성화 상태라면
            if (animator.GetBool("IsRun") == false)
            {
                state = ManStates.Run;
                speed = 5;
            }
            else //활성화 상태라면
            {
                animator.SetBool("IsRun", false);
                state = ManStates.Walk;
                speed = 3;
            }
            OnState();
        }


        if (h != 0 || v != 0)
        {
            state = ManStates.Walk;
        }
        if (h == 0 && v == 0)
        {
            state = ManStates.Idle;
        }
        OnState();
    }

    public void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rd.AddForce(Vector3.up * jump, ForceMode.Impulse);
            state = ManStates.Jump;
            OnState();
            Invoke("JumpExit", 1.0f);
        }
        OnState();
    }
    public void JumpExit()
    {
        animator.SetBool("IsJump", false);
    }

}


