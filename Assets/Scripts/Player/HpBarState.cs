using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class HpBarState : MonoBehaviour
{
    [SerializeField] Transform hpFill;
    
    
    public void SetState(int current, int max)
    {
        float state = ((float)current) / max;
        if(state < 0f) state = 0f;
        hpFill.localScale = new Vector3(state, 1f, 1f);
    }
}
