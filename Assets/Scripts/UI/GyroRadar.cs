using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GyroRadar : MonoBehaviour
{
    public int distRadar;
    public int radarSpeed;
    public float radarLineSpeed;
    public LayerMask mask;
    public Transform Player;
    public Transform lineaRadar;
    public Transform camara;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Player.transform.position;
        transform.Rotate(0, radarSpeed * Time.deltaTime, 0);
        lineaRadar.Rotate(0, 0, -radarSpeed * radarLineSpeed * Time.deltaTime);
        camara.position = new Vector3(Player.position.x, camara.position.y, Player.position.z);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, distRadar, mask))
        {
            hit.collider.GetComponentInChildren<DetectaRadar>().activo = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * distRadar);

    }
}