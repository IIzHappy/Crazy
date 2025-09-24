using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : MonoBehaviour
{

    [SerializeField] private Rigidbody rb;
    private bool dead = false;
    public Transform player;        
    public float moveSpeed = 3f;         
    public float rotationSpeed = 5f;     

    private Vector3 originalPosition;
    private Vector3 pDirection;
    private bool isFollowing = false;
    public AudioClip death;
    public AudioClip hit;
    
    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!dead)
        {

            Vector3 direction = (player.position - transform.position).normalized;
            Vector3 pDirection = player.position - transform.position;
            pDirection.y = 0f;
            transform.position += direction * moveSpeed * Time.deltaTime;
            if (transform.position.y != 0)
            {
                transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
            }
            Quaternion lookrotation = Quaternion.LookRotation(pDirection);
            lookrotation *= Quaternion.Euler(0, +90f, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookrotation, Time.deltaTime * rotationSpeed);

        }



    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("bat"))
        {
            dead = true;
            Bounce();
        }
    }

    private void facePlayer()
    {
        Quaternion lookRotation = Quaternion.LookRotation(pDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }
    private void Bounce()
    {
        Debug.Log("Hit");
        AudioSource.PlayClipAtPoint(hit, gameObject.transform.position);
        AudioSource.PlayClipAtPoint(death, gameObject.transform.position);
        rb.AddForce((new Vector3(20, 10, 30)) * Random.Range(2f, 4f), ForceMode.Impulse);
        
    }
}
