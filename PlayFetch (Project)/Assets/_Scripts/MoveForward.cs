using UnityEngine;

public sealed class MoveForward : MonoBehaviour
{
    private const int moveSpeed = 30;

    private void FixedUpdate() => transform.Translate(Vector3.forward * Time.fixedDeltaTime * moveSpeed);
}