using UnityEngine;

public sealed class OutOfBoundDestroy : MonoBehaviour
{
    private const int leftBound = -50;
    private const int downBound = -3;

    private void FixedUpdate() => CheckOrDestroy();

    private void CheckOrDestroy()
    {
        Vector3 currentPos = transform.position;
        if (currentPos.x < leftBound)
            Destroy(gameObject);
        else if (currentPos.y < downBound)
        {
            Destroy(gameObject);
            TerminateGame();
        }
    }

    private void TerminateGame()
    {
        Debug.Log("GameOver");
        Time.timeScale = 0;
    }
}