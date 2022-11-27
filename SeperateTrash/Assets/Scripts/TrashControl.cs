using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashControl : MonoBehaviour
{
    public float moving_speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Moving
        transform.position += Vector3.down * Time.deltaTime * moving_speed;

        //Destory
        if(transform.position.y<-6f){
            Destroy(gameObject);
        }
        
    }
}
