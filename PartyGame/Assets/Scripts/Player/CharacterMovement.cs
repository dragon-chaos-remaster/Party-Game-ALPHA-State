using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] float playerSpeed = 15f, jumpForce = 400f;
    CharacterController characterController;

    [SerializeField] float turnSmoothTime = 0.15f;
    [SerializeField] bool apenasNaHorizontal, apenasNaVertical;

    float turnSmoothVelocity;
    //Input input;
    //[SerializeField] Transform cam;
    Vector3 playerMovement;

    Vector3 direcaoDeMovimento;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    //void CheckMovementConditions(float xAxis,float zAxis)
    //{
    //    if (apenasNaHorizontal && !apenasNaVertical)
    //    {
    //        zAxis = 0f;
    //        direcaoDeMovimento = new Vector3(xAxis, 0f, zAxis).normalized;
    //    }
    //    else if (apenasNaVertical && !apenasNaHorizontal)
    //    {
    //        xAxis = 0f;
    //        direcaoDeMovimento = new Vector3(xAxis, 0f, zAxis).normalized;
    //    }
    //}
   
    void Update()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float zAxis = Input.GetAxis("Vertical");
     
        if (apenasNaHorizontal && !apenasNaVertical)
        {
            //zAxis = 0f;
            direcaoDeMovimento = new Vector3(xAxis, 0f, 0).normalized;
        }
        else if (apenasNaVertical && !apenasNaHorizontal)
        {
            //xAxis = 0f;
            direcaoDeMovimento = new Vector3(0f, 0f, zAxis).normalized;
        }
        else
        {
            direcaoDeMovimento = new Vector3(xAxis, 0f, zAxis).normalized;
        }

        if (direcaoDeMovimento.magnitude >= 0.1f)
        {
            float anguloDeVisao = Mathf.Atan2(direcaoDeMovimento.x, direcaoDeMovimento.z) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
            float anguloDeRotacao = Mathf.SmoothDampAngle(transform.eulerAngles.y, anguloDeVisao, ref turnSmoothVelocity, turnSmoothTime);

            transform.rotation = Quaternion.Euler(0f, anguloDeRotacao, 0f);

            playerMovement = Quaternion.Euler(0f, anguloDeVisao, 0f) * Vector3.forward;
            characterController.Move(playerMovement.normalized * playerSpeed * Time.deltaTime);
        }
    }
}
