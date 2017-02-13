using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    GameObject cameraHolder;
    GameObject player;
    Vector3 playerPosition;

    float elevation;

    // Use this for initialization
    void Start () {
        cameraHolder = this.gameObject;
        player = GameObject.FindGameObjectWithTag("Player");
        elevation = 10;
	}
	
	// Update is called once per frame
	void Update () {
        playerPosition = new Vector3(player.transform.position.x, elevation, player.transform.position.z);
        cameraHolder.transform.position = playerPosition;

        float mouseWheel = Input.GetAxis("Mouse ScrollWheel");

        if(Mathf.Abs(mouseWheel) > 0)
        {
            elevation += mouseWheel;
        }
	}
}
