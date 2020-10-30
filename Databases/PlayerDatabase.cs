using System;
using System.Collections;
using System.Collections.Generic;
using D2D.Database;
using UnityEngine;

public static class PlayerDatabase
{
    public static IntegerContainer MoneyContainer { get; }  = new IntegerContainer("Money", 0);
}
