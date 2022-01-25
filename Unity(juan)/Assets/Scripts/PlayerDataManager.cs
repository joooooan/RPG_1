using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using System;

public class PlayerDataManager : MonoBehaviour
{
    private static PlayerDataManager instance = null;

    PlayerData _player;

    public Vector3 _currPlayerPosition;

    public PlayerData Player {get { return _player;  } set { _player = value; } }

    private void Awake()
    {
        if (null == instance)
        {
            instance = this;

            _currPlayerPosition = Vector3.zero;
            LoadPlayerDataToJson(); //Player 데이터를 로드.

            DontDestroyOnLoad(this.gameObject); //이 GameObject를 싱글톤화.

        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static PlayerDataManager Instance
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
       
    public void LoadPlayerDataToJson() //Player 데이터를 지정된 경로에서 Json 파일의 정보를 로드.
    {
        string path = Path.Combine(Application.dataPath, "PlayerData.json");
        
        FileInfo _file = new FileInfo(path);

        if (_file.Exists)
        {
            //파일
            string jsonData = File.ReadAllText(path);

            //암호화
            byte[] bytes = System.Convert.FromBase64String(jsonData);
            string reformat = System.Text.Encoding.UTF8.GetString(bytes);

            //로드
            _player = JsonConvert.DeserializeObject<PlayerData>(reformat);

            Debug.Log("파일 확인 로드 중");

            
        }
        else
        {
            _player = new PlayerData(); //파일이 없을 경우 새로생성 후 저장.
            SavePlayerDataToJson();

            Debug.Log("파일 없음 생성 중");

        }
               
    }

    public void SavePlayerDataToJson() //Player 데이터를 Json 파일로 변환 후 지정된 경로에 저장.
    {
        //파일
        string jsonData = JsonConvert.SerializeObject(_player);

        //암호화 
        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(jsonData);
        string format = System.Convert.ToBase64String(bytes);

        //경로
        string path = Path.Combine(Application.dataPath, "PlayerData.json");      
        
        //저장
        File.WriteAllText(path, format);
    }

    private void InitData()
    {
        
    }

}
