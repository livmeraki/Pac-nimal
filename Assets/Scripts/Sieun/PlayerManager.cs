using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public float speed;
    public float rotateSpeed = 0.05f;
    public float jumpPower = 0.5f;
    public Rigidbody rigid;
    public AudioSource effect;
    public AudioSource effect2;
    //public GameManager gm;

    public bool isJump;
    private Animator playerAnimator; 
    // 평면에서는 Vector2 -> 그냥 더 깔끔해서 h, v 대신에 이거 사용
    private Vector2 input;
    // Target은 3차원이니까 Vector3 사용
    private Vector3 targetDirection;
    private Camera mainCamera;
    private float turnSpeedMultiplier = 1.0f;
    GameObject skill;
    public bool stopAll = false;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();

        // Animator 사용
        playerAnimator = GetComponent<Animator>();

        // 메인 카메라 가져오기 (메인 카메라는 하나)
        mainCamera = Camera.main;

        skill = GameObject.FindWithTag("Skill");
    }

    // Update is called once per frame
    // FixedUpdate 쓰면 time.deltaTime 안써도 됨
    void FixedUpdate()
    {
        // 위로 올라가는 코드 -> Jump
        if (Input.GetKeyDown(KeyCode.Space) && isJump){
            playerAnimator.SetBool("isJump", true);
            effect.Play();
            rigid.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
            skill.GetComponent<itemEat>().RevertImage();
            isJump=false;
        }

        input.x = Input.GetAxisRaw("Horizontal"); 
        input.y = Input.GetAxisRaw("Vertical");


        updateTargetDirection();


        if(input == Vector2.zero){
            playerAnimator.SetBool("isWalk", false);
        }
        else{
            // 0.1 : 유니티에서 충분히 작은 값, 벡터의 값이 존재할 때
            if(targetDirection.magnitude > 0.1f){
                // 봐야하는 방향 
                Vector3 lookDirection = targetDirection.normalized;
                // 카메라가 돌아간 각 : freeRotation
                Quaternion freeRotation = Quaternion.LookRotation(lookDirection, transform.up);
                // 차이 계산
                var differenceRotation = freeRotation.eulerAngles.y - transform.eulerAngles.y;
                var eulerY = transform.eulerAngles.y;
                // 만약에 각 차이가 존재한다면 
                if(differenceRotation < 0 || differenceRotation > 0){
                    eulerY = freeRotation.eulerAngles.y;
                }
                // 최종적으로 적용해야하는 오일러 값 -> lookDirection 값을 이제 쓸 필요가 없어서 오일러 값 사용
                var euler = new Vector3(0, eulerY, 0);
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(euler), rotateSpeed * turnSpeedMultiplier);
            }
            playerAnimator.SetBool("isWalk", true);
            // 절대 좌표계로 고정하기 위해서 transform 안 씀.
            //rigid.AddForce(targetDirection * speed, ForceMode.Impulse);
            transform.Translate(targetDirection * speed * Time.deltaTime, Space.World);
        }

        if(Input.GetKeyDown(KeyCode.Space) && stopAll){
            ;
        }
    }

    public void updateTargetDirection(){
        turnSpeedMultiplier = 1.0f;
        // 카메라의 forward 값 계속 받아오기 위해서
        var forward = mainCamera.transform.TransformDirection(Vector3.forward);
        forward.y = 0;
        var right = mainCamera.transform.TransformDirection(Vector3.right);
        // input.y -> 3차원에서는 z을 의미
        targetDirection = (input.x * right) + (input.y * forward);
    }

    // 충돌했을 때 제어하는 방법
    private void OnCollisionEnter(Collision other){
        // 충돌 대상이 바닥일 때
        if(other.gameObject.tag == "Floor"){
            playerAnimator.SetBool("isJump", false);
        }
        if(other.gameObject.tag == "Enemy"){
            SceneManager.LoadScene(2);
        }
    }
    private void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "JumpItem"){
            skill.GetComponent<itemEat>().ChangeImage();
        }
        if(other.gameObject.tag == "StopItem"){
            effect2.Play();
            Invoke("Stop", 3.0f);
        }
    }
    void Stop(){
        effect2.Stop();
    }
}

