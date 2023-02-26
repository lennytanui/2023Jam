using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject playerOne;
    public GameObject playerTwo;
    public AudioSource mainAudioSource;

    public float currentTime;
    public float startTime = 60;
    public TMPro.TMP_Text countDown;
    public Image soundLengthBar;

    private int flowersCollected;
    private int chocolatesCollected;

    public float minimumDistanceToBeNornal = 2;
    public float pitchAvg = 2;

    public RectTransform gamePanel;
    private float musicLength = 0;
    private float audioLength;
    // public textme
    // Start is called before the first frame update
    void Start()
    {
        flowersCollected = 0;
        currentTime = startTime;

        Debug.Log("Initital Pitch" + mainAudioSource.pitch);
        audioLength = mainAudioSource.clip.length;
        mainAudioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        musicLength = mainAudioSource.time;
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(Time.timeScale == 1){
                Time.timeScale = 0;
                gamePanel.gameObject.SetActive(true);
            }
        }


        float distanceBetweenPlayers = Vector2.Distance(playerOne.transform.position, playerTwo.transform.position);

        if(distanceBetweenPlayers > minimumDistanceToBeNornal){
            float dist = distanceBetweenPlayers - minimumDistanceToBeNornal;
            dist /= pitchAvg;

            mainAudioSource.pitch = 1 + dist;
        }

        
        if(playerOne.GetComponent<PlayerMovement>().notMoving 
            || playerTwo.GetComponent<PlayerMovement>().notMoving){
                currentTime -= Time.deltaTime;
        }else{
            currentTime = startTime;
        }

        if(currentTime <= 0){
            // Debug.Log("GAME OVER!!");
        }else{
            // Debug.Log(currentTime + " S");
        }

        soundLengthBar.fillAmount = 1 - musicLength / audioLength;
        countDown.text =  ((int)(audioLength - musicLength)).ToString();
    }

    public void ContinueGame(){
        Time.timeScale = 1;
        Debug.Log("YIKESSSS");
        gamePanel.gameObject.SetActive(false);
    }

    public void AddFlower(){
        flowersCollected += 1;
        Debug.Log("flower has been added");
    }

    public void AddChocolate(){
        chocolatesCollected += 1;
        Debug.Log("chocolate has been added");
    }
}   
