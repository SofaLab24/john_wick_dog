using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformationFinisher : MonoBehaviour
{
    public StateController stateController;

    public void OnEnable()
    {
        stateController.FinishTransformation();
    }
}
