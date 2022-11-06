using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class DotweenExample : MonoBehaviour {
    [Header("Objects")]
    [SerializeField] private Transform from;
    [SerializeField] private Transform to;
    [SerializeField] private Transform item;

    [Header("Eases")]
    [SerializeField] private Ease moveEasing;
    [SerializeField] private float duration;
    [Range(0f, 1f)]
    [SerializeField] private float parabolaHeight;
    [SerializeField] private bool applyParabola;
    [SerializeField] private PathType parabolaPathType;
    [SerializeField] private PathMode parabolaPathMode;


    [Header("Management")]
    [SerializeField] private Button startStop;
    [SerializeField] private Button setup;

    Sequence _sequence;
    protected Vector3[] _intermediatePoints;

    private void Start() {
        startStop.onClick.AddListener(StartStopTween);
        setup.onClick.AddListener(ResetupTween);
        SetupTween();
    }

    public void StartStopTween() {
        if (_sequence.IsPlaying()) {
            PauseTween();
        } else {
            StartTween();
        }
    }

    public void StartTween() {
        _sequence.Play();
    }

    public void PauseTween() {
        _sequence.Pause();
    }

    public void ResetupTween() {
        KillTween();
        SetupTween();
    }

    public void KillTween() {
        _sequence.Kill();
    }

    public void SetupTween() {
        item.position = from.position;
        _sequence = DOTween.Sequence();

        if (applyParabola) {
            CalculateIntermediatePoints(from.position, to.position);
            _sequence.Insert(0f, item.DOPath(_intermediatePoints, duration, parabolaPathType, parabolaPathMode));
        } else {
            _sequence.Insert(0f, item.DOMove(to.position, duration).SetEase(moveEasing));
        }

        _sequence.InsertCallback(duration + 0.1f, ResetupTween);

    }

    protected void CalculateIntermediatePoints(Vector2 startPos, Vector2 targetPos) {
        if (_intermediatePoints == null) {
            _intermediatePoints = new Vector3[2];
        }

        Vector2 mid = Vector2.Lerp(startPos, targetPos, 0.5f);
        Vector2 direction = Vector2.Perpendicular((targetPos - startPos).normalized);
        float height = Vector2.Distance(startPos, targetPos) * parabolaHeight;
        _intermediatePoints[0] = (direction * height) + mid;
        _intermediatePoints[1] = targetPos;
    }
}