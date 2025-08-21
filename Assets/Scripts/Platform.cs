using System.Diagnostics;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float x = -20f;
    public GameObject[] obstacles;

    private bool stepped = false;

    private GameManager gm;

    private void OnEnable()
    {
        stepped = false;

        foreach (var obstacle in obstacles)
        {
            obstacle.SetActive(Random.value < 0.3);
        }
    }

    private void Start()
    {
        gm = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
    }

    private void Update()
    {
        if (transform.position.x < x)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!stepped && collision.collider.CompareTag("Player"))
        {
            stepped = true;
            gm.AddScore(10);
        }
    }
}
