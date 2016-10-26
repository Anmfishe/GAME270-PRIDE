using UnityEngine;
using System.Collections;

public class CloudSpawnerController : MonoBehaviour {
    public GameObject cloud1;
    public GameObject cloud2;
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
            float maybe = (int)Random.value % 15;
            if(maybe == 0)
            {
                keeper -= 2;
                timer = 0;
                float height = Random.Range(transform.position.y - 1.5f, transform.position.y + 0.5f);
                maybe = Random.value;
                if(maybe < 0.5)
                {
                    GameObject cloud = (GameObject)Instantiate(cloud1, new Vector3(transform.position.x, height, transform.position.z), Quaternion.identity);
                    cloud.transform.parent = transform;
                }else
                {
                    GameObject cloud = (GameObject)Instantiate(cloud2, new Vector3(transform.position.x, height, transform.position.z), Quaternion.identity);
                    cloud.transform.parent = transform;
                }
                
            }
        }
        timer++;
    }
}
