//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class RangedWeapon : MonoBehaviour
//{

//    public Transform Projectile;
//    public float SHootingForce = 0;
//    public float range;
//    public float fireRate;



//    bool IsShooting = false;
//    Transform newProjectile = null;
//    Rigidbody rb;
//    ProjectileScript ps;


//    // Start is called before the first frame update
//    void Start()
//    {
//        Projectile.gameObject.SetActive(false);

//        rb = Projectile.GetComponent<Rigidbody>();
//        if (!rb)
//        {
//            Projectile.gameObject.AddComponent<Rigidbody>();
//        }

//    }



//    Vector3 bulletSTartPos = Vector3.zero;
//    Vector3 bulletEndPos = Vector3.zero;

//    // Update is called once per frame
//    void Update()
//    {

//        if (Input.GetMouseButtonDown(0))
//        {
//            IsShooting = true;
//        }
//        if (Input.GetMouseButtonUp(0))
//        {
//            IsShooting = false;
//        }

//        if (IsShooting)
//        {
//            newProjectile = GameObject.Instantiate(Projectile);
//            newProjectile.gameObject.SetActive(true);
//            newProjectile.position = this.transform.position;
//            newProjectile.rotation = this.transform.rotation;

//            IsShooting = false;

//            ps = newProjectile.GetComponent<ProjectileScript>();
//            if (ps)
//            {
//                ps.range = range;
//            }

//            rb = newProjectile.GetComponent<Rigidbody>();
//            // newProjectile.rotation = this.transform.rotation;
//        }

//    }


//    private void FixedUpdate()
//    {
//        if (rb)
//        {
//            rb.AddForce(newProjectile.transform.forward * SHootingForce, ForceMode.Impulse);
//            rb = null;
//        }
//    }
//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : MonoBehaviour
{
    public Transform Muzzle;
    public Transform Projectile;
    public float SHootingForce = 0;
    public float range;

    public int MagazineMaxSize = 30;
    public int MagazineCount = 0;
    public int totalProjectilesNumber = 300;
    public float reloadTime;

    public float fireRate;

    Transform newProjectile = null;
    Rigidbody rb;
    ProjectileScript ps;
    Coroutine ShootingRotine = null;
    Coroutine ReloadingRotine = null;

    // Start is called before the first frame update
    void Start()
    {
        Projectile.gameObject.SetActive(false);

        rb = Projectile.GetComponent<Rigidbody>();
        if (!rb)
        {
            Projectile.gameObject.AddComponent<Rigidbody>();
        }

        MagazineCount = MagazineMaxSize;
    }

    IEnumerator ShootBullets()
    {
        while (true)
        {
            if (MagazineCount > 0 && ReloadingRotine == null)
            {
                CreateBullet();
                ShootCurrentProjectile();
                MagazineCount--;
                yield return new WaitForSeconds(fireRate);
            }
            else
            {
                if (ReloadingRotine == null)
                {
                    ReloadingRotine = StartCoroutine(Reload());
                }
                else
                {
                    yield return true;
                }
            }
        }
    }

    private IEnumerator Reload()
    {
        Debug.Log("Reloading !!! ");
        yield return new WaitForSeconds(reloadTime);
        totalProjectilesNumber += MagazineCount;
        if (totalProjectilesNumber > 0)
        {
            if (totalProjectilesNumber > MagazineMaxSize)
            {
                totalProjectilesNumber -= MagazineMaxSize;
                MagazineCount = MagazineMaxSize;
            }
            else
            {
                MagazineCount = totalProjectilesNumber;
                totalProjectilesNumber = 0;
            }
        }
        ReloadingRotine = null;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootingRotine = StartCoroutine(ShootBullets());
        }
        if (Input.GetMouseButtonUp(0))
        {
            StopCoroutine(ShootingRotine);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (ReloadingRotine == null)
                ReloadingRotine = StartCoroutine(Reload());
        }
    }

    private void CreateBullet()
    {
        StartCoroutine(CreateBulletCo());
    }

    IEnumerator CreateBulletCo()
    {
        yield return new WaitForEndOfFrame();
        newProjectile = GameObject.Instantiate(Projectile);
           
        newProjectile.gameObject.SetActive(true);
        newProjectile.position = Muzzle.transform.position;
        newProjectile.rotation = Muzzle.transform.rotation;

        //  IsShooting = false;

        ps = newProjectile.GetComponent<ProjectileScript>();
        if (ps)
        {
            ps.range = range;
        }

        rb = newProjectile.GetComponent<Rigidbody>();
        if (rb)
        {
            rb.velocity = Vector3.zero;
            rb.AddForce(Muzzle.transform.forward * SHootingForce, ForceMode.Impulse);
            print(newProjectile.transform.position);
            print(rb.velocity);
            rb = null;
        }
    }

    private void ShootCurrentProjectile()
    {
 
    }
}
