using UnityEngine;
using System.Collections;

public class BranchController : MonoBehaviour {
    public GameObject cs;
    public GameObject ws;
    public GameObject branchSprite;
    public int numBranches;
    private Transform meter;
    private GameObject[] spots;
    private float rate = 0.05f;
	// Use this for initialization
	void Start () {
        meter = transform.GetChild(0);
        meter.localScale -= new Vector3(meter.localScale.x, 0, 0);
        
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
        

        rate = 0.02f;
        foreach(Transform child in cs.transform)
        {
            rate -= 0.005f;
        }
        foreach (Transform child in ws.transform)
        {
            rate -= 0.005f;
        }
        meter.localScale += new Vector3(rate, 0, 0);
        if(meter.localScale.x < 0)
        {
            meter.localScale += new Vector3(-meter.localScale.x, 0, 0);
        }
        if(meter.localScale.x > 5)
        {
            if (numBranches < 5)
            {
                meter.localScale += new Vector3(-meter.localScale.x, 0, 0);
                numBranches++;
            }else
            {
                meter.localScale -= new Vector3(meter.localScale.x - 5, 0, 0);
            }
        }
    }
}
