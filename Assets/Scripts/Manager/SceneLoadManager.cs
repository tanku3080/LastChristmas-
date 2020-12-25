using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// シーン切り替えとフェードを行うことのできるスクリプト
/// </summary>
public class SceneLoadManager : Singleton<SceneLoadManager>
{
    public enum SceneName
    {
        Taitle, Setsumei, GamePlay, GameOvar, GameClear,
    }
    [HideInInspector] public SceneName scene;
    CanvasGroup group = null;
    string sceneName = null;
    float timer = 0;
    bool t = true;

    void Start()
    {
        var t = this.gameObject.transform.GetChild(0).GetChild(0).GetComponent<Image>();
        group = gameObject.transform.GetChild(0).GetComponent<CanvasGroup>();
        t.color = Color.black;
        group.alpha = 1;
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (t)
        {
            RootSceneFadeAndChanging();
        }
    }

    /// <summary>
    /// 好きなシーンの切り替えとフェードを行う関数
    /// </summary>
    /// <param name="name">遷移先のシーンを選択</param>
    /// <param name="fadeStart">trueならフェードありfalseはフェード無し</param>
    /// <param name="sceneChangeStart">trueならシーン遷移スタート</param>
    /// <param name="fadeInterval">フェードの間隔を変えることが出来る</param>
    public void SceneFadeAndChanging(SceneName name, bool fadeStart = false, bool sceneChangeStart = false,float fadeInterval = 0.05f)
    {
        if (fadeStart)
        {
            //0.0005はmeetingに使うとちょうどいいかも？
            if (group.alpha > 0)//透明化する
            {
                group.alpha -= timer * fadeInterval;
            }
            else if(group.alpha < 0)//あらわれる
            {
                group.alpha += timer * fadeInterval;
            }
            else //ゼロなら
            {
                GameManager.Instance.OnChangeScene = true;
            }
        }
        if (sceneChangeStart)
        {
            if (name.ToString() == SceneManager.GetActiveScene().name && sceneChangeStart == false) return;
            sceneName = name.ToString();
            SceneManager.LoadScene(sceneName);
        }
        else return;
    }

    /// <summary>
    /// 呼び出されるだけでシーンに応じて次のシーン遷移とフェードが行われる関数
    /// </summary>
    public void RootSceneFadeAndChanging()
    {
        float fadeInterval = 0.05f;
        //0.0005はmeetingに使うとちょうどいいかも？
        if (group.alpha > 0)//透明化する
        {
            group.alpha -= timer * fadeInterval;
        }
        else if (group.alpha < 0)//あらわれる
        {
            group.alpha += timer * fadeInterval;
        }
        else //ゼロなら
        {
            switch (scene)
            {
                case SceneName.Taitle:
                    sceneName = "Setsumei";
                    break;
                case SceneName.Setsumei:
                    sceneName = "GamePlay";
                    break;
                case SceneName.GamePlay:
                    if (GameManager.Instance.gameClearFlag) sceneName = "GameClear";
                    if (GameManager.Instance.gameOverFlag) sceneName = "GameOvar";
                    break;
                case SceneName.GameOvar:
                    if (GameManager.Instance.titleFlag) sceneName = "Taitle";
                    if (GameManager.Instance.ReStartFlag) sceneName = "GamePlay";
                    break;
                case SceneName.GameClear:
                    if (GameManager.Instance.titleFlag) sceneName = "Taitle";
                    break;
            }
            SceneManager.LoadScene(sceneName);
            t = false;
        }
    }
}
