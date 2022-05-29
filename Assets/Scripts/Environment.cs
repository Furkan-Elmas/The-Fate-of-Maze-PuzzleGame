using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Environment : MonoBehaviour
{
    [SerializeField] private GameObject maleCharacter, femaleCharacter, gold, maleArrivalPoint, femaleArrivalPoint, maleStartPoint, femaleStartPoint;
    [SerializeField] private Text counterText;
    [SerializeField] private ParticleSystem TpPartical;
    [SerializeField] private List<Transform> portalList = new List<Transform>();

    private Movement _maleMovement, _femaleMovement;
    private CameraTracking _maleOffsetBuff, _femaleOffsetBuff;

    private void Start()
    {
        _maleMovement = GameObject.Find("MaleCharacter").GetComponent<Movement>();
        _femaleMovement = GameObject.Find("FemaleCharacter").GetComponent<Movement>();

        _maleOffsetBuff = GameObject.Find("MaleCharacter").GetComponent<CameraTracking>();
        _femaleOffsetBuff = GameObject.Find("FemaleCharacter").GetComponent<CameraTracking>();

    }

    public void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
           _maleMovement.ReverseMovement();
           _femaleMovement.ReverseMovement();
        }*/


    }

    //Portal Collision
    private void OnTriggerEnter(Collider other)
    {

        //Special Teleportation Buff
        if (gameObject.name == "MaleCharacter" && other.gameObject.CompareTag("BlueSpecialTpBuff"))
        {


            StartCoroutine(BlueBackwardTeleportationBuff());

        }
        if (gameObject.name == "FemaleCharacter" && other.gameObject.CompareTag("PinkSpecialTpBuff"))
        {


            StartCoroutine(PinkBackwardTeleportationBuff());
        }
        if (other.CompareTag("MaleWall"))
        {
            if (gameObject.name == "MaleCharacter")
            {
                StartCoroutine(MalePenalty());
            }
            else if (gameObject.name == "FemaleCharacter")
            {
                StartCoroutine(FemalePenalty());
            }
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        //SpeedBuff
        if (collision.gameObject.CompareTag("BlueSpeedBuff"))
        {
            Destroy(collision.gameObject);

            StartCoroutine(BlueBackwardSpeedBuff());
        }

        //Offset Buff
        if (collision.gameObject.CompareTag("BlueOffsetBuff"))
        {
            Destroy(collision.gameObject);

            StartCoroutine(BlueBackwardOffsetBuff());
        }

        //Ice Buff
        if (collision.gameObject.CompareTag("BlueIceBuff"))
        {
            Destroy(collision.gameObject);

            StartCoroutine(BlueBackwardIceBuff());
        }
        //SpeedBuff
        if (collision.gameObject.CompareTag("PinkSpeedBuff"))
        {
            Destroy(collision.gameObject);

            StartCoroutine(PinkBackwardSpeedBuff());
        }

        //Offset Buff
        if (collision.gameObject.CompareTag("PinkOffsetBuff"))
        {
            Destroy(collision.gameObject);

            StartCoroutine(PinkBackwardOffsetBuff());
        }

        //Ice Buff
        if (collision.gameObject.CompareTag("PinkIceBuff"))
        {
            Destroy(collision.gameObject);

            StartCoroutine(PinkBackwardIceBuff());
        }


    }
    //******************************************************************************

    // Male
    IEnumerator BlueBackwardSpeedBuff()
    {
        _maleMovement.CharacterSpeed = _maleMovement.CharacterSpeed * 1.5f;
        _femaleMovement.CharacterSpeed = _femaleMovement.CharacterSpeed * 0.2f;

        yield return new WaitForSeconds(3f);
        _maleMovement.CharacterSpeed = _maleMovement.CharacterSpeed / 1.5f;
        _femaleMovement.CharacterSpeed = _femaleMovement.CharacterSpeed / 0.2f;
    }
    IEnumerator BlueBackwardOffsetBuff()
    {
        _maleOffsetBuff.offset *= 1.8f;
        _femaleOffsetBuff.offset *= 0.2f;

        yield return new WaitForSeconds(10f);

        _maleOffsetBuff.offset /= 1.8f;
        _femaleOffsetBuff.offset /= 0.2f;
    }
    IEnumerator BlueBackwardIceBuff()
    {
        maleCharacter.GetComponent<BoxCollider>().isTrigger = true;
        _femaleMovement.CharacterSpeed = _femaleMovement.CharacterSpeed * 0;


        yield return new WaitForSeconds(3f);


        maleCharacter.GetComponent<BoxCollider>().isTrigger = false;
        _femaleMovement.CharacterSpeed = 1000f;
    }
    IEnumerator BlueBackwardTeleportationBuff()
    {
        _maleMovement.CharacterSpeed *= 0f;
        TpPartical.Play();

        yield return new WaitForSeconds(3f);

        _maleMovement.CharacterSpeed = 1000f;
        gameObject.transform.position = maleArrivalPoint.transform.position;
        TpPartical.Stop();
    }
    IEnumerator MalePenalty()
    {
        yield return new WaitForSeconds(1);
        maleCharacter.transform.position = maleStartPoint.transform.position;

    }

    //******************************************************************************

    // Female

    IEnumerator PinkBackwardSpeedBuff()
    {
        _maleMovement.CharacterSpeed = _maleMovement.CharacterSpeed * 0.2f;
        _femaleMovement.CharacterSpeed = _femaleMovement.CharacterSpeed * 1.5f;

        yield return new WaitForSeconds(3f);
        _maleMovement.CharacterSpeed = _maleMovement.CharacterSpeed / 0.2f;
        _femaleMovement.CharacterSpeed = _femaleMovement.CharacterSpeed / 1.5f;
    }
    IEnumerator PinkBackwardOffsetBuff()
    {
        _maleOffsetBuff.offset *= 0.2f;
        _femaleOffsetBuff.offset *= 1.8f;

        yield return new WaitForSeconds(10f);

        _maleOffsetBuff.offset /= 0.2f;
        _femaleOffsetBuff.offset /= 1.8f;
    }
    IEnumerator PinkBackwardIceBuff()
    {
        femaleCharacter.GetComponent<BoxCollider>().isTrigger = true;
        _maleMovement.CharacterSpeed = _maleMovement.CharacterSpeed * 0;


        yield return new WaitForSeconds(3f);


        femaleCharacter.GetComponent<BoxCollider>().isTrigger = false;
        _maleMovement.CharacterSpeed = 1000f;
    }
    IEnumerator PinkBackwardTeleportationBuff()
    {
        _femaleMovement.CharacterSpeed *= 0f;
        TpPartical.Play();

        yield return new WaitForSeconds(3f);

        _femaleMovement.CharacterSpeed = 1000f;
        gameObject.transform.position = femaleArrivalPoint.transform.position;
        TpPartical.Stop();
    }
    IEnumerator FemalePenalty()
    {
        yield return new WaitForSeconds(1);
        femaleCharacter.transform.position = femaleStartPoint.transform.position;
    }

}
