using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menumanager : MonoBehaviour
{
    private int currentbutton;
    public play pl;
    public quit qu;

    private void Start(){
        currentbutton = 0;
    }

    void Update()
    {
        if(Input.GetKeyDown("w")){
            currentbutton = 0;
            pl.PlayHover();
            qu.QuitRevert();
        }
        if(Input.GetKeyDown("s")){
            currentbutton = 1;
            pl.PlayRevert();
            qu.QuitHover();
        }
        if(Input.GetKeyDown("space")){
            if(currentbutton == 0){
                SceneManager.LoadScene(1);
            }
            if(currentbutton == 1){
                Application.Quit();
            }
        }
    }
}