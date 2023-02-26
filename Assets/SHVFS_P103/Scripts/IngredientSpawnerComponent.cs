using Unity.VisualScripting;
using UnityEngine;

public class IngredientSpawnerComponent:InteractableComponentBase
{
    public override void Interact()
    {
        Debug.Log("Food Spawn!");
    }
}
