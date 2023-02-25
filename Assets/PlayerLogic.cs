using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Paris")){
            Debug.Log("You Share a heart!");
        }

        // if(collision.gameObject.CompareTag("Flower")){
        //     Debug.Log("Grab Flower!");
        // }
    }
}
