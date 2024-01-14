using System;
using UnityEngine;

public sealed class Dog : MonoBehaviour
{
    private Action<Dog> OnRelease;
    private const int leftBound = -50;

    public void Init(Action<Dog> OnRelease) => this.OnRelease = OnRelease;

    private void FixedUpdate() => CheckOrDestroy();

    private void CheckOrDestroy()
    {
        Vector3 currentPos = transform.position;
        if (currentPos.x < leftBound)
            OnRelease(this);
    }
}