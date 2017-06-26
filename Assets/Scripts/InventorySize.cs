using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySize : MonoBehaviour {

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, transform.localScale);
    }

}
