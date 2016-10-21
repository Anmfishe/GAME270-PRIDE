using UnityEngine;
using System.Collections;

public class BranchScript : MonoBehaviour {
    public GameObject childbranch;
    public GameObject leaves;
    public GameObject leaves2;
    private GameObject trunk;
    private GameObject cb;
    private int numBraches = 0;
    private Rigidbody2D rb2d;
    private HingeJoint2D hj2d;
    private HingeJoint2D hj2d2;
    private float ryan = 0f;
    private bool selecting = false;
	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        hj2d = GetComponent<HingeJoint2D>();
        trunk = GameObject.FindGameObjectWithTag("Trunk");
        GameObject lvs = (GameObject)Instantiate(leaves, transform.GetChild(0).transform.position, Quaternion.identity);
        lvs.transform.parent = transform.parent;
        HingeJoint2D lvhj2d = lvs.GetComponent<HingeJoint2D>();
        lvhj2d.connectedBody = rb2d;
        int numLeaves = (int)Random.Range(0f, 3f);
        print(numLeaves);
        if(numLeaves == 1)
        {
            GameObject lvs2 = (GameObject)Instantiate(leaves2, transform.GetChild(1).transform.position, Quaternion.identity);
            lvs2.transform.parent = transform.parent;
            HingeJoint2D lvhj2d2 = lvs2.GetComponent<HingeJoint2D>();
            lvhj2d2.connectedBody = rb2d;
        }
        else if(numLeaves == 2)
        {
            GameObject lvs3 = (GameObject)Instantiate(leaves2, transform.GetChild(2).transform.position, Quaternion.identity);
            lvs3.transform.parent = transform.parent;
            HingeJoint2D lvhj2d3 = lvs3.GetComponent<HingeJoint2D>();
            lvhj2d3.connectedBody = rb2d;

        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void FixedUpdate ()
    {
        
        if(ryan > 10f)
        {
            JointMotor2D jm2d = hj2d.motor;
            jm2d.motorSpeed *= -1;
            hj2d.motor = jm2d;
            ryan = 0f;
        }
        ryan += 0.1f;
    }
    void OnMouseDown()
    {
        if (numBraches < 3 && !selecting && transform.lossyScale.x > 0.07f)
        {
            int randSide = (int)Random.Range(0, 2);
            float randAngle = 0;

            if (transform.rotation.z > 0f)
            {

                randAngle = Random.Range(Mathf.PI / 3f, 0);
            }
            else
            {
                randAngle = Random.Range(Mathf.PI / 6f, -Mathf.PI / 3f);
                
            }
          


            GameObject cb = (GameObject)Instantiate(childbranch, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.AngleAxis(randAngle * Mathf.Rad2Deg, Vector3.back));
            //print(cb.transform.rotation.z + " " + transform.rotation.z);
            cb.transform.localScale = new Vector3(transform.localScale.x * 0.5f, transform.localScale.y * 0.6f, transform.localScale.z);
            cb.transform.position = new Vector3(cb.transform.position.x + cb.transform.lossyScale.y/2 *  Mathf.Atan(randAngle), cb.transform.position.y + cb.transform.lossyScale.y/2 * Mathf.Abs(Mathf.Cos(randAngle)), transform.position.z - transform.lossyScale.z);
            HingeJoint2D hj2d2 = cb.GetComponent<HingeJoint2D>();
            hj2d2.connectedBody = rb2d;
            GameObject parent = transform.parent.gameObject;
            cb.transform.parent = parent.transform;
            transform.parent.transform.position = new Vector3(transform.parent.transform.position.x, transform.parent.transform.position.y + .03f, transform.parent.transform.position.z);
            numBraches++;
        }
    }
}
