using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorMenu : MonoBehaviour
{
    // Start is called before the first frame update
    Info info;

    void Start()
    {
        info = Info.Instance;
    }

    public void Zolty()
    {
        info.pierwszyGracz = "MASZYNA";
        info.drugiGracz = "CZLOWIEK";
        info.czyCzlowiek1 = false;
        info.czyCzlowiek2 = true;
    }

    public void Czerwony()
    {
        info.pierwszyGracz = "CZLOWIEK";
        info.drugiGracz = "MASZYNA";
        info.czyCzlowiek1 = true;
        info.czyCzlowiek2 = false;
    }
}
