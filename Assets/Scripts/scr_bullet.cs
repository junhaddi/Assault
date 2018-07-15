using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_bullet : MonoBehaviour {

    public float bullet_speed;
    Vector3 bullet_pos;

    void Start()
    {
        bullet_pos = Vector3.Normalize(transform.position - Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y)));
    }

    private void FixedUpdate()
    {
        transform.position -= bullet_pos * Time.deltaTime * bullet_speed;
        transform.position = new Vector3(transform.position.x, transform.position.y, 1);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
