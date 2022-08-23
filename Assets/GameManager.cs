using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake() {
        instance = this;
    }
    public void restart() {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
