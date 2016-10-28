using UnityEngine;
using System.Collections;

public class BranchController : MonoBehaviour {
    public GameObject cs;
    public GameObject ws;
    public GameObject branchSprite;
    public int numBranches;
    private Transform meter;
    private SpriteRenderer rend;
    private GameObject[] spots;
    private float rate = 0.05f;
    private Vector3 origPos;
    private bool expand = true;
	// Use this for initialization
	void Start () {
        meter = transform.GetChild(0);
        origPos = meter.position;
        //rend = meter.GetComponent<SpriteRenderer>();
        //Color temp = rend.color;
        //temp.a = 0;
        //rend.color = temp;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void FixedUpdate()
    {
        foreach(Transform child in transform)
        {
            if (child.CompareTag("BranchSprite"))
            {
                Destroy(child.gameObject);
            }
        }
        for(int i = 1; i < numBranches + 1; i++)
        {
            GameObject b = (GameObject)Instantiate(branchSprite, transform.GetChild(i).position , Quaternion.identity);
            b.transform.parent = this.transform;
        }
        

        rate = 0.0015f;
        foreach(Transform child in cs.transform)
        {
            rate -= 0.0005f;
        }
        foreach (Transform child in ws.transform)
        {
            rate -= 0.0005f;
        }
        if(rate < 0) rate = 0;
        meter.localScale += new Vector3(rate, 0, 0);
        
        if(meter.localScale.x < 0.2220003)
            meter.position += new Vector3(rate * 9, 0, 0);
        if (meter.localScale.x > 0.2220003)
        {
            if (numBranches < 5)
            {
                
                meter.localScale += new Vector3(-meter.localScale.x, 0, 0);
                meter.position = origPos;
                numBranches++;
                
            }
            else
            {
                
                meter.localScale -= new Vector3(meter.localScale.x - 0.2220003f, 0, 0);
                
            }
        }else if(meter.localScale.x < 0)
        {
            meter.localScale += new Vector3(-meter.localScale.x, 0, 0);
        }
        //rend = meter.GetComponent<SpriteRenderer>();
        //Color temp = rend.color;
        //temp.a += rate;
        /*if (temp.a < 0)
        {
            temp.a = 0;
        }
        if(temp.a > 1)
        {
            if (numBranches < 5)
            {
                temp.a = 0;
                numBranches++;
            }else
            {
                temp.a = 1;
            }
        }
        rend.color = temp;
        */
    }
}
