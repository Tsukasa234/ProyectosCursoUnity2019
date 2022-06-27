using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyManager : MonoBehaviour
{
    public int maxEnergy;
    private int currentEnergy;
    private Animator _anim;

    public float rechargeEneryTime;
    private float rechargeEnergyTimeCounter;

    public int CurrentEnergy
    {
        get
        {
            return currentEnergy;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        UpdateMaxEnergy(maxEnergy);
        _anim = GetComponent<Animator>();
        rechargeEnergyTimeCounter = rechargeEneryTime;
    }

    private void Update()
    {
        rechargeEnergyTimeCounter -= Time.deltaTime;
        if (currentEnergy <= 0)
        {
            _anim.SetBool("LowEnergy", true);
        }
        else if (rechargeEnergyTimeCounter <= 0)
        {
            rechargeEnergyTimeCounter = rechargeEneryTime;
            currentEnergy = maxEnergy;
            if (currentEnergy > 0)
            {
                _anim.SetBool("LowEnergy", false);
            }
        }
    }

    public void LowEnergy (int Useenergy)
    {
        currentEnergy -= Useenergy;
    }

    public void UpdateMaxEnergy(int newMaxEnergy)
    {
        maxEnergy = newMaxEnergy;
        currentEnergy = maxEnergy;
    }
}
