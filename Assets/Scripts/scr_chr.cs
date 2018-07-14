using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_chr : MonoBehaviour {

    public float chr_speed = 3;
    public GameObject look_object;

    private void FixedUpdate()
    {
        //  Movement
        float w = Input.GetAxis("Horizontal");
        float h = Input.GetAxis("Vertical");

        transform.position += new Vector3(w * Time.deltaTime * chr_speed, h * Time.deltaTime * chr_speed, 0);

        //  Angle
        //transform.rotation = Quaternion.Euler(0, 0, 30);
        Vector2 mouse_pos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));

        float dx = mouse_pos.x - transform.position.x;
        float dy = mouse_pos.y - transform.position.y;
        float rotDeg = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;

        transform.localRotation =
        Quaternion.Lerp(transform.localRotation, Quaternion.Euler(0f, 0f, rotDeg), 10 * Time.deltaTime);
    }

    private void Update()
    {
        //Debug.Log("X: " + Input.mousePosition.x);
        //Debug.Log("Y: " + Input.mousePosition.y);
        //Debug.Log("Camera Pos: " + Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y)));
        //Debug.Log("Y: " + transform.position.);
    }
}
