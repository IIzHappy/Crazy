using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Camera cam;

    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float sens;
    [SerializeField] private GameObject swing;
    private bool swinging;
    private float swingTimer;

    Vector3 move;
    Vector3 look;
    Vector3 forward;
    Vector3 right;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    void FixedUpdate()
    {
        forward = cam.transform.forward;
        right = cam.transform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        move = new Vector3() + (Input.GetAxisRaw("Horizontal") * right) + (Input.GetAxisRaw("Vertical") * forward);
        rb.AddForce(move * speed);
        Debug.Log(rb.velocity.magnitude);

        if ( new Vector2(rb.velocity.x, rb.velocity.z).magnitude >= maxSpeed)
        {
            rb.velocity = new Vector3(rb.velocity.normalized.x * maxSpeed, rb.velocity.y, rb.velocity.normalized.z * maxSpeed);
        }

        look = new Vector3(-Input.GetAxisRaw("Mouse Y"), Input.GetAxisRaw("Mouse X"), 0) * sens;
        cam.transform.localEulerAngles += look;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("tab"))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }

        if (swinging)
        {
            swingTimer -= Time.deltaTime;
            if (swingTimer < 0)
            {
                swinging = false;
                swing.SetActive(false);
            }
        }

    }

    private void Attack()
    {
        swing.SetActive(true);
        swinging = true;
        swingTimer = 0.5f;
    }
}
