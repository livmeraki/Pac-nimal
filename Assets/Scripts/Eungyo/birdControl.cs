using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdControl : MonoBehaviour
{
    public Rigidbody rigid;
    public gameManager gm;
    public AudioSource effect;
    // Start is called before the first frame update
    void Start()
    {
        gm.totalCount = 0;
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    // FixedUpdate 쓰면 time.deltaTime 안써도 됨
    void FixedUpdate()
    {
        
    }

    // 겹쳐있다 아니다를 판단(접촉 판정), 유니티에서 isTrigger가 True 돼있으면 이 함수에 영향을 받는다.
    private void OnTriggerEnter(Collider other){
        // Game Manager는 딱 하나이다.
        if(other.gameObject.tag == "Seed"){
            effect.Play();
            gm.totalCount++;
            gm.getItem(gm.totalCount);
            // 아예 지우는거 (아예 사라지는거)
            StartCoroutine(ActivationRoutine(other.gameObject));
        }
        if(other.gameObject.tag == "JumpItem" || other.gameObject.tag == "StopItem"){
            StartCoroutine(ActivationRoutine(other.gameObject));
        }
    }

    private IEnumerator ActivationRoutine(GameObject inactiveObject)
    {   
        inactiveObject.SetActive(false);
        while(!inactiveObject.active){
            yield return new WaitForSeconds(10);
            inactiveObject.SetActive(true);
        }
        yield return null;
    }
    
}



