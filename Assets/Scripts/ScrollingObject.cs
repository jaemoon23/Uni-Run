using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    public float speed = 10f;

    private GameManager gm;

    private void Start()
    {
        gm = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
    }

    private void Update()
    {
        if (gm.IsGameOver)
        {
            return;
        }
        transform.Translate(Vector3.left *  speed * Time.deltaTime);
    }
}
