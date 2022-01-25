using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    public int GetNextIndex(int currIndex)
    {
        return (currIndex + 1) % this.transform.childCount;
    }

    public Vector3 GetWayPoint(int currIndex)
    {
        return this.transform.GetChild(currIndex).position;
    }

    public void CreateWayPoint(GameObject ParentNode)
    {
        // ** 오브젝트를 생성한다. 그리고 오브젝트의 이름을 "Node 0", "Node 1", "Node 2", "Node 3" 등등.... 으로 설정해준다.
        GameObject NodeObj = new GameObject("Node " + ParentNode.transform.childCount);

        // ** 생성된 오브젝트의 부모를 ParentNode로 설정해준다.
        NodeObj.transform.SetParent(ParentNode.transform);


        //** 포지션 초기화 진행 가능.


        // ** 그리고 생선된 오브젝트에 컴퍼넌트를 추가한다.
        // ** GetGizmo = 위치확인용 
        NodeObj.AddComponent<GetGizmo>();

        // ** Node = 다음 노드를 가르키는 용으로 사용된다.
        // ** 생성된 오브젝트에 노드 컴퍼넌트를 받아온다.
        Node CurrentNode = NodeObj.AddComponent<Node>();

        // ** 노드의 인덱스를 생성한다.
        CurrentNode.Index = ParentNode.transform.childCount - 1;


        while (true)
        {
            // ** 생성된 노드의 위치를 랜덤하게 셋팅한다.
            // ** 현재는 (-5 ~ +5) 사이값으로 생성한다.
            // ** 이때, Y좌표에 값은 변경 시키지 않는다. 
            NodeObj.transform.position = new Vector3(Random.Range(-20.0f,50.0f), 0.0f, Random.Range(10.0f, 77.0f));

            float Distance = 1000.0f;

            // ** 만약 ParentNode의 하위에 자식노드의 개수가 2개 이상이라면...
            if (ParentNode.transform.childCount > 1)
            {
                // ** 이 전 노드를 찾는다. 
                Node PreviousNode = ParentNode.transform.GetChild(ParentNode.transform.childCount - 2).GetComponent<Node>();

                // ** 찾은 이전 노드에 현재 노드를 넣는다.
                PreviousNode.NextNode = ParentNode.transform.GetChild(ParentNode.transform.childCount - 1).GetComponent<Node>();

                // ** 그리고 현재 노드에 처번째 노드를 넣어 반복될 수 있도록 한다.
                CurrentNode.NextNode = ParentNode.transform.GetChild(0).GetComponent<Node>();

                Distance = Vector3.Distance(PreviousNode.transform.position, CurrentNode.transform.position);
            }

            if (Distance > 1.5f)
                break;
        }
    }
}
