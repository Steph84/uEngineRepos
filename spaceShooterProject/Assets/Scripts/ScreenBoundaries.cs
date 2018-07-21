using UnityEngine;

public class ScreenBoundaries : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {
        // get the sprite position in the ViewPort coordinates
        var spriteCoord = Camera.main.WorldToViewportPoint(transform.position);

        // clamp the coordinates to keep the sprite into the ViewPort
        spriteCoord.x = Mathf.Clamp(spriteCoord.x, 0.01f, 0.99f);
        spriteCoord.y = Mathf.Clamp(spriteCoord.y, 0.01f, 0.99f);

        // actualize the sprite position
        transform.position = Camera.main.ViewportToWorldPoint(spriteCoord);
    }
}
