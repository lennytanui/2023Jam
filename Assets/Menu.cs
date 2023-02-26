using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    public GameManager gameManager;
    public AudioSource switchAudio;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


   
    public Image[] letters;
    public Button next_button;
    int letter_index = 0;
    public void ShowLetters(){
        letters[0].gameObject.SetActive(true);
        letters[1].gameObject.SetActive(true);
        letters[2].gameObject.SetActive(true);
        letters[3].gameObject.SetActive(true);
        letters[4].gameObject.SetActive(true);

        next_button.gameObject.SetActive(true);
    }
    public void ShowNextLetter(){
        if(letter_index == 4){
            next_button.gameObject.SetActive(false);
            Play();
            // letters[letter_index].gameObject.SetActive(false);
        }else{
            letters[letter_index].gameObject.SetActive(false);
        }
        letter_index += 1;
    }
    public void Play(){
        Time.timeScale = 1;
        SceneManager.LoadScene("GameScene");
    }

    public void ShowMenu(){
        SceneManager.LoadScene("Start");
    }
    public void ShowInstructions(){
        SceneManager.LoadScene("Instructions");
    }

    public void Continue(){
        gameManager.ContinueGame();
    }

    public void Quit(){
        Application.Quit();
    }
}
