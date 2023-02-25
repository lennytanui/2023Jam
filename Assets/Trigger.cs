using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    private GameObject gameManagerObject;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManagerObject = GameObject.FindGameObjectWithTag("GameManager");
        gameManager = gameManagerObject.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.CompareTag("Player 1") || col.CompareTag("Player 2")){
            if(this.gameObject.tag == "Flower"){
                gameManager.AddFlower();
            } else if(this.gameObject.tag == "Chocolate"){
                gameManager.AddChocolate();
            }
            
            Destroy(this.gameObject);
        }
    }
}
