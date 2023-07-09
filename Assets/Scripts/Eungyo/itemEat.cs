using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI 관련 스크립트에 활용

public class itemEat : MonoBehaviour
{
    public Image original_img;
    public Image img;
    public Sprite after_img;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        Color newColor = img.color;  
        newColor.a = 0f;             
        img.color = newColor;        

        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ChangeImage()
    {   
        Debug.Log("ChangeImage");
        Color newColor = img.color;
        newColor.a = 1f;
        img.color = newColor;
        img.sprite = after_img;
    }
    public void RevertImage()
    {   
        Debug.Log("RevertImage");
        Color newColor = img.color;
        newColor.a = 0f;
        img.color = newColor;
        img.sprite = original_img.sprite;
    }

}





