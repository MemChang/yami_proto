using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Combo : MonoBehaviour {

    public int value = 0;
    private Text comboValue;

    // Use this for initialization
    void Awake()
    {
        comboValue = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        comboValue.text = string.Format("{0:d}", value);
    }
}
