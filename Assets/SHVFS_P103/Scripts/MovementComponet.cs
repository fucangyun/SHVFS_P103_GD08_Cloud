using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovementComponet : MonoBehaviour
{
    [SerializeField]
    private InputComponentBase InputComponent;
    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private float playerWidth;
    [SerializeField]
    private float playerHeight;
    private float movementDistance => movementSpeed * Time.deltaTime;
    void Update()
    {
        if (!(InputComponent.GetInputDirectionNormalized().magnitude > 0f)) return;
        var movementDirection = new Vector3(InputComponent.GetInputDirectionNormalized().x, 0f, InputComponent.GetInputDirectionNormalized().y);
        var targetLookRotation = Vector3.Slerp(transform.forward, movementDirection, Time.deltaTime * rotationSpeed);
        transform.rotation = Quaternion.LookRotation(targetLookRotation, Vector3.up);
        if (CanMove(movementDirection)) return;

        if (CanMove(new Vector3(movementDirection.x, 0f, 0f).normalized)) return;

        CanMove(new Vector3(0f, 0f, movementDirection.z).normalized);

    }
    private bool CanMove(Vector3 direction)
    {
        var hits = Physics.CapsuleCastAll(transform.position, transform.position + Vector3.up * playerHeight, playerWidth, direction, movementDistance);
        if (hits.Length >= 1)
        {
            if (hits.All(hit => hit.transform.GetComponent<StructureComponent>() == null))
            {
                Move(direction);
                return true;
            }
            else return false;
        }


        Move(direction);
        return true;
    }
    private void Move(Vector3 direction)
    {
        var targetPosition = transform.position + movementSpeed * direction * Time.deltaTime;
        transform.position = targetPosition;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, playerWidth);
        Gizmos.DrawWireSphere(transform.position + Vector3.up * playerHeight, playerWidth);
    }
}
