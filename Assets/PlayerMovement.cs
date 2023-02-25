using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float playerSpeed;
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    public bool notMoving = false;
    string playerTag;

    // Start is called before the first frame update
    void Start()
    {   
        rb = this.GetComponent<Rigidbody2D>();
        playerTag = this.gameObject.tag;
    }

    // Update is called once per frame
    void Update()
    {


        int vertical = 0;
        int horizontal = 0;

        if(playerTag == "Player 1"){
            if(Input.GetKey(KeyCode.W)){
                vertical = 1;
            }else if(Input.GetKey(KeyCode.S)){
                vertical = -1;
            }

            
            if(Input.GetKey(KeyCode.D)){
                horizontal = 1;
            }else if(Input.GetKey(KeyCode.A)){
                horizontal = -1;
            }
            
            if(horizontal != 0 || vertical != 0){
                notMoving = false;
            }else{
                notMoving = true;
            }

        } else if(playerTag == "Player 2"){
            if(Input.GetKey(KeyCode.UpArrow)){
                vertical = 1;
            }else if(Input.GetKey(KeyCode.DownArrow)){
                vertical = -1;
            }

            
            if(Input.GetKey(KeyCode.RightArrow)){
                horizontal = 1;
            }else if(Input.GetKey(KeyCode.LeftArrow)){
                horizontal = -1;
            }  
            
            if(horizontal != 0 || vertical != 0){
                notMoving = false;
            }else{
                notMoving = true;
            }
        }

        moveDirection = new Vector2(horizontal, vertical);
    }

    void FixedUpdate(){
        rb.velocity = new Vector2(moveDirection.x * playerSpeed * Time.fixedDeltaTime, moveDirection.y * playerSpeed * Time.fixedDeltaTime);
    }
}
