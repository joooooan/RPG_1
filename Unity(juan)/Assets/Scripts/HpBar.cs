using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBar : MonoBehaviour
{
    [SerializeField]
    private GameObject _hpbar_Prefab = null;

    private List<Transform> _monster_ObjectList;
    private List<GameObject> _monster_HpBarList;

    private Camera _mainCam;

    private void Awake()
    {
        _monster_ObjectList = new List<Transform>();
        _monster_HpBarList = new List<GameObject>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < _monster_ObjectList.Count; i++)
        {
            _monster_HpBarList[i].transform.position = _mainCam.WorldToScreenPoint(_monster_ObjectList[i].transform.position + new Vector3(0, 1, 0));
        }
    }

    public void CreateHpBar()
    {
        GameObject[] tag_objects = GameObject.FindGameObjectsWithTag("Monster");
        for (int i = 0; i < tag_objects.Length; i++)
        {
            _monster_ObjectList.Add(tag_objects[i].transform);
            GameObject tag_hpbar = Instantiate(_hpbar_Prefab, tag_objects[i].transform.position, Quaternion.identity, transform);
            _monster_HpBarList.Add(tag_hpbar);
        }
    }
}


