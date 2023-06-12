using UnityEngine;
using UnityEngine.UI;


namespace aptXR.MasterMenu
{
    [CreateAssetMenu(fileName = "MasterModel", menuName = "MasterMenu/MasterModel")]
    public class MasterModel: ScriptableObject
    {
    
        [Header("Lock Decision")]
        public bool[] Unlocked = new bool[7];
    }
}