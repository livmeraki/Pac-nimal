using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int itemCount;
    public int totalCount;
    public Text countText;
    public Text totalText;

    public int stage;
    public bool finalStage = false;

    // Start is called before the first frame update
    void Start()
    {
        itemCount = 0;
    }
    //differenciate Start() and Awake()
    void Awake(){
        DontDestroyOnLoad(this.gameObject);
    }

    public void GetItem(int count){
        countText.text = count.ToString(); 
    }    //function that affects the whole game program should be in the game manager

    public void MoveNextStage(){
        if(itemCount == totalCount){
            if(!finalStage){
                SceneManager.LoadScene(stage + 1);
            }
            else{

            }
            stage++;

        } else {
            SceneManager.LoadScene(stage);
        }
    }

    public void ExitGame(){
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

}
