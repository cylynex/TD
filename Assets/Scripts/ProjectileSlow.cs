using Mobs;
using UnityEngine;
using UnityEngine.AI;

public class ProjectileSlow : MonoBehaviour {
    public float speed = 10f;
    [SerializeField] Transform target;
    [SerializeField] int damage = 1;
    [SerializeField] float slowAmount = 1;
    [SerializeField] float slowTime = 3f;

    public void Seek(Transform _target) {
        target = _target;
    }

    void Update() {
        if (target == null) {
            Destroy(gameObject);
            return;
        }

        // Face target and keep moving
        Vector3 direction = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
    }

    private void OnCollisionEnter(Collision collision) {
        //collision.gameObject.GetComponent<HitPoints>().TakeDamage(1);
        collision.gameObject.GetComponent<Mob>().Slowed(slowAmount, slowTime);
        Destroy(gameObject);
    }

}