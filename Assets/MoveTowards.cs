using UnityEngine;
public class MoveTowards : MonoBehaviour
{

    [SerializeField] private Vector3 target = new Vector3(-7, 1, 1);
    [SerializeField] private float speed = 1;
    public Transform Target;
    public float RotationSpeed;
    private Quaternion _lookRotation;
    private Vector3 _direction;
    private void Update()
    {
        
        // Moves the object to target position
        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
        _direction = (Target.position - transform.position).normalized;
        _lookRotation = Quaternion.LookRotation(_direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * RotationSpeed);
    }
}