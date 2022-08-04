using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILearnable
{
    void UpdateSkills(bool learned, int cost);
}
