using UnityEngine;

public class ButtonFade : MonoBehaviour
{
    CanvasGroup group;
   [SerializeField] float fadeInterval = 0.5f;
    float timer = 0;
    bool titleOn = false;
    void Start()
    {
        group = gameObject.GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Return))
        {
            titleOn = true;
        }
        if (titleOn)
        {
            FadeStart();
        }
    }

    void FadeStart()
    {
        //0.0005はmeetingに使うとちょうどいいかも？
        if (group.alpha >= 0.70)//透明化する
        {
            group.alpha -= timer * fadeInterval;
        }
        else//あらわれる
        {
            group.alpha += timer * fadeInterval;
        }
    }
}
