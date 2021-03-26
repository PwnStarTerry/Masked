using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Item[] inventory;
    public int index;

    void Update() {
        if(Input.GetKeyDown(KeyCode.Q)) {
            DropItem();
        }

        if(Input.GetAxisRaw("Mouse ScrollWheel") > 0) {
            index++;
            if(index > inventory.Length - 1) index = 0;
        } else if(Input.GetAxisRaw("Mouse ScrollWheel") < 0) {
            index--;
            if(index < 0) index = inventory.Length - 1;
        }
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.gameObject.layer == 7 /* Layer 7 is the designated Item Layer */) {
            Debug.Log("Works");
            Item item = collider.gameObject.GetComponent<PhysicalItem>().scriptableObjectRepresentation;
            InsertItem(item, collider.gameObject);
        }
    }

    void InsertItem(Item item, GameObject itemObject) {
        for(int i = 0; i < inventory.Length; i++) {
            // if slot is occupied continue to next iteration
            if(inventory[i] != null) continue;
            inventory[i] = item;
            Destroy(itemObject);
            break;
        }
    }

    void DropItem() {
            if(inventory[index] == null) return;

            GameObject item = inventory[index].physicalRepresentation;
            Vector3 position = new Vector3(transform.position.x + 1, transform.position.y, 0);
            inventory[index] = null;
            Instantiate(item, position, Quaternion.identity);
    }
}
