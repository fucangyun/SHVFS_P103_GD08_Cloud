using Unity.VisualScripting;
using UnityEngine;

public partial class IngredientSpawnerComponent:InteractableComponentBase
{
    //public bool IsOnDesk = false;
    //public bool IsOnHand = false;
    //public GameObject Food;
    //public Transform SpawnPosition;
    //public Transform handposition; 
    //public GameObject Foodspawn;

    public override void Interact()
    {



        /*if (IsOnDesk == false && IsOnHand == false)
        {
            Foodspawn = Instantiate(Food, SpawnPosition.transform);
            IsOnDesk = true;
        }
        else if (IsOnDesk == false && IsOnHand == true)
        {
            Foodspawn.transform.SetParent(SpawnPosition);
            IsOnDesk = true;
            IsOnHand = false;
        }
        else if (IsOnDesk == true && IsOnHand == false)
        {
            Foodspawn.transform.SetParent(handposition);
            IsOnDesk = false;
            IsOnHand = true;
        }*/


    }
}
