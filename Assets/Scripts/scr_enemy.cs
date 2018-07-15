using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_enemy : MonoBehaviour {

    GameObject follow_object;    
    public float enemy_speed;
    public int enemy_hp = 4;

    scr_chr scr_chr;

    private void Awake()
    {
        follow_object = GameObject.Find("obj_chr");
        scr_chr = GameObject.Find("obj_chr").GetComponent<scr_chr>();
    }

    private void FixedUpdate()
    {
        if (GameObject.Find("obj_chr") != null)
        {
            //  Follow
            transform.position += Vector3.Normalize(follow_object.transform.position - transform.position) * Time.deltaTime * enemy_speed;
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "tag_bullet")
        {
            enemy_hp -= 1;

            Destroy(col.gameObject);
            if (enemy_hp < 1)
            {
                //  Dead
                Destroy(gameObject);
                scr_chr.score += 1;
            }
        }
    }
}
