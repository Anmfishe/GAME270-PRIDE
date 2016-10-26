using UnityEngine;
using System.Collections;

public class WeedScript : MonoBehaviour {
    private int timer;
	// Use this for initialization
	void Start () {
        timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void FixedUpdate()
    {
        if(timer == 200)
        {
            timer = 0;
            transform.localScale += new Vector3(0.02f, 0.02f, 0);
            transform.position += new Vector3(0, 0.1f, 0);
        }
        timer++;
    }
    void OnMouseDown()
    {
        Destroy(this.gameObject);
    }
}
