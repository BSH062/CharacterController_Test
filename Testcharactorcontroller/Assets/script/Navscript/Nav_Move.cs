using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Nav_Move : MonoBehaviour
{

    [SerializeField]
    private float movespeed = 5.0f;
    private NavMeshAgent nav;
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    
    void Update()
    {
        
    }

    public void moveTo(Vector3 goalPosition)
    {
        // 기존에 이동 행동을 하고 있었다면 코루틴 중지 
        StopCoroutine("OnMove");
        //이동속도
        nav.speed = movespeed;
        //목표지점 설정(목표까지의 경로 계산 후 알아서 움직임)
        nav.SetDestination(goalPosition);
        //이동 행동에 대한 코루틴 시작
        StartCoroutine("OnMove");


    }
    IEnumerator OnMove()
    {
        while (true)
        {
            //목표 위치와 내 위치의 거리가 0.1 미만일때 (도착했을때)
            if (Vector3.Distance(nav.destination,transform.position)<0.1f)
            {
                //내위치를 목표위피로 설정
                transform.position = nav.destination;
                //SetDestination에 의해 설정된 경로를 초기화 
                nav.ResetPath();
                break;
            }
            yield return null;
        }
    }
}
