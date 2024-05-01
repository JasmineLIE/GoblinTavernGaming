using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIInteraction : MonoBehaviour
{
    [SerializeField] private CanvasGroup UIGroup;
    [SerializeField] private AudioSource click;
    [SerializeField] private AudioSource bgm;
    private bool fadeOut;

    // Start is called before the first frame update

    // Update is called once per frame

    private void Awake()
    {
        click = GetComponent<AudioSource>();
        UIGroup = GetComponent<CanvasGroup>();  
        fadeOut = false;
        UIGroup.alpha = 1;
    }
    void Update()
    {
        if (fadeOut)
        {
            if (UIGroup.alpha > 0)
            {
                UIGroup.alpha -= Time.deltaTime;
                if (UIGroup.alpha <= 0)
                {
                    fadeOut = false;
                }
            }
        }
    }

    public void PlayGame()
    {
        print("We should be transitioning now.");
        fadeOut = true;
        click.Play();
        StartCoroutine(Transition());
    }

    public IEnumerator Transition()
    {
        StartCoroutine(AudioFadeout.StartFade(bgm, 2.5f, 0f));
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("Cutscene");

    }
}