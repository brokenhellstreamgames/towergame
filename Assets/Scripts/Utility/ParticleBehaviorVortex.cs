using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleBehaviorVortex : MonoBehaviour
{
    [SerializeField] ParticleSystem generatorParticle = default;
    [SerializeField] int originalTimer = default;

    int timer;
    int currentRotationSpeed;
    bool isCharging;
    // Start is called before the first frame update
    void Start()
    {
        timer = originalTimer;
        StartCoroutine(OverCharge());
    }

    private IEnumerator OverCharge()
    {
        currentRotationSpeed = 1;
        //isFiring = false;
        isCharging = true;
        generatorParticle.Play();
        while (isCharging)
        {
            if (timer > 0)
            {
                var vel = generatorParticle.velocityOverLifetime;
                vel.orbitalYMultiplier = currentRotationSpeed;

                timer -= 1;
                if (currentRotationSpeed < originalTimer * 2)
                {
                    currentRotationSpeed += 2;
                }
                yield return new WaitForSeconds(1f);
            }
            else
            {
                isCharging = false;

            }
        }
    }
}
