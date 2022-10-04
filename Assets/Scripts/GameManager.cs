using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake() {
        instance = this;
    }
    public void restart() {
        SceneManager.LoadScene(0);
    }
}
