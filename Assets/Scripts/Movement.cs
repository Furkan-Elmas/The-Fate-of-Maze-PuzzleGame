using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody characterRigidbody;
    [SerializeField] private GameObject maleCharacter, femaleCharacter;
    public float CharacterSpeed = 1000;

    private float _horizontal, _vertical;

    private void Start()
    {
        characterRigidbody = GetComponent<Rigidbody>();

    }
    private void FixedUpdate()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");


        characterRigidbody.velocity = (transform.forward * _vertical + transform.right * _horizontal) * Time.deltaTime * CharacterSpeed;

    }
    /*public void ReverseMovement()
    {
        maleCharacter.transform.Rotate(new Vector3(0,45,0));
        femaleCharacter.transform.Rotate(new Vector3(0,-45,0));
    }*/
}
