using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_camera : MonoBehaviour {

    public GameObject target_object;
    Transform AT;

    void Start()
    {
        AT = target_object.transform;
    }

    void LateUpdate()
    {
        transform.position = new Vector2(AT.position.x, AT.position.y);
    }
}
