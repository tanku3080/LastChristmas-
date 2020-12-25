using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SE
{
    M_se,S_se,
}

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] AudioClip[] Bgm;
    [SerializeField] AudioClip[] se = new AudioClip[2];
    [HideInInspector] public int SectionNumber = 0;
    AudioSource source;
    private string nowScene = null;
    // Start is called before the first frame update
    void Start()
    {
        source = gameObject.GetComponent<AudioSource>();
        source.playOnAwake = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BGMPlay()
    {
        nowScene = SceneManager.GetActiveScene().name;
        source.loop = true;
        source.clip = AudioBGM();
        source.Play();
    }
    /// <summary>
    /// メインSEの再生関数
    /// </summary>
    public void M_SEPlay()
    {
        Debug.Log("呼び出された");
        source.loop = false;
        source.PlayOneShot(AudioSE());
    }
    /// <summary>
    /// サブSEの再生関数
    /// </summary>
    public void S_SEPlay()
    {
        Debug.Log("呼び出された");
        source.loop = false;
        source.PlayOneShot(AudioSE(SE.S_se));
    }

    /// <summary>シーンのBGM</summary>
    /// <returns></returns>
    AudioClip AudioBGM()
    {
        if (nowScene == SceneLoadManager.SceneName.Taitle.ToString())
        {
            this.SectionNumber = 1;
        }
        if (nowScene == SceneLoadManager.SceneName.Setsumei.ToString())
        {
            SectionNumber = 2;
        }
        if (nowScene == SceneLoadManager.SceneName.Game.ToString())
        {
            SectionNumber = 3;
        }
        if (nowScene == SceneLoadManager.SceneName.GameClear.ToString())
        {
            SectionNumber = 4;
        }
        if (nowScene == SceneLoadManager.SceneName.GameOvar.ToString())
        {
            SectionNumber = 5;
        }
        return Bgm[SectionNumber];
    }

    /// <summary>
    /// シーン毎のSEこの関数に限っては要修正
    /// </summary>
    /// <param name="sE">M_seはシーン切り替えなどに使われる。S_seは通常クリックに使われる</param>
    AudioClip AudioSE(SE sE = SE.M_se)
    {
        var num = 0;
        switch (sE)
        {
            case SE.M_se:
                num = 0;
                break;
            case SE.S_se:
                num = 1;
                break;
        }
        return se[num];
    }
}
