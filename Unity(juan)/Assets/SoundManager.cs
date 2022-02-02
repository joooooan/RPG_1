using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public AudioSource bgSound;
    public AudioClip[] bglist;
    public float _volume;

    private static SoundManager instance = null;

    private void Awake()
    {
        if (null == instance)
        {
            instance = this;

            _volume = 1.0f;
            DontDestroyOnLoad(this.gameObject); //이 GameObject를 싱글톤화.

        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void OnSceneLoaded(Scene arg0,LoadSceneMode arg1)
    {
        for(int i =0; i < bglist.Length; i++)
        {
            if(arg0.name == bglist[i].name)
            {
                BgSoundPlay(bglist[i]);
            }
        }
    }

    public static SoundManager Instance
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

    public void SFXPlay(string sfxName, AudioClip clip)
    {
        GameObject go = new GameObject(sfxName + "Sound");
        AudioSource audiosource = go.AddComponent<AudioSource>();
        audiosource.clip = clip;
        audiosource.Play();

        Destroy(go, clip.length);
    }

    public void BgSoundPlay(AudioClip clip)
    {
        bgSound.clip = clip;
        bgSound.loop = true;
        bgSound.volume = _volume;
        bgSound.Play();
    }



}

