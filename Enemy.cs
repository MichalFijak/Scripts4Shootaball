using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody enemyRb;
    private GameManager gameManager; // W celu pozniejej aktualizacji wynikow, 
    public ParticleSystem particleSystem;
    public float enemySpeed;
    private float enemyRangeSpeed=15;
    private int waveNumber;
    private float colorRange0 = 0;
    private float colorRange255 = 1;

    public int pointValue;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Renderer>().material.color = new Color(Random.Range(colorRange0, colorRange255), Random.Range(colorRange0, colorRange255), Random.Range(colorRange0, colorRange255));
        enemyRb = GetComponent<Rigidbody>();

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        waveNumber = gameManager.waveNumber;
        
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();
    }

    private void EnemyMove()
    {
        
        if (waveNumber > 3)
        {
            enemySpeed = Random.Range(-enemyRangeSpeed, enemyRangeSpeed);
            enemyRb.AddForce(Vector3.right * enemySpeed*Time.deltaTime,ForceMode.Impulse);
        }
        enemyRb.AddForce(Vector3.up * 2 * Time.deltaTime, ForceMode.Force);
    }

    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            ParticleSystem killEffect = Instantiate(particleSystem) as ParticleSystem;
            killEffect.transform.position = transform.position;

            killEffect.loop = false;
            killEffect.Play();
            Destroy(killEffect.gameObject, killEffect.duration);
            Destroy(gameObject);
            gameManager.UpdateScore(pointValue);
        }
    }
}
