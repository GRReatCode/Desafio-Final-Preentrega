namespace ArionDigital
{
    using UnityEngine;

    public class Shooter : MonoBehaviour
    {
        //---------------------- PROPIEDADES SERIALIZADAS ----------------------

        [SerializeField] GameObject bullet1;         
        [SerializeField] GameObject bullet2;

        //--------------- Spawners de balas tank
        [SerializeField] Transform spawnPointD;      // Derecho
        [SerializeField] Transform spawnPointI;      // Izquierdo

        //--------------- Física de disparo
        [SerializeField] float shootForce = 1500;   // La Fuerza disparo
        [SerializeField] float shootRate = 0.5f;    // La velocidad de repetición de disparo

        //--------------- Reproducción de sonido
        [SerializeField] AudioSource shootAudio;    // El sonido que hará al disparar
        [SerializeField] AudioClip SonidoDisparo;

        public bool estoyAtacando;
        public bool retrocedo;
        public float impulsoDisparo = 10f;


        //---------------------- PROPIEDADES PRIVADAS ----------------------

        private float shootRateTime = 0;
        private Rigidbody rb;
        private Animation anim;

        private void Start()
        {
            rb = this.GetComponent<Rigidbody>();
            //anim = this.GetComponentInChildren<Animation>().;
        }

        private void FixedUpdate()
        {

            if (!estoyAtacando)
            {

            }
            if (retrocedo)
            {
                rb.velocity = transform.forward*-impulsoDisparo;

            }
        }
        private void Update()
        {
            if (Input.GetMouseButtonUp(0))
            {

                if (Time.time > shootRateTime)
                {
                    //anim.SetTrigger("Disparando");
                    GameObject newBullet;
                    shootAudio.Play();
                    //---------- Balas del brazo derecho
                    newBullet = Instantiate(bullet1, spawnPointD.position, spawnPointD.rotation);
                    newBullet.GetComponent<Rigidbody>().AddForce(spawnPointD.forward * shootForce);
                    //---------- Balas del brazo izquierdo
                    newBullet = Instantiate(bullet2, spawnPointI.position, spawnPointI.rotation);
                    newBullet.GetComponent<Rigidbody>().AddForce(spawnPointI.forward * shootForce);

                    shootRateTime = Time.time + shootRate;

                    Destroy(newBullet, 3f);
                }
            }
        }
    }
}