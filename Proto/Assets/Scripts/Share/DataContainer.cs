using UnityEngine;
using System.Collections;
using System;

public class DataContainer : MonoBehaviour {
    static int score;
    static TimeSpan playTime;
    static int coin;
    static int maxCombo;

    // Use this for initialization
    static public void setScore(int _score)
    {
        score = _score;
    }
    static public void setMaxCombo(int _maxCombo)
    {
        maxCombo = _maxCombo;
    }
    static public void setPlayTime(TimeSpan _playTime)
    {
        playTime = _playTime;
    }
    static public void setCoin(int _coin)
    {
        coin = _coin;
    }

    // Update is called once per frame
    static public int getScore () {
        return score;
	}
    static public TimeSpan getPlayTime()
    {
        return playTime;
    }
    static public int getCoin()
    {
        return coin;
    }
}
