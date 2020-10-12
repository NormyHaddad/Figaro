using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int jumpPower = 10;
    public bool isOnGround = true;
    public bool canPushPull = false;
    public bool isPushPull = false;

    float speedMultiplier = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("a"))
        {
            //GetComponent<Rigidbody>().velocity += Vector3.left * Time.deltaTime;
            transform.position += new Vector3(1, 0, 0) * Time.deltaTime * speedMultiplier;
        }
        if (Input.GetKey("d"))
        {
            transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * speedMultiplier;
        }
        if (Input.GetKeyDown("space") && isOnGround)
        {
            GetComponent<Rigidbody>().velocity += Vector3.up * jumpPower;
        }
        if (Input.GetKeyDown("g"))
        {
            canPushPull = !canPushPull;
            if (canPushPull)
            {
                speedMultiplier = 0.5f;
            }
            else if (!canPushPull)
            {
                speedMultiplier = 1.0f;
            }
        }
    }

    //started 6:55pm
    //finished 7:15pm
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "movable" && canPushPull)
        {
            collision.transform.SetParent(gameObject.transform);
        }
        if (collision.transform.tag == "movable" && !canPushPull)
        {
            collision.transform.SetParent(null);
        }
    }
}
