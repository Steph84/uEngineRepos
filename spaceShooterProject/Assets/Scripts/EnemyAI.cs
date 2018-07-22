using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    private float elpasedTime;
    private float changingTime;
    private int rangeRandom;
    private int deviderRandom;
    public Rigidbody2D SpriteRigidBody;
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

        myRandX = GetRandomVelocity(rangeRandom, deviderRandom);
        myRandY = GetRandomVelocity(rangeRandom, deviderRandom);

        SpriteRigidBody.velocity = new Vector2(myRandX, myRandY);

    }

    // Update is called once per frame
    void Update()
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

    // method to have random velocity
    private float GetRandomVelocity(int range, int devider)
    {
        Random.InitState((int)System.DateTime.Now.Ticks);
        float myRand = 0;
        while (myRand == 0)
        {
            myRand = (float)Random.Range(-range, range) / devider;
        }
        return myRand * Time.deltaTime * 60;
    }
}
