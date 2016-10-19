using UnityEngine;
using System.Collections;

public class BranchScript : MonoBehaviour {
    public GameObject childbranch;
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
        if (numBraches < 2 && !selecting)
        {
            float randAngle = Random.Range(-45f, 45f);
            GameObject cb = (GameObject)Instantiate(childbranch, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.AngleAxis(randAngle, Vector3.back));

           
            cb.transform.localScale = new Vector3(transform.localScale.x * .6f, transform.localScale.y * .6f, transform.localScale.z);
            cb.transform.position = new Vector3(cb.transform.position.x - cb.transform.lossyScale.x / 2 * Mathf.Tan(randAngle), cb.transform.position.y + Mathf.Abs(cb.transform.lossyScale.y/2 * Mathf.Tan(randAngle)), transform.position.z);
            //cb.transform.rotation = Quaternion.AngleAxis(randAngle, Vector3.forward);
            HingeJoint2D hj2d2 = cb.GetComponent<HingeJoint2D>();
            hj2d2.connectedBody = rb2d;
            /*JointAngleLimits2D jla2d = hj2d2.limits;
            jla2d.min = randAngle - 5;
            jla2d.max = randAngle + 5;
            hj2d2.limits = jla2d;*/

            GameObject parent = transform.parent.gameObject;
            cb.transform.parent = parent.transform;
            //cb.transform.rotation = Quaternion.AngleAxis(randAngle, Vector3.forward);

            //rb2d.AddForce(new Vector2(100, 10));
            numBraches++;
            //selecting = true;
        }
    }
}
