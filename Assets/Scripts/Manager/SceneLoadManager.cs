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
    public SceneName scene;
    CanvasGroup group = null;
    string sceneName = null;
    float timer = 0;

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
    }

    /// <summary>
    /// シーンの切り替えとフェードを行う関数
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
            if (group.alpha >= 0)//透明化する
            {
                group.alpha -= timer * fadeInterval;
            }
            else//あらわれる
            {
                group.alpha += timer * fadeInterval;
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
}
