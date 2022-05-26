using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TiltFive;

public class WindForce : MonoBehaviour
{
    public GameObject myWand;

    public Vector3 forceDir;

    public float maxWindForce = 10f;

    public float windForce;

    public float updraftForce = 0.04f;

    public float maxDistance = 10f;

    public LineRenderer line;

    public Vector3 actualForce = Vector3.zero;

    public ParticleSystem windParticle;

    public float windStartSpeed = 50f;

    public bool isRunning = false;

    public bool isCoolDown = false;

    public float accelerator = 0;

    public Light light;

    private SfxManager sfxManager;

    Vector3 vacumAng;

    void Start()
    {
        line = GetComponent<LineRenderer>();

        sfxManager = FindObjectOfType<SfxManager>();
    }

    void Update()
    {
        InputHandle();
        //RayVisualize();
    }

    void RayVisualize()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.down);

        if (Physics.Raycast(transform.position, fwd, out hit, 10))
        {
            print("There is something in front of the object!");
        }
        Vector3[] poses = new Vector3[] {transform.parent.position, transform.parent.position + fwd * maxDistance };
        line.SetPositions(poses);

    }

    void InputHandle()
    {
        vacumAng = transform.rotation.eulerAngles;
        Vector3 vacumDir = transform.TransformDirection(Vector3.down);

        if (!isCoolDown)
        {
            accelerator = TiltFive.Input.GetTrigger(ControllerIndex.Primary);
            //Debug.Log("accelerator" + accelerator + "time: " + Time.time);
        }
        else
        {
            accelerator = 0;
        }
        if (accelerator < 0.1f)
        {
            accelerator = 0f;
            isRunning = false;
            light.intensity = 0;
            windParticle.Stop();

            sfxManager.StopJetSound();
        }
        else
        {
            isRunning = true;
            windParticle.startColor = Color.grey * windForce / maxWindForce;
            windParticle.startSpeed = windStartSpeed * windForce / maxWindForce;
            light.intensity = 100;
            windParticle.Play();

            sfxManager.PlayJetSound();
        }
        windForce = accelerator * maxWindForce;
        forceDir = vacumDir;
    }

    private void OnDrawGizmos()
    {
        //Gizmos.color = Color.red;
        //Vector3 direction = transform.TransformDirection(Vector3.forward) * 5;
        //Gizmos.DrawRay(transform.position, direction);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals("WindAffectable") || other.tag.Equals("Leaf"))
        {
            var distance = (other.transform.position - transform.parent.position).magnitude;
            //Physics.gravity = Vector3.down * 5;

            actualForce = forceDir * windForce;
            if (distance > 1 && distance <= maxDistance)
            {
                actualForce *= (maxDistance - distance) / maxDistance;
            }
            else if (distance > maxDistance)
            {
                actualForce *= 0;
            }

            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (other.tag.Equals("Leaf"))
            {
                rb.AddForce(actualForce, ForceMode.Impulse);
                Vector3 updraftDir = Vector3.up * accelerator * updraftForce;
                updraftDir = Quaternion.AngleAxis(Random.Range(-20f, 20f), Vector3.forward) * updraftDir;
                updraftDir = Quaternion.AngleAxis(Random.Range(-20f, 20f), Vector3.right) * updraftDir;
                rb.AddForce(updraftDir, ForceMode.Impulse);
                if (accelerator > 0.1f)
                {
                    rb.GetComponent<LeafBounce>().isBlown = true;
                }
            }
            else
            {
                Vector3 pushForward = actualForce;
                pushForward.y = 0f;
                rb.AddForce(pushForward, ForceMode.Impulse);
            }
        }
    }

}
