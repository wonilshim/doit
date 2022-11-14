using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float hAxis;
    float vAxis;
    bool  wDown;
    bool jDown;
    bool isJump;
    bool isDodge;

    Vector3 moveVec;
    Vector3 dodgeVec;


    public float speed = 4.0f;

    Animator anim;
    Rigidbody rigid;

    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        rigid = GetComponent<Rigidbody>();
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    void GetInput(){
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        wDown = Input.GetButton("Walk");
        jDown = Input.GetButtonDown("Jump");
    }

    void Move(){
        moveVec = new Vector3(hAxis, 0, vAxis).normalized;
        if (isDodge)
            moveVec = dodgeVec;

        transform.position += moveVec * Time.deltaTime * speed * (wDown ? 0.3f : 1f);

        anim.SetBool("bIsRun", moveVec != Vector3.zero);
        anim.SetBool("bIsWalk", wDown);
    }

    void Turn(){
        transform.LookAt(transform.position + moveVec);
    }

    void Jump(){
        if(jDown && moveVec==Vector3.zero && !isJump && !isDodge) {
            rigid.AddForce(Vector3.up * 10, ForceMode.Impulse);

            anim.SetBool("bIsJump", true);
            anim.SetTrigger("doJump");

            isJump = true;
        }
    }

    void Dodge()
    {
        if (jDown && moveVec != Vector3.zero && !isJump && !isDodge)
        {
            speed *= 2;
            anim.SetTrigger("doDodge");
            isDodge = true;
            dodgeVec = moveVec;

            Invoke("DodgeOut", 0.4f);
        }
    }

    void DodgeOut()
    {
        speed *= 0.5f;
        isDodge = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            anim.SetBool("bIsJump", false);
            isJump = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();   
        Move();
        Turn();
        Jump();
        Dodge();
    }
}
