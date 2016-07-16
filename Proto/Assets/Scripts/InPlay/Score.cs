using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public float value = 0.0f;
    private Text scoreValue;

    // Use this for initialization
    void Awake()
    {
        scoreValue = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
       scoreValue.text = string.Format("{0:d10}", (int)value);
    }
}
