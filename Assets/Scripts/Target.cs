using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private GameManager gameManager;
    private float speedMin = 13;
    private float speedMax = 17;
    private float rTorq = 10f;
    private float rPosX = 4f;
    private float rPosY = -2f;
    public int valuePoint;
    public ParticleSystem explosionParticle;

    // Start is called before the first frame update
    void Start()
    {
        targetRb = gameObject.GetComponent<Rigidbody>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomPosition();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    Vector3 RandomForce(){ return Vector3.up * Random.Range(speedMin, speedMax); }
    Vector3 RandomPosition() { return new Vector3(Random.Range(-rPosX, rPosX), rPosY); }
    float RandomTorque() { return Random.Range(-rTorq, rTorq); }

    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            gameManager.UpdateScore(valuePoint);
            Instantiate(explosionParticle, transform.position,
            transform.rotation);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
        Destroy(gameObject);
    }
}
