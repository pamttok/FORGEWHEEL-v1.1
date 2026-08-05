using UnityEngine;

public class FinishRotate : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(0, 1, 0, Space.World);
    }
}