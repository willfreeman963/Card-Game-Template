using UnityEngine;

public class OrcScript : MonoBehaviour
{
    public float delayTime = 10f;
    private float initialTime = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initialTime = 1000f;
    }

    // Update is called once per frame
    void Update()
    {
        initialTime -= 0.1f;

        if (initialTime <= 0f)
        {
            Destroy(gameObject);
            print("timer");
            initialTime = 1000f;
        }
    }

    
}
