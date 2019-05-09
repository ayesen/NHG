using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScript : MonoBehaviour
{
    public static InventoryScript me;
    public Image silverKey;
    public Image goldenKey;
    public Image redFuse;
    public Image blueFuse;

    public void Awake()
    {
        if (me != null)//check me
        {
            Destroy(gameObject);
            return;
        }
        me = this;
    }
}
