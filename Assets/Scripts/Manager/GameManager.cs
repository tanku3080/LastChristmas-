using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public bool OnChangeScene = false;

    public bool gameOverFlag = false;
    public bool gameClearFlag = false;

    public bool titleFlag = false;
    public bool ReStartFlag = false;
    AudioSource source;
    void Start()
    {
        AudioManager.Instance.BGMPlay();
    }
    void Update()
    {
    }

}
