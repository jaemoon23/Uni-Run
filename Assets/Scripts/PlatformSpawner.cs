using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameManager gameManager;

    public GameObject prefab;
    private GameObject[] platforms;

    public int poolSize = 10;
    private int currentIndex;

    public float yMin = -1f;
    public float yMax = 1f;

    public float intervalMin = 1.5f;
    public float intervalMax = 2f;

    public float interval = 1f;
    public float timer = 0f;

    private List<GameObject> pool = new List<GameObject>();


    private void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject gameObject = Instantiate(prefab);
            gameObject.SetActive(false);
            pool.Add(gameObject);
        }
        //Respawn();
    }

    private void Update()
    {
        if (gameManager.IsGameOver)
        {
            return;
        }
        timer += Time.deltaTime;
        if (timer > interval)
        {
            timer = 0;
            var newPos = transform.position;
            newPos.y = Random.Range(yMin, yMax);

            pool[currentIndex].transform.position = newPos;
            pool[currentIndex].SetActive(true);
            currentIndex = (currentIndex + 1) % pool.Count;
            interval = Random.Range(intervalMin, intervalMax);
        }
    }

}
