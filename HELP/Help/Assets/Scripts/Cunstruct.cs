using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class Cunstruct : MonoBehaviour
{
    [SerializeField] private List<GameObject> Details;
    private Coroutine moveDetailsCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            if (moveDetailsCoroutine == null) moveDetailsCoroutine = StartCoroutine(MoveDetails());
        });
    }

    private IEnumerator MoveDetails()
    {
        for (int i = 0; i < Details.Count; i++)
        {
            if(Details[i].name == "����")
                yield return MoveBolt(Details[i]);
            if (Details[i].name == "����")
                yield return MoveVint(Details[i]);
            if (Details[i].name == "������ 1")
                yield return MoveDetail_2(Details[i]);
            if (Details[i].name == "������ 2")
                yield return MoveDetail_1(Details[i]);
            if (Details[i].name == "�����")
                yield return MoveShaiba(Details[i]);
            yield return null;
        }

        moveDetailsCoroutine = null;
    }

    private IEnumerator MoveBolt(GameObject bGameObject)
    {
        yield return bGameObject.GetComponent<MovePosition>().EnableMove = true;
        Debug.Log("������� ����");
    }

    private IEnumerator MoveDetail_1(GameObject bGameObject)
    {
        yield return bGameObject.GetComponent<MovePosition>().EnableMove = true;
        Debug.Log("������� ������ 1");
    }

    private IEnumerator MoveDetail_2(GameObject bGameObject)
    {
        yield return bGameObject.GetComponent<MovePosition>().EnableMove = true;
        Debug.Log("������� ������ 2");
    }

    private IEnumerator MoveShaiba(GameObject bGameObject)
    {
        yield return bGameObject.GetComponent<MovePosition>().EnableMove = true;
        Debug.Log("������� �����");
    }

    private IEnumerator MoveVint(GameObject bGameObject)
    {
        yield return bGameObject.GetComponent<MovePosition>().EnableMove = true;
        Debug.Log("������� ����");
    }
}
