using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSize : MonoBehaviour {

    private void OnDrawGizmos() {
        Gizmos.DrawWireCube(transform.position, transform.localScale);
    }

}
