using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipment : MonoBehaviour
{
   

    [SerializeField]
    private GameObject _match;

    [SerializeField]
    private GameObject _jerryCan;

    [SerializeField]
    private GameObject _fireWork;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SwitchEquipment();
       
    }

    private void SwitchEquipment()
    {
       if (Input.GetButtonDown("Hotbar 1"))
        {
           
            _match.SetActive(true);
            _jerryCan.SetActive(false);
            _fireWork.SetActive(false);
        }
        if (Input.GetButtonDown("Hotbar 2"))
        {
          
            _match.SetActive(false);
            _jerryCan.SetActive(true);
            _fireWork.SetActive(false);
        }
    
        if (Input.GetButtonDown("Hotbar 3"))
        {
           
         _match.SetActive(false);
            _jerryCan.SetActive(false);
            _fireWork.SetActive(true);
        }
        
    }

    
}
