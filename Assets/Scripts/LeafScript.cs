using UnityEngine;
using System.Collections;

public class LeafScript : MonoBehaviour {
    RaycastHit[] hits;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void FixedUpdate()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 20;
        hits = Physics.RaycastAll(transform.position, forward);
        string hitss = "";
        for (int i = 0; i < hits.Length; i++)
        {
            hitss += hits[i].transform.tag + " ";
            //RaycastHit hit = hits[hits.Length - 1];
            /*if (hit.transform.tag == "Sky")
            {
                break;
            }
            else if (hit.transform.tag == "Rainbow")
            {
                print("Test");
                break;
            }*/
        }
        print(hitss);
        Debug.DrawRay(transform.position, forward, Color.green);
    }
}
