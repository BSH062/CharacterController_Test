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
        // ������ �̵� �ൿ�� �ϰ� �־��ٸ� �ڷ�ƾ ���� 
        StopCoroutine("OnMove");
        //�̵��ӵ�
        nav.speed = movespeed;
        //��ǥ���� ����(��ǥ������ ��� ��� �� �˾Ƽ� ������)
        nav.SetDestination(goalPosition);
        //�̵� �ൿ�� ���� �ڷ�ƾ ����
        StartCoroutine("OnMove");


    }
    IEnumerator OnMove()
    {
        while (true)
        {
            //��ǥ ��ġ�� �� ��ġ�� �Ÿ��� 0.1 �̸��϶� (����������)
            if (Vector3.Distance(nav.destination,transform.position)<0.1f)
            {
                //����ġ�� ��ǥ���Ƿ� ����
                transform.position = nav.destination;
                //SetDestination�� ���� ������ ��θ� �ʱ�ȭ 
                nav.ResetPath();
                break;
            }
            yield return null;
        }
    }
}
