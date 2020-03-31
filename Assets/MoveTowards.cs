using UnityEngine;
public class MoveTowards : MonoBehaviour
{

    [SerializeField] private Vector3 target = new Vector3(1, 1, 1);
    [SerializeField] private float speed = 1;
    private void Update()
    {
        // Moves the object to target position
        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
    }
}