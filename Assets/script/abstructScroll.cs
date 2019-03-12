using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class abstructScroll : MonoBehaviour {

    private Text text;
    private RectTransform mytransform;

    void Start() {
        text = transform.Find("adstructText").gameObject.GetComponent<Text>();
        mytransform = GetComponent<RectTransform>();
        abstructTextHeoghtToContentHeight();
    }

    void Update() {
        abstructTextHeoghtToContentHeight();
    }

    private void abstructTextHeoghtToContentHeight() {
        mytransform.sizeDelta = new Vector2(text.rectTransform.sizeDelta.x, text.rectTransform.sizeDelta.y);
        text.rectTransform.sizeDelta = new Vector2(text.rectTransform.sizeDelta.x, text.preferredHeight);
        text.rectTransform.localPosition = new Vector3(text.rectTransform.localPosition.x,text.preferredHeight / -2, text.rectTransform.localPosition.z);
    }
}
