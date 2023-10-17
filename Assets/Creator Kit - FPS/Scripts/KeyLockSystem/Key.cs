﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour
{

    public string keyAppearSound;
    public string keyPickUpSound;
    public string keyType;
    public Text KeyNameText;

    void OnEnable()
    {
        KeyNameText.text = keyType;
        FMODUnity.RuntimeManager.PlayOneShot(keyAppearSound, GetComponent<Transform>().position);
    }

    void OnTriggerEnter(Collider other)
    {
        var keychain = other.GetComponent<Keychain>();

        if (keychain != null)
        {
            keychain.GrabbedKey(keyType);
            FMODUnity.RuntimeManager.PlayOneShot(keyPickUpSound, GetComponent<Transform>().position);
            Destroy(gameObject);
        }
    }
}
