using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerWeaponController : MonoBehaviour {
    public GameObject mainWeaponSlot;
    public GameObject EquippedWeapon { get; set; }

    private Camera myCamera;
    private Player player;

    private void Start() {
        player = GetComponent<Player>();
    }

    public void EquipWeapon(Item weaponToEquip) {
        if (EquippedWeapon != null) {
            Destroy(mainWeaponSlot.transform.GetChild(0).gameObject);
        }
        EquippedWeapon = Instantiate(Resources.Load<GameObject>("Weapons/" + weaponToEquip.ObjectSlug),
            mainWeaponSlot.transform.position, Quaternion.identity);
        EquippedWeapon.transform.SetParent(mainWeaponSlot.transform);
    }

    public void MainAttack() {
        if (!player.IsDead) {
            Vector2 attackDirection = GetAttackDirection();
            Quaternion attackRotation = GetAttackRotation(attackDirection);

            // finding weapon by IWeapon, only works with a single weapon equipped.
            GetComponentInChildren<IWeapon>().PerformAttack(attackDirection, attackRotation);
        }
    }

    Vector2 GetAttackDirection() {
        Vector2 mousePositionInWorld = myCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 playerPosition = new Vector2(transform.position.x, transform.position.y);
        Vector2 attackDirection = (mousePositionInWorld - playerPosition).normalized;
        return attackDirection;
    }

    Quaternion GetAttackRotation(Vector2 attackDirection) {
        float attackRotationZ = Mathf.Atan2(attackDirection.y, attackDirection.x) * Mathf.Rad2Deg;
        Quaternion attackRotation = Quaternion.Euler(new Vector3(0, 0, attackRotationZ - 90));
        return attackRotation;
    }

    private void OnEnable() {
        SceneManager.sceneLoaded += FindObjects;
    }

    private void OnDisable() {
        SceneManager.sceneLoaded -= FindObjects;
    }

    void FindObjects(Scene scene, LoadSceneMode mode) {
        myCamera = FindObjectOfType<Camera>();
    }
}
