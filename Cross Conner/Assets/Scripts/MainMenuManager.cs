using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text newBestScore;
    [SerializeField] private TMP_Text bestScoreText;

    [SerializeField] private float animationSpeed;
    [SerializeField] private AnimationCurve speedCurve;

    [SerializeField] private AudioClip clickClip;


    private void Awake()
    {
        bestScoreText.text = GameManager.Instance.highScore.ToString();

        if(!GameManager.Instance.isInitialized)
        {
            scoreText.gameObject.SetActive(false);
            newBestScore.gameObject.SetActive(false);
        }
        else
        {
            StartCoroutine(ShowScore());
        }
    }

    private IEnumerator ShowScore()
    {
        int tempScore = 0;
        scoreText.text = tempScore.ToString();

        int currentScore = GameManager.Instance.currentScore;
        int highScore = GameManager.Instance.highScore;

        if (highScore < currentScore) 
        {
            newBestScore.gameObject.SetActive(true);
            GameManager.Instance.highScore = currentScore;
        }
        else
        {
            newBestScore.gameObject.SetActive(false);
        }

        float speed = 1 / animationSpeed;
        float timeElapsed = 0f;

        while (timeElapsed < 1f)
        {
            timeElapsed += speed * Time.deltaTime;
            tempScore = (int)(speedCurve.Evaluate(timeElapsed) * currentScore);
            scoreText.text = tempScore.ToString();
            yield return null;
        }
    }

    public void ClickPlay()
    {
        SoundManager.instance.PlaySound(clickClip);
        GameManager.Instance.GoToGamePlay();
    }
}
