using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int PlayerScoreL = 0;
    public int PlayerScoreR = 0;

    public GameObject BackMenu;
    public GameObject PlayerWin;
    public GameObject BotWin;

    public TMP_Text playerscore;
    public TMP_Text botscore;

    public static GameManager instance;

    public GameObject left;
    public GameObject right;
    public GameObject leftgoal;
    public GameObject rightgoal;
    public GameObject bot;

    public AudioSource audioSource;
    public AudioClip newAudioClip;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {

        playerscore.text = PlayerScoreL.ToString();
        botscore.text = PlayerScoreR.ToString();
    }



    public void Score(string wallID)
    {
        if (wallID == "Leftwall")
        {
            PlayerScoreR = PlayerScoreR + 10;
            botscore.text = PlayerScoreR.ToString();
        }
        else
        {
            PlayerScoreL = PlayerScoreL + 10;
            playerscore.text = PlayerScoreL.ToString();

        }
        ScoreCheck();
    }

    public void ScoreCheck()
    {
        if (PlayerScoreL == 50)
        {
            Rigidbody2D botgod = bot.GetComponent<Rigidbody2D>();
            botgod.velocity = botgod.velocity * 2;
            ChangeAudio();
        }

        if (PlayerScoreL == 100)
        {
            BackMenu.SetActive(true);
            PlayerWin.SetActive(true);

            BoxCollider2D left = leftgoal.GetComponent<BoxCollider2D>();
            left.isTrigger = false;

            BoxCollider2D right = rightgoal.GetComponent<BoxCollider2D>();
            right.isTrigger = false;
        }
        else if (PlayerScoreR == 100)
        {
            BackMenu.SetActive(true);
            BotWin.SetActive(true);

            BoxCollider2D left = leftgoal.GetComponent<BoxCollider2D>();
            left.isTrigger = false;

            BoxCollider2D right = rightgoal.GetComponent<BoxCollider2D>();
            right.isTrigger = false;
        }

    }

    public void ChangeAudio()
    {
        if (audioSource.clip != newAudioClip) 
        {
            audioSource.Stop();          
            audioSource.clip = newAudioClip; 
            audioSource.Play();          
        }

    }

}