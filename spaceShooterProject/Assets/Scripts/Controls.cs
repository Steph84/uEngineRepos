using UnityEngine;

public class Controls : MonoBehaviour
{

    private Vector2 currentPos = new Vector2();
    private readonly float unitPerSec = 6.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float moveSpeed = unitPerSec * Time.deltaTime;

        // reinitialize currentPos otherwise
        currentPos = transform.position;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            currentPos.y = currentPos.y + moveSpeed;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            currentPos.y = currentPos.y - moveSpeed;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            currentPos.x = currentPos.x - moveSpeed;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            currentPos.x = currentPos.x + moveSpeed;
        }

        transform.position = currentPos;
    }
}
