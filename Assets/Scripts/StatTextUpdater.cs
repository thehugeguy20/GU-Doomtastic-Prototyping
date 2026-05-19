using System;
using System.Collections.Generic;
using Sirenix.Utilities;
using TMPro;
using Unity.Collections;
using UnityEngine;

public class StatTextUpdater : MonoBehaviour
{
    public TextMeshProUGUI damageOrItemEffect;
    public TextMeshProUGUI elementDamage;
    //public TextMeshProUGUI effectDamage;
    public TextMeshProUGUI knockback;
    public TextMeshProUGUI attackRange;
    public TextMeshProUGUI knockbackStrength;

    public List<TextMeshProUGUI> textList;

    public void Start()
    {
        textList.Add(damageOrItemEffect);
        textList.Add(elementDamage);
        textList.Add(knockback);
        textList.Add(attackRange);
        textList.Add(knockback);
    }


    public void UpdateText(Slot slot)
    {
        if (slot.pairedItem.damage.isEnabled)
        {
            damageOrItemEffect.text = $"Damage: {slot.pairedItem.damage.value}";
        }
        else
        {
            BumpUpText(1);
        }
        
        if (slot.pairedItem.prefix != null || slot.pairedItem.prefix.affixName != null || slot.pairedItem.prefix.affixName.Length > 0 || slot.pairedItem.prefix.amount.value == 0)
        {
            elementDamage.text = $"{slot.pairedItem.prefix.affixName} Damage: {slot.pairedItem.prefix.amount.value}";
        }
        else
        {
            BumpUpText(2);
        }

        if (slot.pairedItem.damage.isEnabled)
        {
            knockback.text = $"Knockback: {slot.pairedItem.knockbackStrength.value}";
        }
        else
        {
            BumpUpText(3);
        }

        if (slot.pairedItem.damage.isEnabled)
        {
            attackRange.text = $"Attack Range: {slot.pairedItem.attackRange.value}";
        }

        // if (slot.pairedItem.suffix != null)
        // {
        //     effectDamage.text = $"{slot.pairedItem.suffix.affixName} + Damage: {slot.pairedItem.suffix.amount}";
        // }
    }

    void BumpUpText(int startIndex)
    {
        for (int i = startIndex; i < textList.Count; i++)
        {
            textList[i].transform.position = new Vector3
            (
                textList[i].transform.position.x,
                textList[i].transform.position.y - 55,
                textList[i].transform.position.z
            );
        }
    }
}
