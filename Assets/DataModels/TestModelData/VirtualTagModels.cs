using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="VirtualTag", menuName = "DataModel/VirtualTag")]
public class VirtualTagModels : ScriptableObject
{
   public List<string> Tags = new List<string>();   
}
