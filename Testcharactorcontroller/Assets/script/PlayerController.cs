using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    //���� == �����̽��� 
    private KeyCode jumpkeycode = KeyCode.Space; 
    //������Ʈ�� �����ð�
    private PlayerMove playerMove;
    void Start()
    {
        //�����Ӱ� ���� �޼ҵ带 �������� ���� ������Ʈ �߰�
        playerMove = GetComponent<PlayerMove>(); 
    }

    void Update()
    {
        movement();
    }

    void movement()
    {
        float x = Input.GetAxisRaw("Horizontal"); //�¿� ����Ƽ ���� �޼ҵ�
        float z = Input.GetAxisRaw("Vertical");  //����
        //������ �Է¹��� ���� ������ MoveTo ����
        playerMove.MoveTo(new Vector3(x, 0, z));
        //����Ű�� ��������� ���� ����
        if (Input.GetKeyDown(jumpkeycode))
        {
            playerMove.JumpTo();
        }

    }
}
