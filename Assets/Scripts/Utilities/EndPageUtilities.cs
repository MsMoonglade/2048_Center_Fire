using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPageUtilities : MonoBehaviour
{
    public void Reset()
    {
        GameManager.instance.DeleteAllSave();
    }
}
