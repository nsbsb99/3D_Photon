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
        #region �Է� Ű�� ���� �÷��̾� �ִϸ��̼ǰ� �̵�
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) // ����
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            animator.SetBool("Run_Forward", true);
            transform.Translate(Vector3.forward * playerSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) // ����
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            animator.SetBool("Run_Forward", true);
            transform.Translate(Vector3.forward * playerSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) // ����
        {
            transform.rotation = Quaternion.Euler(0f, -90f, 0f);
            animator.SetBool("Run_Forward", true);
            transform.Translate(Vector3.forward * playerSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) // ����
        {
            transform.rotation = Quaternion.Euler(0f, 90f, 0f);
            animator.SetBool("Run_Forward", true);
            transform.Translate(Vector3.forward * playerSpeed * Time.deltaTime);
        }
        else // ���� � Ű�� ������ �ʴ´ٸ� => Idle �ִϸ��̼� ����
        {
            animator.SetBool("Run_Forward", false); // Ű �ʱ�ȭ
        }
        #endregion

        #region �÷��̾� ���� ó��
        
        
        
        
        
        
        if (Input.GetKeyDown(KeyCode.Space)) // ����
        {
            Debug.Log("�����̽� ����");

            animator.SetTrigger("Jump_Up");
            rigidbody.AddForce(Vector3.up * playerJumpForce, ForceMode.Impulse);

            isJumping = true;
        }

        
        bool hitFlatform = Physics.Raycast
            (transform.position, Vector3.down, 0.1f, LayerMask.GetMask("Flatform"));

        if (isJumping && hitFlatform) 
        {
            Debug.Log("���� ����");
            animator.SetBool("Jump_Down", true);
        }

        #endregion
    }
}
