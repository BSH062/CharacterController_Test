using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OffMeshClimb : MonoBehaviour
{
    [SerializeField]
    private int offMeshArea = 3;  //�����޽��� ���� (Climb)
    [SerializeField]
    private float climbspped = 1.5f; //���������� �̵� �ӵ� 
    private NavMeshAgent navMeshAgent;

    private void Awake()
    {
        navMeshAgent= GetComponent<NavMeshAgent>();
    }

    IEnumerator Start()
    {
        while(true)
        {
            //IsOnClimb() �Լ��� ��ȭ ���� true�� �� ���� �ݺ� ȣ�� 
            yield return new WaitUntil(() => IsOnClimb());

            //�ö󰡰ų� �������� �ൿ
            yield return StartCoroutine(ClimbOrDescend());
        }
    }

    public bool IsOnClimb()
    {
        //���� ������Ʈ�� ��ġ�� OffMeshLink�� �ִ��� (true/false)
        if (navMeshAgent.isOnOffMeshLink)
        {
            //���� ��ġ�� �ִ� OffMeshLink�� ������
            OffMeshLinkData linkData = navMeshAgent.currentOffMeshLinkData;
            // navMeshAgent.currentOffMeshLinkData.offMeshLink��
            // true�̸� �������� ������ OffMeshLink
            // false�̸� �ڵ����� ������ OffMeshLink

            //���� ��ġ�� �ִ� OffMeshLink�� �������� ������ offMeshLink�̰�, ��� ������ "Climb"�̸�
            if (linkData.offMeshLink !=null && linkData.offMeshLink.area == offMeshArea)
            {
                return true;
            }
        }

        //������ġ�� offMeshLink�� ���ٸ� false
        return false;   
    }

    private IEnumerator ClimbOrDescend()
    {
        //�׺���̼��� �̿��� �̵��� ��� ���� 
        navMeshAgent.isStopped= true;

        //���� ��ġ�� �ִ� OffMeshLink�� ����/���� ��ġ 

        yield return null;
    }
}
