using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Dummy : MonoBehaviour
{
    [SerializeField]
private TMP_Text DPSText;
    public float dpsUpdateTime = 1f; // Time interval to update DPS
    private float totalDamage = 0f;
    private float lastUpdateTime;

    void Start()
    {
        lastUpdateTime = Time.time;
        if (DPSText != null)
            DPSText.text = "DPS: 0";
        StartCoroutine(UpdateDPS());
    }

    public void TakeDamage(float damage)
    {
        totalDamage += damage;
    }

    private IEnumerator UpdateDPS()
    {
        while (true)
        {
            yield return new WaitForSeconds(dpsUpdateTime);
            float dps = totalDamage / dpsUpdateTime;
            totalDamage = 0; // Reset damage counter after each update
            
            if (DPSText != null)
                DPSText.text = "DPS: " + dps.ToString("F2");
        }
    }
}
