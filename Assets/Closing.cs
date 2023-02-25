using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Closing : MonoBehaviour
{
    Rigidbody2D rb;
    public float closingSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveDirection = new Vector2(-1, 0);
    }

    void FixedUpdate(){
        rb.velocity = new Vector2(-1 * closingSpeed * Time.fixedDeltaTime, 0);
    }
}
