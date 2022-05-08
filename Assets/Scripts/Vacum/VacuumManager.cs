using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VacuumManager : MonoBehaviour
{
    [Header("EnergyBar")]
    public Image energyBar;
    public float energyBarFillAmount = 0f;
    public GameObject WindForceObj;
    public float coolDownDuration = 1.5f;
    
    void Start()
    {
        energyBarFillAmount = 1f;
        energyBar.fillAmount = energyBarFillAmount;
    }

    void Update()
    {
        HandleHeathBar();
    }

    private void HandleHeathBar()
    {
        energyBar.fillAmount = energyBarFillAmount;
        WindForce windLauncher = WindForceObj.GetComponent<WindForce>();
        if (windLauncher.isRunning)
        {
            if (energyBarFillAmount <= 0)
            {
                windLauncher.isCoolDown = true;
                windLauncher.isRunning = false;
                StartCoroutine(CoolDown(coolDownDuration));
            }
            else
            {
                energyBarFillAmount -= 0.005f * windLauncher.accelerator * windLauncher.accelerator;
            }
        }
        else
        {
            if (energyBarFillAmount < 1)
            {
                
                if (windLauncher.isCoolDown)
                {
                    energyBarFillAmount += 0.00f;
                }
                else
                {
                    energyBarFillAmount += 0.01f;
                }
            }
        }

        IEnumerator CoolDown(float duration)
        {
            yield return new WaitForSeconds(duration);
            WindForce windLauncher = WindForceObj.GetComponent<WindForce>();
            windLauncher.isCoolDown = false;
        }
    }

}
