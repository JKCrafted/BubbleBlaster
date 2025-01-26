using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class HUBPlayer : MonoBehaviour
{
    [SerializeField]
    private float lookSensitivity = 1f;

    [SerializeField]
    private CharacterController characterController;

    [SerializeField]
    private Camera playerCam;

    [SerializeField]
    private float camExtents = 90;

    [SerializeField]
    private bool invertLook = false;

    private float sprintModifier = 2.0f;

    [SerializeField]
    private float moveSpeed = 1f;

    private Vector2 lookInputs = Vector2.zero;

    private Vector2 moveInputs = Vector2.zero;

    private bool allowMovement = true;

    private bool isSprinting = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        playerCam.transform.rotation = Quaternion.Euler(0, 0, 0);
    }
    
    public void SetInControl(bool inControl)
    {
        allowMovement= inControl;        
    }


    // Update is called once per frame
    void Update()
    {
        if (allowMovement)
        {
            Vector3 rotation = transform.rotation.eulerAngles;

            rotation.y += lookInputs.x * lookSensitivity * Time.deltaTime;

            transform.rotation = Quaternion.Euler(rotation);

            Vector3 camRotation = playerCam.transform.rotation.eulerAngles;

            camRotation.x += (invertLook == true ? lookInputs.y : -lookInputs.y ) * lookSensitivity * Time.deltaTime;

            playerCam.transform.rotation = Quaternion.Euler(camRotation);

            
            Vector3 forwardMotion = transform.forward * moveInputs.y * moveSpeed;

            Vector3 strafeMotion = transform.right * moveInputs.x * moveSpeed;


            if (isSprinting)
            {
                forwardMotion *= sprintModifier;
                strafeMotion *= sprintModifier;
            }

            characterController.Move((forwardMotion + strafeMotion) * Time.deltaTime);
        }
    }

    // 'Move' input action has been triggered.
    public void OnMove(InputValue value)
    {
        moveInputs = value.Get<Vector2>();
    }

    // 'Look' input action has been triggered.
    public void OnLook(InputValue value)
    {
        lookInputs = value.Get<Vector2>();

        Debug.Log(lookInputs);
    }

    // 'Look' input action has been triggered.
    public void OnSprint(InputValue value)
    {
        isSprinting = value.Get<float>() > 0.5f;
    } 
}
