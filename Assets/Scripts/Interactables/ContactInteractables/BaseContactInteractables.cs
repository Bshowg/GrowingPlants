﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseContactInteractables : BaseInteractable{

    private void OnTriggerEnter2D(Collider2D collision){
        GameObject go = collision.gameObject;
        interact(go);
    }


}
