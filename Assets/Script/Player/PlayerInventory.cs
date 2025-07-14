using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public bool hasKey = false;

    public void Obtain()
    {
        hasKey = true;
        Debug.Log("¿­¼è È¹µæ");
    }

    public void Use()
    {
        hasKey = false;
        Debug.Log("¿­¼è »ç¿ë");
    }

    public bool HasKey()
    {
        return hasKey;
    }
}
