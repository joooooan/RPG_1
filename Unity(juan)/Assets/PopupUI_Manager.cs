using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupUI_Manager : MonoBehaviour
{
    public GameObject _inventoryPopup;
    public GameObject _shopPopup;

    private List<GameObject> _activePopupList;

    private List<GameObject> _allPopupList;

    private static PopupUI_Manager instance = null;

    private int _index;

    private void Awake()
    {
        if (null == instance)
        {
            instance = this;

            _activePopupList = new List<GameObject>();
            _index = 0;
            DontDestroyOnLoad(this.gameObject);

        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        if(_activePopupList.Count > 0)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                Debug.Log(_activePopupList.Count);

                _index = _activePopupList.Count - 1;

                _activePopupList[_index].SetActive(false);
                _activePopupList.RemoveAt(_index);
                
            }
        }
    }

    public void Open_PopupUi(GameObject popup_ui)
    {
        //Debug.Log(_activePopupList.Count);

        if(popup_ui.activeSelf == true)
        {
            Close_PopupUi(popup_ui);
        }
        else
        {
            popup_ui.SetActive(true);
            _activePopupList.Add(popup_ui);
        }

    }

    public void Close_PopupUi(GameObject popup_ui)
    {

        popup_ui.SetActive(false);
        
        for(int i= _activePopupList.Count - 1; i >=0; i--)
        {
            if(_activePopupList[i].name == popup_ui.name)
            {
                _activePopupList.RemoveAt(i);
            }
        }
    }

    public static PopupUI_Manager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }




}
