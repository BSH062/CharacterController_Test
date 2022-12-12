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
    
    //ĳ���� ��Ʈ�ѷ� ������Ʈ�� �޾ƿ� ��
    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        //��Ʈ�ѷ��� �⺻������ �����ϴ� ���� üũ ���� ���� ���������� �ʴٰ���
        if (characterController.isGrounded ==false)
        {
            //�߷��� -���̱� ������ �������������� �������� 0�̵Ǵ� �������� ���� �� ����
            moveDirection.y +=gravity*Time.deltaTime;
        }
        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
    }
  
    public void MoveTo(Vector3 direction)
    {
        //moveDirection = direction;
        //������ ���� y���� ��ȭ�� ������ ������ y���� ���ΰ��� 
        moveDirection = new Vector3(direction.x, moveDirection.y, direction.z);
    }
    public void JumpTo()
    {
        if (characterController.isGrounded==true)
        {
            //�������� �ʴ� ����3��ŭ y������ ��� ������Ʈ�� �߷°� �������� �Ѽ����� 3���� �ٷ� �̵����� ����
            moveDirection.y = jumpforce;
        }
    }

}
