using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = .1f;
    public float jumpSpeed = 1f;
    public float gravity = 1f;
    public float jumpHeight = 1f;
    public float rotationSpeed = 4f;

    public List<GameObject> parts;

    private float startingHeight;
    private bool isJumping;
    private CharacterController controller;
    private Vector3 startingPosition;
    private float yaw = 0f;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;    
        controller = GetComponent<CharacterController>();    
    }

    // Update is called once per frame
    void Update()
    {
        string player = "P1";
        if(tag!="Player1")
        {
            player = "P2";
        }

        var moveDirection = new Vector3(0f, gravity * Time.deltaTime, 0f);

        if(!isJumping && controller.isGrounded)
        {
            if (Input.GetButtonDown ($"{player}Jump")) 
            {
                isJumping = true;
                startingHeight = transform.position.y; 
            }
        }

        if(isJumping)
        {
            moveDirection.y = jumpSpeed;
        }

        if(transform.position.y > startingHeight + jumpHeight)
        {
            isJumping = false;
            moveDirection.y = gravity * Time.deltaTime;
        }
        
        yaw += Input.GetAxis($"{player}Horizontal") * rotationSpeed;
        transform.eulerAngles = new Vector3(0f, yaw, 0f);

        moveDirection += (transform.forward * Input.GetAxis($"{player}Vertical") * moveSpeed * Time.deltaTime);

        controller.Move(moveDirection);

        // Player fell
        if(transform.position.y < 50)
        {
            Respawn();
        }
    }

    public void Respawn()
    {
        var carryingPart = parts.FirstOrDefault(p => p.activeSelf);
        if(carryingPart != null)
        {
            carryingPart.SetActive(false);
            Parts.Instance.Respawn(carryingPart.name);
        }

        controller.enabled = false;
        transform.position = startingPosition;       
        controller.enabled = true;
    }

    public void ToggleController(bool enabled)
    {
        controller.enabled = enabled;
    }
}
