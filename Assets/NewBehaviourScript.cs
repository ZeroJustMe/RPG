using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    Animator tmp;
    // Use this for initialization
    void Start()
    {
        tmp = GameObject.Find("Animation").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        if (h == 0 && v == 0){ tmp.SetBool("run", false); return; }
        Vector3 move = new Vector3(h * Time.deltaTime * (float)3.8, v * Time.deltaTime * (float)3.0, 0);
        tmp.SetBool("run", true);
        transform.position += move;
    }
}
