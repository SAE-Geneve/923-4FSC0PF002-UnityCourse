using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

namespace FSM_Starter
{
    public class FSM_Tank : MonoBehaviour
    { 
        [SerializeField] private WaypointsManager _waypointsManager;
        [SerializeField] private GameObject _turret;
        [SerializeField] private Animator _animator;        
        [SerializeField] private GameObject _bulletModel;
        [SerializeField] private Transform _firePoint;

        private NavMeshAgent _navMeshAgent;
        private float _startSpeed;
        private GameObject _myTarget;
        private FSM_TargetTank _target = null;

        private const float TARGETTING_DISTANCE = 75f;
        private const float SHOOTING_DISTANCE = 10f;
        private const float FIRE_AMPLITUDE = 10f;
        private const float HIDING_TIME = 2f;
        private const float FIRE_RATE = .35f;

        public  FSM_TargetTank Target => _target;
        public Transform TurretTransform => _turret.transform;
        public Animator Animator => _animator;
        public NavMeshAgent NavmeshAgent => _navMeshAgent;
        public WaypointsManager WaypointsManager => _waypointsManager;

        private FSM_PatrolState _patrolState;
        private FSM_ChaseState _chaseState;
        private FSM_StateMachine _stateMachine = new FSM_StateMachine();


        private float timer = 0;
        
        // Start is called before the first frame update
        void Awake()
        {
            
            if(!TryGetComponent<NavMeshAgent>(out _navMeshAgent))
                Debug.LogError("No nav mesh agent on current tank");
            
            if(!TryGetComponent<Animator>(out _animator))
                Debug.LogError("No animator");

            _patrolState = new FSM_PatrolState(this);
            _chaseState = new FSM_ChaseState();
            
            _stateMachine.AddTransition(_patrolState, _chaseState, () => Target != null);
            _stateMachine.AddTransition(_chaseState, _patrolState, () => Target == null);
            
            _stateMachine.SetState(_patrolState);
            
        }

        // Update is called once per frame
        void Update()
        {
            timer += Time.deltaTime;
            
            _stateMachine.Tick();
            
        }

        public void StartTargetting()
        {
            StartCoroutine("CheckTargetting");
        }
        public void StopTargetting()
        {
            StopCoroutine("CheckTargetting");
        }
        IEnumerator CheckTargetting()
        {

            float timeSpotting = 0f;
            
            do
            {
                
                Ray targetRay = new Ray(TurretTransform.position, TurretTransform.forward);
                Debug.DrawRay(targetRay.origin, targetRay.direction * TARGETTING_DISTANCE, Color.red);

                RaycastHit targetHit;
                if (Physics.Raycast(targetRay, out targetHit, TARGETTING_DISTANCE))
                {
                    
                    FSM_TargetTank target;
                    if (targetHit.collider.gameObject.TryGetComponent<FSM_TargetTank>(out target))
                    {
                        Debug.Log("Targetting a tank : " + targetHit.collider.gameObject.name);
                        _target = target;
                        timeSpotting = 0f;
                    }
                    else
                    {
                        timeSpotting += Time.deltaTime;
                        if (timeSpotting >= HIDING_TIME)
                        {
                            _target = null;
                        }
                    }

                }

                yield return null;

            } while (true);
            
        }

        public void StartShooting()
        {
            StartCoroutine("DoShoot");
        }
        public void StopShooting()
        {
            StopCoroutine("DoShoot");
        }
        IEnumerator DoShoot()
        {

            do
            {
                GameObject bulletLaunched = Instantiate(_bulletModel, _firePoint.position, _firePoint.rotation);

                Rigidbody rb = bulletLaunched.GetComponent<Rigidbody>();
                rb.AddRelativeForce(Vector3.forward * FIRE_AMPLITUDE, ForceMode.Impulse);
                
                yield return new WaitForSeconds(FIRE_RATE);

            } while (true);
            
        }

        
    }
}
