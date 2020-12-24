using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [HideInInspector] public int SectionNumber = 1;
    public bool OnChangeScene = false;
    AudioSource source;
    [SerializeField] AudioClip[] Bgm;
    void Start()
    {
        source = gameObject.GetComponent<AudioSource>();
        source.playOnAwake = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneLoadManager.Instance.SceneFadeAndChanging(SceneLoadManager.SceneName.Taitle, true);
        }
        if (OnChangeScene)
        {
            source.loop = true;
            source.clip = Audio();
            source.Play();
            OnChangeScene = false;
        }
    }
    /// <summary>シーンのBGM</summary>
    /// <returns></returns>
    AudioClip Audio()
    {
        var num = 0;
        switch (SceneLoadManager.Instance.scene)
        {
            case SceneLoadManager.SceneName.Taitle:
                num = 0;
                break;
            case SceneLoadManager.SceneName.Setsumei:
                num = 1;
                break;
            case SceneLoadManager.SceneName.GamePlay:
                num = 2;
                break;
            case SceneLoadManager.SceneName.GameOvar:
                num = 3;
                break;
            case SceneLoadManager.SceneName.GameClear:
                num = 4;
                break;
        }
        return Bgm[num];
    }
}
