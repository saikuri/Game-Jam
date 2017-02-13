using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    private Rigidbody myRB;
    public float moveSpeed;

    PlayerController Player;

    // Use this for initialization
    void Start () {
        myRB = GetComponent<Rigidbody>();
        Player = FindObjectOfType<PlayerController>();
		
	}

    void FixedUpdate()
    {
        myRB.velocity = (transform.forward * moveSpeed);
    }
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(Player.playerModel.transform.position);
	}
}
