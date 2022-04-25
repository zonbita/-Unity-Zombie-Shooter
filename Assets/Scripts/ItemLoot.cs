using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLoot : IPickUp
{
    public enum Type {Medkit, Armor, C4, Ammo1, Ammo2, Ammo3, Ammo4, Ammo5};
    
    [System.Serializable]
    public struct ItemModify{
        
        [SerializeField] public Type type;
        [SerializeField] public string name;
        [SerializeField] public int value;
        [SerializeField] public GameObject model;
        [SerializeField] public Sprite Image;
    }
    public ItemModify item;
    // Debug Type
    // private void Awake() {
    //      Debug.Log(item.type.ToString());
    // }
    protected override void OnPicked()
    {
        EventManager.TriggerEvent("addCoins", 2);
        PlayPickupFeedback();
        Destroy(gameObject);
    }
}
