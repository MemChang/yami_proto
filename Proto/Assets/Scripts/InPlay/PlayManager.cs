using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class PlayManager{

    //Data
    static int score;
    static int maxCombo;
    static TimeSpan playTime;
    static DateTime startTime;

    static int coin;

    //state
    enum STATE { START, PLAY, FERVER_TIME, STOP, END };
    static STATE state=STATE.START;
    
    //toggle
    bool ferver=false;
    bool stop=false;
    bool end=false;

    static gauge_bar _gauge;

   static public void setMaxCombo(int _combo)
    {
        if (_combo > maxCombo) maxCombo = _combo;
        Debug.Log(maxCombo);
    }
	static public void startState () {
        score = 0;
        startTime = DateTime.Now;
        coin = 0;
        state = STATE.PLAY;
        maxCombo=0;

        _gauge = GameObject.FindObjectOfType<gauge_bar>();
        _gauge.setGaugeBarFill(1.0f);
        

        Debug.Log("Start State");
        playState();
        
	}
    static public void playState()
    {
        
    }
    static public void ferverState()
    {

    }
    static public void stopState()
    {

        //long elapsedTicks = DateTime.Now.Ticks - startTime.Ticks;
        //playTime = new TimeSpan(elapsedTicks);
    }
    static public void endState()
    {
        score = GameObject.FindObjectOfType<Score>().value;
        //playTime update


        //////save
        DataContainer.setScore(score);
        DataContainer.setMaxCombo(maxCombo);
        DataContainer.setPlayTime(playTime);
        DataContainer.setCoin(coin);
    }


}
