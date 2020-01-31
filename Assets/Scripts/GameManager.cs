using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public static GameManager sInstance;

    [Header("Gear")]
    [SerializeField] private Transform m_GearSpawnTransform;

    [Space(5)]
    [SerializeField] private GameObject m_GearPrefabOne;
    [SerializeField] private GameObject m_GearPrefabTwo;
    [SerializeField] private GameObject m_GearPrefabThree;

    [Header("Tower")]
    [SerializeField] private GameObject m_Tower;

    public bool m_TowerIsTurning {
        get { return m_towerIsTurning; } 
        private set {
            m_towerIsTurning = value;
        }
    }

    private bool m_towerIsTurning = false;

    private void Awake()
    {
        if (sInstance == null)
        {
            sInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SpawnGears();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnGears()
    {

    }

    public void ParentGear( Gear gear)
    {
        gear.transform.localScale = Vector3.one;
        gear.transform.parent = m_Tower.transform.GetChild(1);
    }

    public void TurnLeft()
    {
        if (m_TowerIsTurning)
        {
            return;
        }

        Vector3 rot = m_Tower.transform.rotation.eulerAngles + new Vector3(0.0f, 90.0f, 0.0f);
        m_Tower.transform.DORotate(rot, 1.0f).SetEase(Ease.InOutCirc).OnComplete(OnTurnComplet);
        m_towerIsTurning = true;

    }

    public void TurnRight()
    {
        if (m_TowerIsTurning)
        {
            return;
        }

        Vector3 rot = m_Tower.transform.rotation.eulerAngles - new Vector3(0.0f, 90.0f, 0.0f);
        m_Tower.transform.DORotate(rot, 1.0f).SetEase(Ease.InOutCirc).OnComplete(OnTurnComplet);
        m_TowerIsTurning = true;
    }

    void OnTurnComplet()
    {
        m_TowerIsTurning = false;
    }
}
