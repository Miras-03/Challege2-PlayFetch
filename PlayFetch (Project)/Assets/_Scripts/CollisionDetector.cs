using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    private void OnCollisionEnter() => Destroy(gameObject);
}
