using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalsTrans : MonoBehaviour
{
    public Material MalePortalMaterial;

    private Color _portalColor;

    // Update is called once per frame
    void Start()
    {
        MalePortalMaterial.color = _portalColor;
        InvokeRepeating("MakeTransparentMaterial", 0, 0.1f);
    }
    public void MakeTransparentMaterial()
    {
        _portalColor.a -= 0.01f;
        MalePortalMaterial.color = _portalColor;
        if (_portalColor.a == 0)
        {
            InvokeRepeating("MakeSolidMaterial", 0, 0.1f);
        }
    }
    public void MakeSolidMaterial()
    {
        _portalColor.a += 0.01f;
        MalePortalMaterial.color = _portalColor;
        if (_portalColor.a == 100)
        {
            InvokeRepeating("MakeTransparentMaterial", 0, 0.01f);
        }
    }
}
