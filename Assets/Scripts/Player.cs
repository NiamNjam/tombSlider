using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject landParticles;
    public float speed = 5;
    Rigidbody2D rb;
    Vector2 input = Vector2.left;
    public bool canDash;
    public LayerMask wallLayer;
    public AudioSource audio;
    public AudioSource audio1;
    public AudioSource audio2;
    public AudioClip clip;
    public AudioClip clip1;
    public AudioClip clip2;
    bool hasLanded;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        var hit = Physics2D.Raycast(transform.position, input, 1f, wallLayer);
        canDash = hit.collider != null && hit.collider.CompareTag("Wall");
        */

        var newInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (rb.velocity.magnitude < 0.1f && newInput != Vector2.zero) //velocity - xyz rodykle
        {
            input = newInput;
            transform.up = -input;
            /*
            //convert input to z angle
            var angle = Mathf.Atan2(input.y, input.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, 0, angle + 90);
            */
        }

        rb.velocity = speed * input;
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            audio.clip = clip;
            audio.Play();
            
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("BigCoin"))
        {
            audio1.clip = clip1;
            audio1.Play();
            Destroy(collision.gameObject);
           
        }
        if (collision.gameObject.CompareTag("Star"))
        {
            audio2.clip = clip2;
            audio2.Play();
            Destroy(collision.gameObject);

        }
    }

    

}
