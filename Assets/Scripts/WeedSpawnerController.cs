using UnityEngine;
using System.Collections;

public class WeedSpawnerController : MonoBehaviour {
    public GameObject Weed1;
    private int timer;
    private int keeper;
    private int minRange;
    private int maxRange;
	// Use this for initialization
	void Start () {
        timer = 0;
        minRange = 100;
        maxRange = 300;
        keeper = Random.Range(minRange, maxRange);
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
    void FixedUpdate()
    {
        if(timer > keeper)
        {
            minRange--;
            maxRange--;
            keeper = Random.Range(minRange, maxRange);
            timer = 0;
            float xpos = Random.Range(-7.5f, 7.5f);
            GameObject weed = (GameObject)Instantiate(Weed1, new Vector3(xpos, transform.position.y, transform.position.z), Quaternion.identity);
            weed.transform.parent = transform;
            
        }
        timer++;
    }
}
