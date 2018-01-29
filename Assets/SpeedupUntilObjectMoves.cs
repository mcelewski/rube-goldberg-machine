using UnityEngine;

public class SpeedupUntilObjectMoves : MonoBehaviour
{
    [Tooltip("Fizyka zwolni jak dany gameobject ruszy się o taką odległość")]
    [Range(0f, 1f)]
    public float distanceThreshold = 0.1f;
    Vector3 startPosition;

    void Awake()
    {
        startPosition = transform.position;
        SpeedUp();
    }

    void Update()
    {
        if (HasMoved())
            SlowDown();
    }

    private void SpeedUp()
    {
        Time.timeScale = 8;
        Debug.Log("Setting timescale to 8 until " + gameObject.name + " will move \n", this);
    }

    private void SlowDown()
    {
        Time.timeScale = 3;
        Debug.Log(gameObject.name + " moved more than " + distanceThreshold + "m\n", this);
        enabled = false;
    }

    private bool HasMoved()
    {
        return Vector3.Distance(transform.position, startPosition) > distanceThreshold;
    }
}