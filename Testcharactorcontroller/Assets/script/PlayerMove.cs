using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5.0f;//�̵��ӵ�
    private Vector3 moveDirection; //�̵�����
    private float gravity = -9.81f; //�߷°��
    [SerializeField]
    private float jumpforce = 3.0f;//���� ��
    
    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (characterController.isGrounded ==false)
        {
            moveDirection.y +=gravity*Time.deltaTime;
        }
        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
    }
  
    public void MoveTo(Vector3 direction)
    {
        //moveDirection = direction;
        moveDirection = new Vector3(direction.x, moveDirection.y, direction.z);
    }
    public void JumpTo()
    {
        if (characterController.isGrounded==true)
        {
            moveDirection.y = jumpforce;
        }
    }

}
