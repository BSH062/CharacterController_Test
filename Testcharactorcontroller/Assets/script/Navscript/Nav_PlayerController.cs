using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nav_PlayerController : MonoBehaviour
{
    private Nav_Move navmove;
    void Start()
    {
        navmove = GetComponent<Nav_Move>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        //메인카메라로부터 마우스 좌표 위치를 관통하는 광선 생성
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction*20, Color.blue);
        //마우스 좌클릭
        if (Input.GetMouseButtonDown(0))
        {
            //광선의 시작위치 부터 레이 방향으로 무한한 길이의 광선 생성
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                //hit.transform.position 부딫힌오브젝트의 위치 
                //hit.point 광선과 오브젝트가 부딫힌 세부 위치 
                navmove.moveTo(hit.point);
            }
        }
    }
}
