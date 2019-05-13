using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource aS;
    public AudioClip BeetleWingsOpening, BeetleWingsClosing, BeetleRammingWall, BeetleProjectileBlock, AntGrab, MiteExplosion, MitePuddle, MiteSpawn, BugHop;

    void Start()
    {
        aS = GetComponent<AudioSource>();
    }

    void Update()
    {
    }
    public void OpenWings()
    {
        aS.PlayOneShot(BeetleWingsOpening);
    }
    public void CloseWings()
    {
        aS.PlayOneShot(BeetleWingsClosing);
    }
    public void WallRam()
    {
        aS.PlayOneShot(BeetleRammingWall);
    }
    public void ShieldBlock()
    {
        aS.PlayOneShot(BeetleProjectileBlock);
    }
    public void Grab()
    {
        aS.PlayOneShot(AntGrab);
    }
    public void DieSatansMinion()
    {
        aS.PlayOneShot(MiteExplosion);
    }
    public void MiteBirth()
    {
        aS.PlayOneShot(MiteSpawn);
    }
    public void PuddleDrop()
    {
        aS.PlayOneShot(MitePuddle);
    }
    public void Hop()
    {
        aS.PlayOneShot(BugHop);
    }
}