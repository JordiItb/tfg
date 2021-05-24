using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{   
    [TextArea]
    public string tutorial;

    public string GetText(){
        return tutorial;
    }

}
