using UnityEngine;

public class ItemData : MonoBehaviour
{
    public string id;
    public string displayName;
    [TextArea] public string description;

    public Sprite icon;

    public int maxStack = 99;
}
