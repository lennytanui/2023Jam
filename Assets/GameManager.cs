using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject playerOne;
    public GameObject playerTwo;
    public AudioSource mainAudioSource;

    public float currentTime;
    public float startTime = 60;
    public TMPro.TMP_Text countDown;
    public TMPro.TMP_Text musicTimeLeft;
    public Image soundLengthBar;
    public Image applauseAmountBar;


    private int flowersCollected;
    private int chocolatesCollected;

    public float minimumDistanceToBeNornal = 2;
    public float pitchAvg = 2;
    public Transform[] spawnPoints;

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
        
        Debug.Log("lengtj" + spawnPoints.Length);
        Debug.Log("flowers colected" + flowersCollected);

        InitSpawnManager();
    }

    // Update is called once per frame
    void Update()
    {
        musicLength = mainAudioSource.time;
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(Time.timeScale == 1){
                Time.timeScale = 0;
                gamePanel.gameObject.SetActive(true);
                mainAudioSource.Pause();
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

        applauseAmountBar.fillAmount = (float)flowersCollected / (float)spawnPoints.Length;
        soundLengthBar.fillAmount = 1 - musicLength / audioLength;
        Transform time_passed = musicTimeLeft.gameObject.transform;

        // musicTimeLeft.gameObject.transform.SetPositionAndRotation(
        //             new Vector2(soundLengthBar.transform.localScale.x * (soundLengthBar.fillAmount), 
        //             time_passed.position.y), Quaternion.identity);

        musicTimeLeft.text =  ((int)(audioLength - musicLength)).ToString() +  " seconds left";

        if(audioLength - musicLength <= 0){
            if(applauseAmountBar.fillAmount >= .65f){
                ShowWinScene();
            }else{
                ShowLoseScene();
            }
        }
    }

    public void ContinueGame(){
        Time.timeScale = 1;
        gamePanel.gameObject.SetActive(false);
        mainAudioSource.UnPause();
    }

    public void AddFlower(){
        flowersCollected += 1;
        Debug.Log("Flowers added - " + flowersCollected);
    }

    public void AddChocolate(){
        chocolatesCollected += 1;
    }


    public int maxSpawns = 10;
    int[] activeSpawnPoints = {};
    public int currentSpawned = 0;
    public GameObject applause;


    void ShowWinScene(){
        SceneManager.LoadScene("Lose");
    }

    void ShowLoseScene(){
        SceneManager.LoadScene("Win");
    }

    void InitSpawnManager(){
        activeSpawnPoints = new int[maxSpawns];
        for(int i = 0; i < spawnPoints.Length; i++){
            Instantiate(applause, spawnPoints[i].transform.position, Quaternion.identity);
        }
        // bool unique = true;
        //     for(int i = 0; i < activeSpawnPoints.Length; i++){
        //         int random_int = Random.Range(0, spawnPoints.Length);

        //         while(true){
        //             for(int j = 0; j < i; j++){
        //                 if(activeSpawnPoints[j] == 0)
        //             }
        //             if(activeSpawnPoints[i] == )
        //         }
        //         unique = true;
        //     }

        // }
    }

    // void AddSpawnPoint(){
    //     // find open slot
        
    // }

    private void SpawnManager(){
        // while(currentSpawned < maxSpawns){
        //     int random_int = Random.Range(0, spawnPoints.Length);
            
        //     int openIndex = 0;
        //     for(int i = 0; i < activeSpawnPoints.Length; i++){

        //     }
            
        //     if(activeSpawnPoints[i] == -1){
        //         activeSpawnPoints[i] = random_int;
        //         break;
        //     }
        // }
    }
}   
