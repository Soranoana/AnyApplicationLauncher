using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class titleScroll : MonoBehaviour {

    private Text text;
    private RectTransform mytransform;
    private float formWidth=0;
    private float nowTime=0;
    private bool scrollOrNot = false;

	void Start () {
        text = transform.Find("titleText").gameObject.GetComponent<Text>();
        mytransform = GetComponent<RectTransform>();
        
        formWidth = mytransform.sizeDelta.x;
        titleTextWidthToContentWidth();

        if (transform.Find("titleText").GetComponent<RectTransform>().sizeDelta.x>transform.parent.parent.GetComponent<RectTransform>().sizeDelta.x) {
            scrollOrNot=true;
        }
    }

    void Update () {
        if (scrollOrNot) {
            nowTime+=Time.deltaTime;
            textSlideAuto();
        }
        titleTextWidthToContentWidth();
    }

    private void titleTextWidthToContentWidth() {
        mytransform.sizeDelta = new Vector2(text.rectTransform.sizeDelta.x, text.rectTransform.sizeDelta.y);
        text.rectTransform.sizeDelta = new Vector2(text.preferredWidth, text.rectTransform.sizeDelta.y);
        text.rectTransform.localPosition = new Vector3(text.preferredWidth / 2, text.rectTransform.localPosition.y, text.rectTransform.localPosition.z);
    }

    private void textSlideAuto() {
        if (nowTime < 5f) {
            //停止している
        }else {
            if (-mytransform.localPosition.x < mytransform.sizeDelta.x+500) {
                mytransform.localPosition = new Vector3(mytransform.localPosition.x - Time.deltaTime*1000, mytransform.localPosition.y, mytransform.localPosition.z);
            }else {
                mytransform.localPosition = new Vector3(0, mytransform.localPosition.y, mytransform.localPosition.z);
                nowTime = 0;
            }
        }
    }
}
