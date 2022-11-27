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
        //Pick
        if(Input.GetMouseButtonDown(0)) {
            Debug.Log("Click");
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit);
            if(hit.collider != null) {
                GameObject currentTouch = hit.transform.gameObject;

                Debug.Log("Pick");

            }
        }
        //Moving
        transform.position += Vector3.down * Time.deltaTime * moving_speed;
       
    }
}
