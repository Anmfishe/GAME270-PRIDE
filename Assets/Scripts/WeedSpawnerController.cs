using UnityEngine;
using System.Collections;

public class WeedSpawnerController : MonoBehaviour {
    public GameObject Weed1;
    private int timer;
    private int keeper;
	// Use this for initialization
	void Start () {
        timer = 0;
        keeper = 200;
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
    void FixedUpdate()
    {
        if(timer > keeper)
        {
            timer = 0;
            float xpos = Random.Range(-7.5f, 7.5f);
            GameObject weed = (GameObject)Instantiate(Weed1, new Vector3(xpos, transform.position.y, transform.position.z), Quaternion.identity);
            weed.transform.parent = transform;
            keeper --;
        }
        timer++;
    }
}
