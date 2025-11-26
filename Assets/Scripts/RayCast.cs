using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class RayCast : MonoBehaviour
{
    private InputAction _clickAction;
    private InputAction _positionAction;
    private Vector2 _mousePosition;

    public Text _canvasCounter;
    private int counter = 1;
    private int updatedNumber = 5;
    private int updatedNumber1 = 5;
    private int updatedNumber2 = 5;
    private Canvas canvas;

    void Awake()
    {
        _clickAction = InputSystem.actions["Attack"];
        _positionAction = InputSystem.actions["RayPos"];
    }

    void Start()
    {
        updatedNumber.ToString();
    }

    void Update()
    {
        _mousePosition = _positionAction.ReadValue<Vector2>();

        if(_clickAction.WasPerformedThisFrame())
        {
            StopAllCoroutines();
            updatedNumber = 6;
            updatedNumber1 = 6;
            updatedNumber2 = 6;
            RayCastShoot();
        }       

        if(updatedNumber <= 0)
            {
                SceneManager.LoadScene("Scene1");
            } 

        if(updatedNumber1 <= 0)
            {
                SceneManager.LoadScene("Scene2");
            } 

        if(updatedNumber2 <= 0)
            {
                SceneManager.LoadScene("Scene3");
            } 

    }

    void RayCastShoot()
    {
        Ray ray = Camera.main.ScreenPointToRay(_mousePosition);

        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if(hit.transform.gameObject.layer == 6)
            {
                StartCoroutine(StartCounter());
                Debug.Log("Has tocado el Cubo 1");
                
            }

            if(hit.transform.gameObject.layer == 7)
            {
                StartCoroutine(StartCounter1());
                Debug.Log("Has tocado el Cubo 2");
            }

            if(hit.transform.gameObject.layer == 8)
            {
                StartCoroutine(StartCounter2());
                Debug.Log("Has tocado la esfera");
            }
        }
    }

    private IEnumerator StartCounter()
    {
        yield return new WaitForSeconds(counter);
        updatedNumber --;
        //updatedNumber.ToString();
        _canvasCounter.text = updatedNumber.ToString();
        StartCoroutine(StartCounter());
        
        
    }


    private IEnumerator StartCounter1()
    {
        yield return new WaitForSeconds(counter);
        updatedNumber1 --;
        //updatedNumber.ToString();
        _canvasCounter.text = updatedNumber1.ToString();
        StartCoroutine(StartCounter1());
        
        
    }


    private IEnumerator StartCounter2()
    {
        yield return new WaitForSeconds(counter);
        updatedNumber2 --;
        //updatedNumber.ToString();
        _canvasCounter.text = updatedNumber2.ToString();
        StartCoroutine(StartCounter2());
        
        
    }

    
}
