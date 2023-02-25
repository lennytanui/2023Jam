using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playerOne;
    public GameObject playerTwo;

    public float currentTime;
    public float startTime = 3;
    public TMPro.TMP_Text countDown;
    // public textme
    // Start is called before the first frame update
    void Start()
    {
        currentTime = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerOne.GetComponent<PlayerMovement>().notMoving 
            || playerTwo.GetComponent<PlayerMovement>().notMoving){
                currentTime -= Time.deltaTime;
        }else{
            currentTime = startTime;
        }

        if(currentTime <= 0){
            Debug.Log("GAME OVER!!");
        }else{
            Debug.Log(currentTime + " S");
        }

        countDown.text =  ((int)currentTime).ToString();
    }
}
