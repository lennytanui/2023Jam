using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    private GameObject gameManagerObject;
    public AudioSource pick_sound;
    private GameManager gameManager;
    
    private bool destroying = false;
    // Start is called before the first frame update
    void Start()
    {
        gameManagerObject = GameObject.FindGameObjectWithTag("GameManager");
        gameManager = gameManagerObject.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if(pick_sound.time > 1 && destroying == true){
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        if(destroying)
            return;

        if(col.CompareTag("Player 1") || col.CompareTag("Player 2")){
            if(this.gameObject.tag == "Flower"){
                gameManager.AddFlower();
            } else if(this.gameObject.tag == "Chocolate"){
                gameManager.AddChocolate();
            }

            gameObject.GetComponent<Renderer>().enabled = false;
            
            destroying = true;
            pick_sound.time = 0;
            pick_sound.Play();
        }
    }
}
