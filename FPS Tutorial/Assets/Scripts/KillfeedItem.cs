using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillfeedItem : MonoBehaviour {

    [SerializeField]
    Text text;

    public void Setup(string player, string source)
    {
        text.text = "<b><color=orange>" + source + "</b></color>" + " killed " + "<b><color=red>" + player + "</b></color>";
    }
}
