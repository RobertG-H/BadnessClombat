using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public string _horizontal2, _vertical2;

    private Transform sword;
    //private GameObject sword;
    private float armRotation;

    private const int IDLE = 0;
    private const int FORWARD = 1;
    private const int UP = 2;
    private const int BACK = 3;

    private int currentState;
    // Use this for initialization
    void Start () {
        sword = this.gameObject.transform.GetChild(0);
        currentState = IDLE;

    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log(Input.GetAxisRaw(_horizontal2));
        if (Input.GetAxisRaw(_horizontal2) == 0 && Input.GetAxisRaw(_vertical2) == 0)
        {
            // Go to neutral position
           sword.GetComponent<Sword>().move(currentState, IDLE);
            currentState = IDLE;
        }
        else if (Input.GetAxisRaw(_horizontal2) > 0.9f)
        {
            //armRotation = Mathf.Atan2(Input.GetAxisRaw(_vertical2), Input.GetAxisRaw(_horizontal2)) * 360 / 2 / Mathf.PI;
            sword.GetComponent<Sword>().move(currentState, FORWARD);
            currentState = FORWARD;
        }
        else if (Input.GetAxisRaw(_vertical2) > 0.9f)
        {
            sword.GetComponent<Sword>().move(currentState, UP);
            currentState = UP;
        }
        else if (Input.GetAxisRaw(_horizontal2) < -0.9f)
        {
            sword.GetComponent<Sword>().move(currentState, BACK);
            currentState = BACK;
        }

        //transform.GetChild(0).eulerAngles = new Vector3(0, transform.GetChild(0).eulerAngles.y, armRotation);
    }
}
