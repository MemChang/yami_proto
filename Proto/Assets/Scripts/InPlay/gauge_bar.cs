using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class gauge_bar : MonoBehaviour {

    //public float fallSpeed = 0.03f;
    private Image gaugebar;
    private float width;
    public float fillAmount = 1.0f; // 0.0 ~ 1.0 게이지 조절
    private float currentFill = 1.0f;
    Vector3 pos;

    //private int temp = 0;

    void Awake()
    {
        gaugebar = GetComponent<Image>();
       // pos = gaugebar.rectTransform.localPosition;
        width = gaugebar.rectTransform.rect.width;
        Reset();

    }

    public void Reset()
    {
        fillAmount = currentFill = 1.0f;
        setGaugeBarFill(fillAmount);
        GaugeBarMotion(currentFill);
    }

    public void setGaugeBarFill(float val)
    {
        fillAmount = val;
    }

    void GaugeBarMotion(float val)
    {
        //pos.x = (val - 1.0f) * width;
        // gaugebar.rectTransform.localPosition = pos;
        gaugebar.fillAmount = val;
    }

    // Update is called once per frame
    void Update()
    {

        currentFill = Mathf.Lerp(currentFill, fillAmount, Time.deltaTime * 2f);
        GaugeBarMotion(currentFill);

        /*
        if(gaugebar.fillAmount > 0.3)
        gaugebar.fillAmount -= fallSpeed * Time.deltaTime;*/
        //setGaugeBarFill(fillAmount);
    }
}
