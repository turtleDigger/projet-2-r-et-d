using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
// using UnityEditor;

public class Transition : MonoBehaviour
{
    private bool _start;
    private GameObject _newGameGO;
    private Light _flameL, _sunL;
    private VideoPlayer _flameVP;
    // [SerializeField] private LightingDataAsset _sunLDA;
    
    private void Start()
    {
        InitVariables();
        StartCoroutine(FlameDanseRoutine());
    }

    private void InitVariables()
    {
        _newGameGO = GameObject.Find("New Game Text");
        _flameL = GameObject.Find("Flame Light").GetComponent<Light>();
        _sunL = GameObject.Find("Sun Light").GetComponent<Light>();
        _flameVP = GameObject.Find("Flame Video Player").GetComponent<VideoPlayer>();
    }

    public void StartTransition()
    {
        StartCoroutine(TransitionRoutine());
    }

    private IEnumerator FlameDanseRoutine()
    {
        int sign = 1;
        float randomSpeed = Random.Range(0.55f, 1.0f);

        while(!_start)
        {
            if(_flameL.intensity < 0.7f)
            {
                sign = -1;
                randomSpeed = Random.Range(0.55f, 1.0f);
            }
            if(_flameL.intensity > 1.0f)
            {
                sign = 1;
                randomSpeed = Random.Range(0.55f, 1.0f);
            }
            _flameL.intensity -= sign * randomSpeed * Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }
        _flameL.intensity = 1;
    }

    private IEnumerator TransitionRoutine()
    {
        _start = true;
        _newGameGO.SetActive(false);
        // Lightmapping.lightingDataAsset = _sunLDA;

        while(_flameVP.targetCameraAlpha > 0.01f)
        {
            _flameVP.targetCameraAlpha -= 0.5f * Time.deltaTime;
            _flameL.intensity -= 0.5f * Time.deltaTime;
            _sunL.intensity += 0.5f * Time.deltaTime;
            RenderSettings.ambientIntensity += 0.4f * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        _flameVP.gameObject.SetActive(false);
        _flameL.gameObject.SetActive(false);
        _sunL.intensity = 1;
        RenderSettings.ambientIntensity = 1;
    }
}
