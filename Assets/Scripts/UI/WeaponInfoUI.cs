using UnityEngine;
using UnityEngine.UI;

public class WeaponInfoUI : MonoBehaviour
{
    public static WeaponInfoUI Instance { get; private set; }

    public Text WeaponName;
    public Text WeaponClip;
    public Text AmmoTypeCount;
    
    void OnEnable()
    {
        Instance = this;
    }

    public void UpdateWeaponName(string name)
    {
        WeaponName.text = name;
    }

    public void UpdateClipInfo(string clip)
    {
        WeaponClip.text = clip;
    }

    public void UpdateAmmoAmount(int amount)
    {
        AmmoTypeCount.text = amount.ToString();
    }
}
