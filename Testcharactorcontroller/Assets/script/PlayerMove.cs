using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5.0f;//이동속도
    private Vector3 moveDirection; //이동방향
    private float gravity = -9.81f; //중력계수
    [SerializeField]
    private float jumpforce = 3.0f;//점프 힘
    
    //캐릭터 컨트롤러 컴포넌트를 받아올 곳
    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        //컨트롤러가 기본적으로 제공하는 지면 체크 상태 별로 믿을만하지 않다고함
        if (characterController.isGrounded ==false)
        {
            //중력은 -값이기 때문에 땅에서떨어지는 순간부터 0이되는 지점까지 점프 후 착지
            moveDirection.y +=gravity*Time.deltaTime;
        }
        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
    }
  
    public void MoveTo(Vector3 direction)
    {
        //moveDirection = direction;
        //점프로 인한 y축은 변화가 있을수 있으니 y축은 따로관리 
        moveDirection = new Vector3(direction.x, moveDirection.y, direction.z);
    }
    public void JumpTo()
    {
        if (characterController.isGrounded==true)
        {
            //접지하지 않는 순간3만큼 y축으로 상승 업데이트에 중력값 적용으로 한순간에 3으로 바로 이동하지 않음
            moveDirection.y = jumpforce;
        }
    }

}
