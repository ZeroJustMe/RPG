using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc : MonoBehaviour {

    GameObject TB = null,cam;
    private float starttime=-1,nowtime;
    Vector3 pre_cam,pre_pos;
    Collider2D pos;
    int k=0;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        nowtime = Time.time;
        if (TB != null && nowtime - starttime >= 3)
        {
            cam.transform.position = pre_cam;
            pos.transform.position = pre_pos;
            Destroy(TB);
            k = 1;
            TB = null;
        }
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (k==1) { k = 0; return; }
        
        TB=Instantiate(Resources.Load("enemy") as GameObject) as GameObject;
        TB.transform.localScale = new Vector3((float)0.0073, (float)0.0073, 1);
        TB.transform.localPosition = new Vector3((float)2, (float)-10,0);

        pos = other;
        pre_pos = pos.transform.position;
        pos.transform.localPosition = new Vector3((float)-2, (float)-10, -2);

        cam = GameObject.Find("Main Camera");
        pre_cam = cam.transform.position;
        cam.transform.localPosition = new Vector3((float)0, (float)-10, -10);
        starttime = Time.time;
    }
}
