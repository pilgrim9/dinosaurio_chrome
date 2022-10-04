using UnityEngine;

public class Die : MonoBehaviour
{
    public void ondeath()
    {
        GameManager.instance.restart();
    }
}
