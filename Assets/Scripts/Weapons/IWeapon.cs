using System.Collections.Generic;
using UnityEngine;

public interface IWeapon {

    void PerformAttack(Vector2 attackDirection, Quaternion attackRotation);
    void OnHit(Collider2D collision);

}
