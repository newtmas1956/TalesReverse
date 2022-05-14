using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    private bool boosted = true;
    private bool crouched = false;
    [SerializeField]
    private float horizontalSpeed = 1.0f;
    private CharacterController characterController;
    private Transform characterTransform;
    [SerializeField]
    private float jumpForce = 1;
    [SerializeField]
    private float gravity = 1;
    private float height;
    private Vector3 movement;
    private Vector3 lerpMovement;
    [SerializeField]
    private float smooth;
    [SerializeField]
    private Vector3 movementJump;
    private Vector3 lerpMovementJump;


    //Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        characterTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");
        Vector3 forward = transform.forward * vertical;
        Vector3 direction = transform.right * horizontal;
        //transform.position += (forward + direction) * speed;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (boosted)
            {
                horizontalSpeed /= 1.5f;
                boosted = false;
            }
        }
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            if (!boosted)
            {
                horizontalSpeed *= 1.5f;
                boosted = true;
            }
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            if (!crouched)
            {
                characterTransform.localScale.Set(1, 0.8f, 1);
                horizontalSpeed /= 2f;
                crouched = true;
            }
        }

        if (!Input.GetKey(KeyCode.LeftControl))
        {
            if (crouched)
            {
                characterTransform.localScale.Set(1, 1, 1);
                horizontalSpeed *= 2f;
                crouched = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && characterController.isGrounded)
        {
            height = jumpForce;
        }
        else if (!characterController.isGrounded)
        {
            height -= gravity;
        }

        Vector3 movement = new Vector3();
        //movement.y = height / horizontalSpeed;
        movement += (forward + direction) * horizontalSpeed;
        lerpMovement = Vector3.Lerp(lerpMovement, movement, smooth * Time.deltaTime);
        lerpMovementJump = Vector3.Lerp(lerpMovementJump, Vector3.up * height, smooth * Time.deltaTime);
        characterController.Move(lerpMovement * Time.deltaTime);
        characterController.Move(lerpMovementJump * Time.deltaTime);
    }
}
