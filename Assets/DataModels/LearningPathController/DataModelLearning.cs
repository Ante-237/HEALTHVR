
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "TutorialKeys", menuName = "Tutorials/TutorialKeys")]
public class DataModelLearning : ScriptableObject
{

    public int[] TimesPressed = new int[4] { 0, 0, 0, 0};

    public int[] TimePickedController = new int[4] { 0,0, 0, 0};


}
