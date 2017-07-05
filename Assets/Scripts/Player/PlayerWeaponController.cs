using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerWeaponController : MonoBehaviour {
    public GameObject mainWeaponSlot;
    public GameObject EquippedWeaponObj { get; set; }
    public Item EquippedWeaponItem { get; set; }
    
    private Player player;
    private bool canAttack = true;

    private void OnEnable() {
        PlayerHealth.OnPlayerDeath += (() => canAttack = false);
    }

    private void Start() {
        player = GetComponent<Player>();
    }

    public void EquipWeapon(Item weaponToEquip) {
        if (EquippedWeaponObj != null) {
            Destroy(mainWeaponSlot.transform.GetChild(0).gameObject);
            EquippedWeaponItem = null;
        }
        EquippedWeaponItem = weaponToEquip;
        EquippedWeaponObj = Instantiate(Resources.Load<GameObject>("Weapons/" + weaponToEquip.ObjectSlug),
            mainWeaponSlot.transform.position, Quaternion.identity);
        EquippedWeaponObj.transform.SetParent(mainWeaponSlot.transform);
        EquippedWeaponObj.name = weaponToEquip.ItemName;
    }

    public void MainAttack() {
        if (canAttack) {
            Vector2 attackDirection = GetAttackDirection();
            Quaternion attackRotation = GetAttackRotation(attackDirection);

            // finding weapon by IWeapon, only works with a single weapon equipped.
            GetComponentInChildren<IWeapon>().PerformAttack(attackDirection, attackRotation);
        }
    }

    Vector2 GetAttackDirection() {
        Vector2 mousePositionInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 playerPosition = new Vector2(transform.position.x, transform.position.y);
        Vector2 attackDirection = (mousePositionInWorld - playerPosition).normalized;
        return attackDirection;
    }

    Quaternion GetAttackRotation(Vector2 attackDirection) {
        float attackRotationZ = Mathf.Atan2(attackDirection.y, attackDirection.x) * Mathf.Rad2Deg;
        Quaternion attackRotation = Quaternion.Euler(new Vector3(0, 0, attackRotationZ - 90));
        return attackRotation;
    }
    
}
