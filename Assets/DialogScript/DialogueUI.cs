using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class DialogUI : MonoBehaviour
{
    [SerializeField] private TMP_Text textLable;

    private void Start()
    {
        GetComponent<TypewriterEffect>().Run("This is a bit of text!\n Hello.", textLable);
    }
}
