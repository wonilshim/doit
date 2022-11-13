using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float hAxis;
    float vAxis;
    bool  wDown;

    Vector3 moveVec;

    public float speed = 2.0f;

    Animator anim;

    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }


    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {

        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        wDown = Input.GetButton("Walk");

        moveVec = new Vector3(hAxis, 0, vAxis).normalized;

        transform.position += moveVec * Time.deltaTime * speed * (wDown ? 0.3f : 1f);

        anim.SetBool("bIsRun", moveVec != Vector3.zero);
        anim.SetBool("bIsWalk", wDown);

        transform.LookAt(transform.position + moveVec);
        
    }
}
