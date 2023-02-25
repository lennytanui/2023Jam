using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play(){
        Debug.Log("PLAY!!!");
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
