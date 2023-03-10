using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InteractorComponent : MonoBehaviour
{
    [SerializeField]
    private float interactSpeed;
    [SerializeField]
    private float playerWidth;
    [SerializeField]
    private float playerHeight;
    private PlayerActions playerActions;
    private float interactDistance => interactSpeed * Time.deltaTime;
    private void Awake()
    {
        playerActions = new PlayerActions();
        playerActions.PlayerInput.Enable();
    }

    private void Update()
    {
        if(playerActions.PlayerInput.InteractPrimary.WasPressedThisFrame())
        {  
            TryInteract();
        }
    }

    private void TryInteract()
    {
        var hits = Physics.CapsuleCastAll(transform.position, transform.position + Vector3.up * playerHeight, playerWidth, transform.forward, interactDistance);
        
        if (hits.Length < 1) return;


        foreach(var hit in hits)
        {
            var interactable = hit.transform.GetComponent<InteractableComponentBase>();

            if (interactable == null) continue;

            interactable.Interact();
        }
    }

}
