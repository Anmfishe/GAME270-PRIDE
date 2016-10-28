using UnityEngine;
using System.Collections;

public class TreeScript : MonoBehaviour {
    public GameObject rbranch;
    public GameObject lbranch;
    public int numBranches;
    private HingeJoint2D hj2d;
    private AudioSource a;
	// Use this for initialization
	void Start () {
        a = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void reload()
    {
        Application.LoadLevel("Level1");
    }
    void FixedUpdate()
    {
        float rnum = 0;
        float lnum = 0;
        numBranches = 0;
        foreach(Transform child in transform)
        {
            if(child.tag == "RightBranch")
            {
                numBranches++;
                rnum += 1;
            }
            if (child.tag == "LeftBranch")
            {
                numBranches++;
                lnum += 1;
            }
        }
        if(rnum > lnum + 3)
        {
            hj2d = rbranch.GetComponent<HingeJoint2D>();
            hj2d.breakForce = 0f;
            a.Play();
            Invoke("reload", 2f);
        }
        if (lnum > rnum + 3)
        {
            hj2d = lbranch.GetComponent<HingeJoint2D>();
            hj2d.breakForce = 0f;
            a.Play();
            Invoke("reload", 2f);
        }
    }
    
}
