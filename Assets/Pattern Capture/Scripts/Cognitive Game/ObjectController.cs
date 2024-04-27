using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    Rigidbody rb;
    Vector3 initialVel;
    Vector3 newVel;
    public static float speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        //the objects move along the x and y axes
        rb = this.gameObject.GetComponent<Rigidbody>();
        if(rb != null)
        {
            initialVel = new Vector3(speed,speed,0);
            rb.velocity = initialVel;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(rb != null)
            newVel = rb.velocity;
    }
    //object reflects to the new direction when hits with other objects or the bounding box
    void OnCollisionEnter(Collision collision)
    {
        if(rb != null)
        {
            var direction = Vector3.Reflect(newVel.normalized, collision.contacts[0].normal);
            rb.velocity = direction * speed;
        }
    }
}
    