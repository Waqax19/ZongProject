using System.Collections;
using System.Collections.Generic;
using UnityEditor.TextCore.Text;
using UnityEngine;

public class ObjectPickUp : MonoBehaviour
{
    private float pickUpRange = 550;

    private GameObject heldObject;

    public Transform holdParent;

    public GameObject boxes;

    public GameObject buttons;
    public FirstPersonController locking;

    public float moveForce;


    [Header("Weapons, Points , Instrument")]
    public GameObject weapons, points, instrument;

    [Header("Images")]
    public GameObject images;

    [Header("Canvas")]
    public GameObject canvas;

    [Header("Player Got It")]
    public GameObject playerGotIt;
    public GameObject sphere;

    public Sprite icon;


    

    private void Start()
    {
        boxes.SetActive(true);
        canvas.SetActive(true);
        images.SetActive(false);
        playerGotIt.SetActive(false);

        weapons.SetActive(false);
        points.SetActive(false);
        instrument.SetActive(false);

        locking.lockCursor = false;

       
       
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (heldObject == null)
            {
                RaycastHit hit;

                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange))
                {
                    pickUpObject(hit.transform.gameObject);
                    //whenClickButton();
                    //canvas.SetActive(true);

                    weapons.SetActive(true);
                    points.SetActive(true);
                    instrument.SetActive(true);

                    images.SetActive(false);

                }
            }

            else
            {
                DropObject();
            }
        }

        if(heldObject != null)
        {
            MoveObject();
        }

    }

    void pickUpObject(GameObject pickObj)
    {
        if (pickObj.GetComponent<Rigidbody>())
        {
            Rigidbody objRig = pickObj.GetComponent<Rigidbody>();
            objRig.useGravity = false;
            objRig.drag = 10;

            objRig.transform.parent = holdParent;
            heldObject = pickObj;


        }
    }

    void MoveObject()
    {
        if(Vector3.Distance(heldObject.transform.position , holdParent.position) > 0.1f)
        {
            Vector3 moveDirection = (holdParent.position - heldObject.transform.position);
            heldObject.GetComponent<Rigidbody>().AddForce(moveDirection  *  moveForce);
        }
    }

    public void DropObject()
    {
        Rigidbody heldRigid = heldObject.GetComponent<Rigidbody>();
        heldRigid.useGravity = true;
        heldRigid.drag = 1;

        heldRigid.transform.parent = holdParent;
        heldObject = null;

    }


    public void whenClickWeaponButton()
    {
        locking.lockCursor = true;
        if (buttons.activeInHierarchy == true)
        {
            buttons.SetActive(false);
        }

        else
        {
            buttons.SetActive(true);
            images.SetActive(true);
        }
    }


    public void whenClickOnPointButton()
    {
        images.SetActive(false);

    }

    public void whenClickedOnInstrumentButton()
    {
        playerGotIt.SetActive(true);
        images.SetActive(false);
        sphere.SetActive(true);
        buttons.SetActive(false);
        weapons.SetActive(false);
        points.SetActive(false);
        instrument.SetActive(false);
        
    }
   
}
