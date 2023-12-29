using System.Collections;
using UnityEngine;

public sealed class PlayerController : MonoBehaviour
{
    [SerializeField] Transform dogPrefab;

    private bool canInstantiate = true;

    private void Update() => CheckOrInstantiate();

    private void CheckOrInstantiate()
    {
        if (Input.GetKeyUp(KeyCode.Space) && canInstantiate)
        {
            canInstantiate = false; 
            StartCoroutine(WaitForDelayAndInstantiate(0.5f));
        }
    }

    private IEnumerator WaitForDelayAndInstantiate(float second)
    {
        Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        yield return new WaitForSeconds(second);
        canInstantiate = true;
    }
}