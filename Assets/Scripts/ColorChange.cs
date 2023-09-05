using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ColorChange : MonoBehaviour
{
    [SerializeField] private float _changeColorTime;

    [SerializeField] private float _waitColorTime;

    private float _startTime;
    private float _currentTime;

    private bool _changingColor;

    private Color _newColor;

    private Color _currentColor;

    private Renderer _renderer;
    // Start is called before the first frame update

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        GenerateNextColor();
    }

    void Start()
    {
        _startTime = 0;
        _currentTime = 0;
        _changingColor = true;
    }

    private void GenerateNextColor()
    {
        _currentColor = _renderer.material.color;
        
        _newColor = Random.ColorHSV(0f,1f,0.8f,1f,1f,1f);

    }

    // Update is called once per frame
    void Update()
    {
        if (_changingColor)
        {
            _currentTime += Time.deltaTime;
            var progress = _currentTime / _changeColorTime;
            var currentColor = Color.Lerp(_currentColor, _newColor, progress);
            _renderer.material.color = currentColor;
            if (_currentTime >= _changeColorTime)
            {
                ChangeMode();
            }       
        }
        else
        {
            _currentTime += Time.deltaTime;
            if (_currentTime >= _waitColorTime)
            {
                GenerateNextColor();
                ChangeMode();
            }       
            
        }
    }

    private void ChangeMode()
    {
        _changingColor = !_changingColor;
        _currentTime = 0;
    }
}
