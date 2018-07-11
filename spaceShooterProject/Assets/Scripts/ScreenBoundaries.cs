using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBoundaries : MonoBehaviour {

    BoxCollider2D myCollider;

	void Start () {
        // get the component
        myCollider = GetComponent<BoxCollider2D>();
        if(myCollider == null) // if not create one with default values
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
        // substract the x extends to have the left side
        // extends is half the size of bounds
        leftSide.x -= colliderBounds.extents.x;
        rightSide.x += colliderBounds.extents.x;

        Debug.Log("leftSide" + leftSide);
        Debug.Log("rightSide" + rightSide);

        // test if the left is not before the screen bound
        // on prend les coordonnées calculées (left), on les projette sur l'écran via la caméra
        // et on vérifie que ça ne sort pas de l'écran
        if (Camera.main.WorldToScreenPoint(leftSide).x < 0)
        {

        }
        else if (Camera.main.WorldToScreenPoint(rightSide).x > Screen.width)
        {
            Debug.Log(Screen.width);
        }

    }
}
