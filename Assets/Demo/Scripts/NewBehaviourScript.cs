﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    const float eps = 1e-6f;
    public float HorizontalSpeed;
    public float VerticalSpeed;
    private float last_h;
    private Animator tmp;

    // Use this for initialization
    void Start()
    {
        tmp = GameObject.Find("Animation").GetComponent<Animator>();
        last_h = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        if (h == 0 && v == 0){ tmp.SetBool("run", false); return; }
        Vector3 move = new Vector3(h * HorizontalSpeed, v * VerticalSpeed, 0) * Time.deltaTime;
        if (h > 0) {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (h < 0) {
            transform.rotation = Quaternion.Euler(0, 180f, 0);
        }
        tmp.SetBool("run", true);
        last_h = h;
        transform.position += move;
    }
}
