  using UnityEngine;

public class levelboundry : MonoBehaviour
{
    public static float leftside = -3.5f;
    public static float rightside = 3.5f;  
    public  float internalLeft;
    public  float internalRight;
    

    void Update()
    {
        internalLeft = leftside;
        internalRight = rightside;     
    }

}
