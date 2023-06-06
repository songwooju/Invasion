using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float gameTime;
    public float maxGameTime = 5 * 60f;
    public Text GameTimeText;
    public Text killCountText;

    public int killCount; // Added killCount variable

    public PoolManager pool;
    public Player player;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        gameTime += Time.deltaTime;

        if (gameTime > maxGameTime)
        {
            gameTime = maxGameTime;
        }

        GameTimeText.text = "Time : " + (int)gameTime;
        killCountText.text = "Kill : " + killCount;
    }

    public void IncreaseKillCount()
    {
        killCount++;
    }
}
