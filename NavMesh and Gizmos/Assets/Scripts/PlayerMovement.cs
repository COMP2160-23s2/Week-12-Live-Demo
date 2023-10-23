using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private PlayerActions playerActions;
    private InputAction movePosition;
    private InputAction moveClick;

    private Vector3 moveCoordinate;
    private LayerMask layerMask;

    void Awake()
    {
        playerActions = new PlayerActions();
        movePosition = playerActions.Movement.MovePosition;
        moveClick = playerActions.Movement.MoveClick;
    }

    void OnEnable()
    {
        movePosition.Enable();
        moveClick.Enable();
    }

    void Start()
    {
        moveClick.performed += MoveTo;
    }

    void Update()
    {
        GetMovePosition();
    }

    void GetMovePosition()
    {
        Vector2 position = movePosition.ReadValue<Vector2>();
        Ray ray = Camera.main.ScreenPointToRay(position);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            moveCoordinate = hit.point;
        }
    }

    void MoveTo(InputAction.CallbackContext context)
    {
        // Movement code goes here
    }
}
