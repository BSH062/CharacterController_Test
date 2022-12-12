using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    //점프 == 스페이스바 
    private KeyCode jumpkeycode = KeyCode.Space; 
    //컴포넌트를 가져올곳
    private PlayerMove playerMove;
    void Start()
    {
        //움직임과 점프 메소드를 가져오기 위해 컴포넌트 추가
        playerMove = GetComponent<PlayerMove>(); 
    }

    void Update()
    {
        movement();
    }

    void movement()
    {
        float x = Input.GetAxisRaw("Horizontal"); //좌우 유니티 제공 메소드
        float z = Input.GetAxisRaw("Vertical");  //상하
        //위에서 입력받은 값을 변수로 MoveTo 실행
        playerMove.MoveTo(new Vector3(x, 0, z));
        //점프키를 눌렀을경우 점프 실행
        if (Input.GetKeyDown(jumpkeycode))
        {
            playerMove.JumpTo();
        }

    }
}
