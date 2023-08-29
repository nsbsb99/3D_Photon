using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rigidbody;

    private float playerSpeed = 10f;
    private float playerJumpForce = 8f;
    private bool isJumping = false;

    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();  
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        #region 입력 키에 따른 플레이어 애니메이션과 이동
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) // 앞쪽
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            animator.SetBool("Run_Forward", true);
            transform.Translate(Vector3.forward * playerSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) // 뒤쪽
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            animator.SetBool("Run_Forward", true);
            transform.Translate(Vector3.forward * playerSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) // 좌측
        {
            transform.rotation = Quaternion.Euler(0f, -90f, 0f);
            animator.SetBool("Run_Forward", true);
            transform.Translate(Vector3.forward * playerSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) // 우측
        {
            transform.rotation = Quaternion.Euler(0f, 90f, 0f);
            animator.SetBool("Run_Forward", true);
            transform.Translate(Vector3.forward * playerSpeed * Time.deltaTime);
        }
        else // 만약 어떤 키도 누르지 않는다면 => Idle 애니메이션 복귀
        {
            animator.SetBool("Run_Forward", false); // 키 초기화
        }
        #endregion

        #region 플레이어 점프 처리
        
        
        
        
        
        
        if (Input.GetKeyDown(KeyCode.Space)) // 점프
        {
            Debug.Log("스페이스 누름");

            animator.SetTrigger("Jump_Up");
            rigidbody.AddForce(Vector3.up * playerJumpForce, ForceMode.Impulse);

            isJumping = true;
        }

        
        bool hitFlatform = Physics.Raycast
            (transform.position, Vector3.down, 0.1f, LayerMask.GetMask("Flatform"));

        if (isJumping && hitFlatform) 
        {
            Debug.Log("땅을 감지");
            animator.SetBool("Jump_Down", true);
        }

        #endregion
    }
}
