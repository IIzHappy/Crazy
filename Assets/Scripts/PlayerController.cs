using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Camera cam;
    [SerializeField] private Animator anim;

    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float sens;
    [SerializeField] private GameObject swing;
    private bool swinging;
    private float swingTimer;
    public AudioClip swoosh;
    public CrazyCounter CrazyCounter;

    Vector3 move;
    Vector3 look;
    Vector3 forward;
    Vector3 right;

    public bool canPlay = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        Cursor.lockState = CursorLockMode.Locked;
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
        Debug.Log(rb.linearVelocity.magnitude);

        if ( new Vector2(rb.linearVelocity.x, rb.linearVelocity.z).magnitude >= maxSpeed)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.normalized.x * maxSpeed, rb.linearVelocity.y, rb.linearVelocity.normalized.z * maxSpeed);
        }

        look = new Vector3(-Input.GetAxisRaw("Mouse Y"), Input.GetAxisRaw("Mouse X"), 0) * sens;
        cam.transform.localEulerAngles += look;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && !swinging && canPlay)
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
        anim.SetBool("SwingLeft", !anim.GetBool("SwingLeft"));
        AudioSource.PlayClipAtPoint(swoosh, gameObject.transform.position);
        swingTimer = 0.5f;
        CrazyCounter.AddCrazy();
    }
}
