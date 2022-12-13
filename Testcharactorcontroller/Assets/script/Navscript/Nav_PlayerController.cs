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
        //����ī�޶�κ��� ���콺 ��ǥ ��ġ�� �����ϴ� ���� ����
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction*20, Color.blue);
        //���콺 ��Ŭ��
        if (Input.GetMouseButtonDown(0))
        {
            //������ ������ġ ���� ���� �������� ������ ������ ���� ����
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                //hit.transform.position �΋H��������Ʈ�� ��ġ 
                //hit.point ������ ������Ʈ�� �΋H�� ���� ��ġ 
                navmove.moveTo(hit.point);
            }
        }
    }
}
