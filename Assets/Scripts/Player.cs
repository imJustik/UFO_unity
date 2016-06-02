using UnityEngine;
using System.Collections;

public class Player{

    //die by asteroid
    private bool die;

    //sit on the planet
    private bool sit;

    public bool Die
    {
        set
        {
            die = value;
        }

        get
        {
            return die;
        }
    }

    public bool Sit
    {
        set
        {
            sit = value;
        }

        get
        {
            return sit;
        }
    }
}
