using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip planetHitSound, meteorHitSound, fireSound, planetGrowSound, astronautWeaponSound;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        meteorHitSound = Resources.Load<AudioClip>("MeteoriteDestroy");
        planetHitSound = Resources.Load<AudioClip>("PlayerHit");
        fireSound = Resources.Load<AudioClip>("LaserSound");
        planetGrowSound = Resources.Load<AudioClip>("Positive Sound");
        astronautWeaponSound = Resources.Load<AudioClip>("AstronautWeaponSound");
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void PlaySound(string clip)
    {


        switch (clip)
        {
            case "MeteoriteDestroy":

                audioSrc.PlayOneShot(meteorHitSound);
                break;
            case "PlayerHit":

                audioSrc.PlayOneShot(planetHitSound);
                break;
            case "LaserSound":

                audioSrc.PlayOneShot(fireSound);
                break;
            case "Positive Sound":

                audioSrc.PlayOneShot(planetGrowSound);
                break;
            case "AstronautWeaponSound":

                audioSrc.PlayOneShot(astronautWeaponSound);
                break;
        }
    }
}
