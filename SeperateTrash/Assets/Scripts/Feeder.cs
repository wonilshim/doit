using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feeder : MonoBehaviour
{
    public Sprite[] trash_sprites;

    public GameObject base_trash;

    public int spawn_freq;

    int time_cnt = 0;
    ArrayList cur_trashes = new ArrayList();


    // Start is called before the first frame update
    void Start()
    {
        if(spawn_freq<10) 
          spawn_freq = 100;
        
    }

    // Update is called once per frame
    void Update()
    {
        //생성
        if(time_cnt%spawn_freq==0){
            time_cnt=0;
            GameObject new_trash = Instantiate(base_trash);
            new_trash.transform.position = new Vector3(-1.7f, 6.0f, 0.0f);

            int new_trash_type = Random.Range(0,trash_sprites.Length);

            SpriteRenderer new_trash_spirite = new_trash.GetComponent<SpriteRenderer>();
            new_trash_spirite.sprite = trash_sprites[new_trash_type];
            cur_trashes.Add(new_trash);

            if(cur_trashes.Count == 1)
                ActivateHeadObject();
        }
        time_cnt+=1;

        //화면 벗어난 것 삭제
        if(cur_trashes.Count>0){
            GameObject head = (GameObject)cur_trashes[0];

            //Destory
            if(head.transform.position.y<-6f){
                Destroy(head);
                cur_trashes.RemoveAt(0);
                ActivateHeadObject();
            }

        }
        
    }

    void ActivateHeadObject(){
        GameObject new_head = (GameObject)cur_trashes[0];
        GameObject highlight = new_head.transform.Find("Highlight").gameObject;
        if(highlight != null) {
            highlight.SetActive(true);
        }
    }
}
