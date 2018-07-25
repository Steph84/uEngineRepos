using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    private float elpasedTime;
    private float changingTime;
    private int rangeRandom;
    private int deviderRandom;
    private Vector3 heroPosition;
    private Vector3 heroPositionVP;
    private Vector3 enemyPositionVP;
    private bool isHunting;
    public Rigidbody2D SpriteRigidBody;

    // the hero in public
    // then drag and drop in the inspector
    public GameObject theHero;


    float myRandX = 0;
    float myRandY = 0;


    // Use this for initialization
    void Start()
    {
        SpriteRigidBody = GetComponent<Rigidbody2D>();
        elpasedTime = 0;
        changingTime = 2;
        rangeRandom = 10;
        deviderRandom = 1;
        isHunting = true;

        myRandX = GetRandomVelocity(rangeRandom, deviderRandom);
        myRandY = GetRandomVelocity(rangeRandom, deviderRandom);

        SpriteRigidBody.velocity = new Vector2(myRandX, myRandY);

    }

    // Update is called once per frame
    void Update()
    {
        heroPositionVP = theHero.transform.position;
        enemyPositionVP = Camera.main.WorldToViewportPoint(transform.position);
        var heading = heroPositionVP - enemyPositionVP;
        var distance = heading.magnitude;

        if(distance < 0.5)
        {
            isHunting = true;
        }
        else
        {
            isHunting = false;
        }

        if (isHunting)
        {
            var direction = heading / distance;

            // go to the hero
        }
        else
        {
            elpasedTime = elpasedTime + Time.deltaTime;

            if (elpasedTime > changingTime)
            {
                myRandX = GetRandomVelocity(rangeRandom, deviderRandom);
                myRandY = GetRandomVelocity(rangeRandom, deviderRandom);
                elpasedTime = 0;
            }

            SpriteRigidBody.velocity = new Vector2(myRandX, myRandY);
        }
        SpriteRigidBody.velocity = Vector2.zero;

    }

    // method to have random velocity
    private float GetRandomVelocity(int range, int devider)
    {
        Random.InitState((int)System.DateTime.Now.Ticks);
        float myRand = 0;
        while (myRand == 0)
        {
            myRand = (float)Random.Range(-range, range) / devider;
        }
        return myRand * Time.deltaTime * 30;
    }
}
