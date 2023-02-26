using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

//bug1: 

public class MovementComponet : MonoBehaviour
{
    [SerializeField]
    private InputComponentBase InputComponent;
    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private float rotateSpeed;
    [SerializeField]
    private float playerWidth;
    [SerializeField]
    private float playerHeight;
    //[SerializeField]
    //private float stepHeight;
    private float movementDistance => movementSpeed * Time.deltaTime;


    // Update is called once per frame
    void Update()
    {
        if (!(InputComponent.GetInputDirectionNormalized().magnitude > 0f)) return;
        var movementDirection = new Vector3(InputComponent.GetInputDirectionNormalized().x, 0f, InputComponent.GetInputDirectionNormalized().y);
        var movementDirectionX = new Vector3(movementDirection.x, 0f, 0f).normalized;
        var movementDirectionZ = new Vector3(0f, 0f, movementDirection.z).normalized;

        var targetLookRotation = Vector3.Slerp(transform.forward, movementDirection, Time.deltaTime * rotateSpeed);
        transform.rotation = Quaternion.LookRotation(targetLookRotation, Vector3.up);

        if (TryMove(movementDirection)) return;
        if (TryMove(movementDirectionX)) return;
        if (TryMove(movementDirectionZ)) return;
    }

    private bool TryMove(Vector3 direction)
    {
        var hits = Physics.CapsuleCastAll(transform.position, transform.position + Vector3.up * playerHeight, playerWidth, direction, movementDistance);
 
        if (hits.Length >= 1)
        {
            if (!hits.All(hit => hit.transform.GetComponent<StructureComponent>() == null)) return false;
        }

        Move(direction);
        return true;
    }

    private void Move(Vector3 direction)
    {
        var targetPosition = transform.position + movementSpeed * direction * Time.deltaTime;
        transform.position = targetPosition;
    }
}
