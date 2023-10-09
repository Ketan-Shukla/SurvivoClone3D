﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public abstract class Collectable : MonoBehaviour
{
    protected CollectableController collectableController;
    internal CollectableType collectableType;

    public delegate void PickedUpEvent(CollectableType type, GameObject gameObject);
    public event PickedUpEvent onPickedUp;

    public void Setup(CollectableController collectableController)
    {
        this.collectableController = collectableController;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            onPickedUp?.Invoke(collectableType, gameObject);
            GetComponent<Collider>().enabled = false;
            CollectableController.getInstance().unSubscribeCollectable(this);
            Destroy(gameObject);
        }

    }
}

public enum CollectableType
{
    NONE,
    STAR,
    HEALTH,
    HAZARD,
    HAM,
    INGOT,
    JEWEL,
    INVENTORY,
}
