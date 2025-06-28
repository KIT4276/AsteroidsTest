using TMPro;
using UnityEngine;
using Zenject;

public class PointsUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _points;

    /*[Inject]*/ private TargetDefeatPoints _targetDefeatPoints;

    [Inject]
    private void Initialize(TargetDefeatPoints targetDefeatPoints)
    {
        _targetDefeatPoints = targetDefeatPoints;
        Debug.Log("Initialize PointsUI");
    }

    private void Start()
    {
        //_targetDefeatPoints.OnDefeat += UpdatePoints;
    }

    private void UpdatePoints(int currentPoints)
    {
        _points.text = currentPoints.ToString();
    }
}
