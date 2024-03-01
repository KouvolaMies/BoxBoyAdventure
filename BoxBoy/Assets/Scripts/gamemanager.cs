using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class gamemanager : MonoBehaviour
{
    //death variable
    private bool dead = false;

    //coincount
    public int coincount = 0;

    //timer
    private float timer;

    //text references
    [SerializeField] private TMP_Text gameovertxt;
    [SerializeField] private TMP_Text cointxt;
    [SerializeField] private TMP_Text timertxt;

    //scene variables
    private int currentscene;

    private void Start(){
        currentscene = SceneManager.GetActiveScene().buildIndex;
    }

    void Update(){
        //reset button for testing
        if(Input.GetKeyDown("e")){
            SceneManager.LoadScene(0);
        }

        //restart if r is pressed when the player is dead
        if(Input.GetKeyDown("r") && dead == true){
            Time.timeScale = 1;
            Continue();
        }

        //timer
        timer += Time.deltaTime;
        timertxt.text = "TIME: " + Mathf.Round(timer * 100f) / 100f;
    }

    //coin pickup
    public void CoinGet(){
        coincount++;
        cointxt.text = "COINS: " + coincount;
    }

    //game over
    public void GameOver(){
        gameovertxt.text = "GAME OVER PRESS R TO RESTART";
        Time.timeScale = 0;
        dead = true;
    }

    private void Continue(){
        SceneManager.LoadScene(currentscene);
    }

    public void Goal(){
        if(currentscene < 1){
            SceneManager.LoadScene(currentscene + 1);
        }
        else{
            SceneManager.LoadScene(0);
        }
    }
}