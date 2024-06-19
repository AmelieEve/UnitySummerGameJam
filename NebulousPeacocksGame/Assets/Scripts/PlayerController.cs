using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public float mouseSensitivity = 100.0f;

    private float verticalLookRotation = 0f;

    void Update()
    {
        // Movement
        float moveForward = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float moveSide = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        transform.Translate(moveSide, 0, moveForward);

        // Mouse look
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        transform.Rotate(0, mouseX, 0);

        verticalLookRotation -= mouseY;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);

        Camera.main.transform.localRotation = Quaternion.Euler(verticalLookRotation, 0, 0);

        // Verrouiller le curseur à nouveau si besoin
        if (Cursor.lockState != CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        //Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void Jump()
    {
        // Vérifier si le joueur est au sol
        if (IsGrounded())
        {
            // Ajouter une force vers le haut pour sauter
            GetComponent<Rigidbody>().AddForce(Vector3.up * 5, ForceMode.Impulse);
        }
    }

    bool IsGrounded()
    {
        // Raycast vers le bas pour vérifier si le joueur est au sol
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }
}
