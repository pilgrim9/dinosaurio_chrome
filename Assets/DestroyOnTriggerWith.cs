using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTriggerWith : MonoBehaviour
{
    public string with;
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("trigger");
        if (other.gameObject.CompareTag(with))
        {
            Destroy(gameObject);
        }
    }
}
