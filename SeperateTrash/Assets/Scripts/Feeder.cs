using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feeder : MonoBehaviour
{
    public Sprite[] trash_sprites;

    public GameObject base_trash;

    int time_cnt = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(time_cnt==500){
            Debug.Log("TEST");
            time_cnt=0;
            GameObject new_trash = Instantiate(base_trash);
            SpriteRenderer new_trash_spirite = new_trash.GetComponent<SpriteRenderer>();
            new_trash_spirite.sprite = trash_sprites[Random.Range(0,trash_sprites.Length)];
        }
        time_cnt+=1;
        
    }
}
