using UnityEngine;

public class ThrowableRock : MonoBehaviour
{
    private Rigidbody rb;
    private bool isHeld = false;
    public Vector3 heldOffset = new Vector3(0, 0, 0);
    private bool canPickUp = false;
    public float throwForce = 10f;
    public GameObject player = null;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (player == null)
        {
            Debug.LogError("Player is not set in the inspector!");
        }
    }

    void Update()
    {
        if (isHeld)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Throw();
            }
        } else if (canPickUp)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                PickUp();
            }
        }
    }

    public void PickUp()
    {
        isHeld = true;
        rb.isKinematic = true;
        transform.SetParent(player.transform);
        transform.localPosition = heldOffset;
    }

    void Throw()
    {
        isHeld = false;
        transform.SetParent(null);
        rb.isKinematic = false;
        rb.AddForce(player.transform.forward * throwForce, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("RockDestroyable"))
        {
            Destroy(collision.gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            canPickUp = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            canPickUp = false;
        }
    }
}
