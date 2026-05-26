using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private float speed = 20f;
    private float turnSpeed = 45f;
    private float horizontalInput;
    private float verticalInput;

    [SerializeField] InputActionAsset inputActions;
    private InputAction MoveAction;

    private Vector3 WhereWas;
    public float VehVelocity = 0.0f;

    void Awake()
    {
        MoveAction = inputActions.FindAction("Move");
    }

    void Update()
    {
        Vector2 MoveInput = MoveAction.ReadValue<Vector2>();
        horizontalInput = MoveInput.x;
        verticalInput = MoveInput.y;
        //calcula
        VehVelocity = ((transform.position - WhereWas).magnitude)/Time.deltaTime;
        //atualiza pos pro prox calc de velocidade
        WhereWas = transform.position;

        if (verticalInput > 0)
        {
            // Move o ve�culo para frente a partir do Input vertical
            transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        }
        // Rotaciona o carro a partir do Input horizontal
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);
    }
}
