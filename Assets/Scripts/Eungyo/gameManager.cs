using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// 아이템 얼마나 먹었는지 관리해주는 파일
public class gameManager : MonoBehaviour
{
    public int totalCount;

    public Text totalText;
    public Text endText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // 활성화 됐을 때 호출되는 함수
    void Awake(){
        //if scene is not 0, dont destory
        DontDestroyOnLoad(gameObject);
        Cursor.visible = false;
        gameManager gm = GameObject.Find("GameManager").GetComponent<gameManager>();
        totalCount = gm.totalCount;
        totalText.text = "Score : " + totalCount;
    }

    public void getItem(int count){
        totalText.text = "Score : " + count.ToString();

    }
}
