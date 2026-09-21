using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnchorWithoutPassword : MonoBehaviour
{
    public UnityEvent withpassword, withoutpassword;
    public static bool login = false;
    private void Start()
    {
        login = false;
    }
    public void LoginSuccess(bool value)
    {
        login = value;
    }

    public void NeedPasswordPanel()
    {
        if (login)
        {
            withoutpassword.Invoke();

        }
        else
        {
            withpassword.Invoke();
        }
    }
}
