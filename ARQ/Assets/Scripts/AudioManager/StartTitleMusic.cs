using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTitleMusic : MonoBehaviour {

    void Start()
    {
        AudioManager.instance.PlayBGM("ARQtitlemenu");
    }
}
