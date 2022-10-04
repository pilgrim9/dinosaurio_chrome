using UnityEngine;

public class BoxMovement : MonoBehaviour
{
    public float speed = 10f;

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        transform.Translate(new Vector3(x * Time.deltaTime * speed, 0,0));
    }
}
