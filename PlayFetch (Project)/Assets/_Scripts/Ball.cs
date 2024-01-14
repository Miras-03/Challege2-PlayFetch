using System;
using UnityEngine;

public sealed class Ball : MonoBehaviour
{
    private Action<Ball> OnRelease;
    private const int downBound = -3;

    public void Init(Action<Ball> OnRelease) => this.OnRelease = OnRelease;

    private void FixedUpdate() => CheckOrDestroy();

    private void CheckOrDestroy()
    {
        Vector3 currentPos = transform.position;
        if (currentPos.y < downBound)
        {
            OnRelease(this);
            TerminateGame();
        }
    }

    private void TerminateGame()
    {
        Debug.Log("GameOver");
        Time.timeScale = 0;
    }
}