
using UnityEngine;

public class VirtualTag : MonoBehaviour
{
    [Header("VirtualTag Model")]
    [Tooltip("The virtual Tag Model for the Present Scene should be Assigned to this reference")]
    public VirtualTagModels tags;

    [SerializeField]
    [Tooltip("The Index of the Tag in the Virtual Tag Model should be Assigned here to Access it")]
    [Header("Index of Tag")]
    private int TagPosition;


    private string _tag = "virtualTag";
    
    private void Awake()
    {
        SetTag(TagPosition);
    }


    void SetTag(int _position)
    {
        if(tags != null)
        {
            try
            {
                _tag = tags.Tags[_position];
            }catch(System.IndexOutOfRangeException) 
            {
                Debug.LogWarning("The Index Passed is out of Range, Check the VirtualTag Model Tag");
                
            }
            
        }
    }

    public string GetTag()
    {
        if(tags != null)
        {
            return _tag;
        }
        return "virtualTag";
    }

    public void printTag()
    {
        if(_tag != null)
        {
            Debug.Log("The Tag for this Object is : "+ _tag);
        }
    }
   
}
