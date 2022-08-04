using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarnLogic : MonoBehaviour
{
   private IEarnable earner;
   private LearningLogic learningLogic;
   
   public void Init(IEarnable _earner)
   {
      earner = _earner;
      learningLogic = LearningLogic.GetInstace();
   }

   public void Earn()
   {
      learningLogic.PointEarned();
      earner.Earn();
   }
}
