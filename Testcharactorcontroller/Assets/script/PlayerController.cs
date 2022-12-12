using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private KeyCode jumpkeycode = KeyCode.Space;
    private PlayerMove playerMove;
    void Start()
    {
        playerMove = GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }

    void movement()
    {
        float x = Input.GetAxisRaw("Horizontal");//ÁÂ¿ì
        float z = Input.GetAxisRaw("Vertical");//»óÇÏ

        playerMove.MoveTo(new Vector3(x, 0, z));

        if (Input.GetKeyDown(jumpkeycode))
        {
            playerMove.JumpTo();
        }

    }
}
