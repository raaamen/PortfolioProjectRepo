using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public List<Image> keyImages;
    

    public void GreyKeys(){
        Debug.Log("Keys greyed");
        foreach (var item in keyImages)
        {
            var tempcolor = item.color;
            tempcolor.a = 0.5f;
            item.color = tempcolor;
        }
    }
    public void UngreyKeys(){
        foreach (var item in keyImages)
        {
            var tempcolor = item.color;
            tempcolor.a = 1f;
            item.color = tempcolor;
        }
    }
}
