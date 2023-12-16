using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ButtonFall : MonoBehaviour
{
    public void Fall()
    {
        // Aktivuje gravitáciu, keď je metóda zavolaná.
        GetComponent<Rigidbody>().useGravity = true;
        // Ak chcete tlačidlo uvoľniť, aby sa mohlo pohybovať, musíte vypnúť aj kinematiku, ak je zapnutá.
        GetComponent<Rigidbody>().isKinematic = false;
    }
}
