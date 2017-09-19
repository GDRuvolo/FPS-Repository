using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FlashingText : MonoBehaviour {

    //Script used to flash the text this script is attached to

    [SerializeField]
    private float timer;
    [SerializeField]
    Text joinText;
    [SerializeField]
    Image ButtonImage;

    // Update is called once per frame
    void Update () {

        timer += Time.deltaTime;

        if(timer >= 0.5)
        {
            joinText.enabled = true;
            ButtonImage.enabled = true;
        }

        if (timer >= 1)
        {
            joinText.enabled = false;
            ButtonImage.enabled = false;
            timer = 0.0f;
        }
	}
}
