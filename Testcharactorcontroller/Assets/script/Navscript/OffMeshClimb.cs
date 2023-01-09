using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OffMeshClimb : MonoBehaviour
{
    [SerializeField]
    private int offMeshArea = 3;  //오프메시의 구역 (Climb)
    [SerializeField]
    private float climbspped = 1.5f; //오르내리는 이동 속도 
    private NavMeshAgent navMeshAgent;

    private void Awake()
    {
        navMeshAgent= GetComponent<NavMeshAgent>();
    }

    IEnumerator Start()
    {
        while(true)
        {
            //IsOnClimb() 함수의 변화 값이 true일 때 까지 반복 호출 
            yield return new WaitUntil(() => IsOnClimb());

            //올라가거나 내려오는 행동
            yield return StartCoroutine(ClimbOrDescend());
        }
    }

    public bool IsOnClimb()
    {
        //현재 오브젝트의 위치가 OffMeshLink에 있는지 (true/false)
        if (navMeshAgent.isOnOffMeshLink)
        {
            //현재 위치에 있는 OffMeshLink의 데이터
            OffMeshLinkData linkData = navMeshAgent.currentOffMeshLinkData;
            // navMeshAgent.currentOffMeshLinkData.offMeshLink가
            // true이면 수동으로 생성한 OffMeshLink
            // false이면 자동으로 생성한 OffMeshLink

            //현재 위치에 있는 OffMeshLink가 수동으로 생성한 offMeshLink이고, 장소 정보가 "Climb"이면
            if (linkData.offMeshLink !=null && linkData.offMeshLink.area == offMeshArea)
            {
                return true;
            }
        }

        //현재위치에 offMeshLink가 없다면 false
        return false;   
    }

    private IEnumerator ClimbOrDescend()
    {
        //네비게이션을 이용한 이동을 잠시 중지 
        navMeshAgent.isStopped= true;

        //현재 위치에 있는 OffMeshLink의 시작/종료 위치 

        yield return null;
    }
}
