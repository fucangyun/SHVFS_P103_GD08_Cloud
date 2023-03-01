using UnityEngine;

[CreateAssetMenu(fileName = "IngredientConfiguration_Base", menuName = "UnderCooked/IngredientConfiguration")]

 public class IngredientConfiguration:ScriptableObject
{
    public IngredientComponent Ingredient;
    public Vector3 scale;
    public float scaleFactor;
    public string TestText;
}
