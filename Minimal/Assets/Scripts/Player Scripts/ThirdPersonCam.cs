using UnityEngine;

public class ThirdPersonCam : MonoBehaviour
{
      [Header("References")]
        public Transform orientation;
        public Transform player;
        public Transform playerObj;
        public Rigidbody rb;

        public float rotationSpeed;

        public Transform sprintLookAt;

        public GameObject thirdPersonCam;
        public GameObject sprintCam;

        public CameraStyle currentStyle;
        public enum CameraStyle
        {
            Basic,
            Sprinting
        }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      Cursor.lockState = CursorLockMode.Locked;
      Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // rotate orientation
        Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;

        // rotate player object
        if(currentStyle == CameraStyle.Basic)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            Vector3 inputDir = orientation.forward * verticalInput + orientation.right * horizontalInput;

            if (inputDir != Vector3.zero)
            {
                playerObj.forward = Vector3.Slerp(playerObj.forward, inputDir.normalized, Time.deltaTime *rotationSpeed);
            }
        }
        // if not basic, then use sprintlookat
        else
        {
            Vector3 dirToSprintLookAt = sprintLookAt.position - new Vector3(transform.position.x, sprintLookAt.position.y, transform.position.z);
            orientation.forward = dirToSprintLookAt.normalized;

            playerObj.forward = dirToSprintLookAt.normalized;
        }
    }

    private void SwitchCameraStyle(CameraStyle newStyle)
    {
        thirdPersonCam.SetActive(false);
        sprintCam.SetActive(false);

        if (newStyle == CameraStyle.Basic) thirdPersonCam.SetActive(true);
        if (newStyle == CameraStyle.Sprinting) sprintCam.SetActive(true);

        currentStyle = newStyle;
    }

    public void SetBasic()
    {
        SwitchCameraStyle(CameraStyle.Basic);
    }

    public void SetSprinting()
    {
        SwitchCameraStyle(CameraStyle.Sprinting);
    }
}
