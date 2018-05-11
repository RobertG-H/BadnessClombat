using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public string Horizontal1, Vertical1, Horizontal2, Vertical2;

    // Moving variables.
    public float MoveSpeedScale = 10f;

    private Rigidbody rb;



    // Sword variables.
    private Transform sword;
    private float armRotation;

    private const int IDLE = 0;
    private const int FORWARD = 1;
    private const int UP = 2;
    private const int BACK = 3;

    private int currentState;

    void Start ()
    {
        rb = gameObject.GetComponent<Rigidbody>();

        sword = this.gameObject.transform.GetChild(0);
        currentState = IDLE;
    }
	
	void Update ()
    {

        MoveSword();
        MovePlayer();

    }

    void MovePlayer()
    {
        //rb.AddForce(new Vector2(Input.GetAxisRaw(Horizontal1),0));
        rb.velocity = new Vector3(Input.GetAxisRaw(Horizontal1) * MoveSpeedScale, 0, Input.GetAxisRaw(Vertical1) * MoveSpeedScale);

    }

    void MoveSword()
    {
        Debug.Log(Input.GetAxisRaw(Vertical2));
        if (Mathf.Round(Input.GetAxisRaw(Horizontal2) * 100f) / 100f == 0 && Mathf.Round(Input.GetAxisRaw(Vertical2) * 100f) / 100f == 0)
        {
            // Go to neutral position.
            sword.GetComponent<Sword>().move(currentState, IDLE);
            currentState = IDLE;
        }
        else if (Input.GetAxisRaw(Horizontal2) > 0.9f)
        {
            //armRotation = Mathf.Atan2(Input.GetAxisRaw(_vertical2), Input.GetAxisRaw(_horizontal2)) * 360 / 2 / Mathf.PI;
            sword.GetComponent<Sword>().move(currentState, FORWARD);
            currentState = FORWARD;
        }
        else if (Input.GetAxisRaw(Vertical2) > 0.9f)
        {
            sword.GetComponent<Sword>().move(currentState, UP);
            currentState = UP;
        }
        else if (Input.GetAxisRaw(Horizontal2) < -0.9f)
        {
            sword.GetComponent<Sword>().move(currentState, BACK);
            currentState = BACK;
        }

        //transform.GetChild(0).eulerAngles = new Vector3(0, transform.GetChild(0).eulerAngles.y, armRotation);

    }
}
