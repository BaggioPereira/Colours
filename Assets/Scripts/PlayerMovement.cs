using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    GameObject player;
    CharacterController controller;
    public float sensitivityX = 5.0f;
    public float sensitivityY = 5.0f;
    public float yRange = 60.0f;
    float rotationY = 0.0f;
    float verticalVelocity = 0.0f;
    public float jump = 5.0f;
    public float speed = 10.0f;
    private Vector3 moveDirection = Vector3.zero;

	// Use this for initialization
	void Start () 
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.AddComponent<CharacterController>();
        controller = (CharacterController)player.transform.GetComponent("CharacterController");
	}
	
	// Update is called once per frame
	void Update () 
    {
        //Rotation
        float rotationX = Input.GetAxis("Mouse X") * sensitivityX;
        transform.Rotate(0, rotationX, 0);

        rotationY -= Input.GetAxis("Mouse Y") * sensitivityY;
        rotationY = Mathf.Clamp(rotationY, -yRange, yRange);
        Camera.main.transform.localRotation = Quaternion.Euler(rotationY, 0, 0);

        //Movement
        verticalVelocity += Physics.gravity.y * Time.deltaTime;

        if(controller.isGrounded && Input.GetButton("Jump"))
        {
            verticalVelocity = jump;
        }

        moveDirection = new Vector3(Input.GetAxis("Horizontal"), verticalVelocity, Input.GetAxis("Vertical"));
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= 10.0f;
        controller.Move(moveDirection * Time.deltaTime);
	}
}
