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
    public Animator energyEmpty;
    public float coolDownDuration = 1.5f;

    public GameObject energyUI;


    private SfxManager sfxManager;

    
    void Start()
    {
        sfxManager = FindObjectOfType<SfxManager>();

        energyBarFillAmount = 1f;
        energyBar.fillAmount = energyBarFillAmount;
    }

    void Update()
    {
        if (transform.localPosition.y < 8f)
        {
            //Debug.Log("vacuum pos");
            Vector3 newPos = transform.localPosition;
            newPos.y = 8f;
            transform.localPosition = newPos;
        }

        HandleEnergyBar();
    }

    private void HandleEnergyBar()
    {
        energyBar.fillAmount = energyBarFillAmount;

        //sfxManager.jetAudioFilter.cutoffFrequency = Mathf.Lerp(300f, 15000f, energyBarFillAmount);

        WindForce windLauncher = WindForceObj.GetComponent<WindForce>();
        if (Mathf.Abs(energyBarFillAmount - 1) < 0.05f)
        {
            energyUI.SetActive(false);
        }
        else
        {
            energyUI.SetActive(true);
        }
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
                energyBarFillAmount -= 0.001f * windLauncher.accelerator * windLauncher.accelerator;
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
            energyEmpty.SetTrigger("Flashing");
            yield return new WaitForSeconds(duration);
            WindForce windLauncher = WindForceObj.GetComponent<WindForce>();
            windLauncher.isCoolDown = false;
        }
    }

}
