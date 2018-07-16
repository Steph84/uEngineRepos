using UnityEngine;

public class ScreenBoundaries : MonoBehaviour {

    BoxCollider2D myCollider;

	void Start () {
        // get the component
        myCollider = GetComponent<BoxCollider2D>();
        if (myCollider == null) // if not create one with default values
        {
            myCollider = gameObject.AddComponent<BoxCollider2D>();
        }
    }
	

	void Update () {
        // get the boundary of the sprite
        Bounds colliderBounds = myCollider.bounds;

        // get the sprite position
        Vector3 leftSide = transform.position;
        Vector3 rightSide = transform.position;
        Vector3 topSide = transform.position;
        Vector3 bottomSide = transform.position;
        // substract the x extends to have the left side
        // extends is half the size of bounds
        leftSide.x = leftSide.x - colliderBounds.extents.x;
        rightSide.x = rightSide.x + colliderBounds.extents.x;
        topSide.x = topSide.x + colliderBounds.extents.y;
        bottomSide.x = bottomSide.x - colliderBounds.extents.y;

        Debug.Log("love" + transform.position.x);

        // test if the left is not before the screen bound
        // on prend les coordonnées calculées (left), on les projette sur l'écran via la caméra
        // et on vérifie que ça ne sort pas de l'écran
        if (Camera.main.WorldToScreenPoint(leftSide).x < 0)
        {
            Vector3 backPos = Camera.main.ScreenToWorldPoint(Vector3.zero);
            backPos.x = backPos.x + colliderBounds.extents.x;
            backPos.y = transform.position.y;
            backPos.z = transform.position.z;
            
            transform.position = backPos;

            Debug.Log("Left of the screen");
        }
        else if (Camera.main.WorldToScreenPoint(rightSide).x > Screen.width)
        {
            Debug.Log("Right of the screen");
        }

        if (Camera.main.WorldToScreenPoint(bottomSide).y < 0)
        {
            Debug.Log("bottom of the screen");
        }
        else if (Camera.main.WorldToScreenPoint(topSide).y > Screen.height)
        {
            Debug.Log("up of the screen");
        }

    }
}
