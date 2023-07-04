using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRay : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private List<GameObject> _buttonFloor;
    private ElevatorButton _elevatorButtonScript;
    void Update()
    {
        RaycastHit hit;
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            Transform objectHit = hit.transform;
            if (objectHit.gameObject.GetComponent<ElevatorButton>())
            {
                _elevatorButtonScript = objectHit.gameObject.GetComponent<ElevatorButton>();
                DeselectAllButtonPrompts();
                _buttonFloor[_elevatorButtonScript.callFloor].SetActive(true);
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    _elevatorButtonScript.CallToFloor();
                }
            }
            else
            {
                DeselectAllButtonPrompts();
            }
        }
    }
    void DeselectAllButtonPrompts()
    {
        for (int i = 0; i < _buttonFloor.Count; i++) //update visual panels displaying on which floor elevator currently is
        {
            _buttonFloor[i].SetActive(false);
        }
    }
}
