using UnityEngine;

public class DoorUnlock : MonoBehaviour
{
    public bool openOnTrigger = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerInventory inventory = other.GetComponent<PlayerInventory>();

            if(inventory != null && inventory.HasKey())
            {
                inventory.Use();

                Debug.Log("개방");
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("열쇠 부족");
            }
        }
    }
}
