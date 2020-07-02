﻿
using UnityEngine;


    public class InputPlatformSelector : MonoBehaviour
    {
        // ref to object in Canvas
        public GameObject MobileInputs;

        private void Awake()
        {


#if UNITY_EDITOR

            MobileInputs.SetActive(true);
            gameObject.AddComponent<EditorInput>();
#elif UNITY_STANDALONE_WIN
        gameObject.AddComponent<EditorInput>();
#else
        MobileInputs.SetActive(true);
        gameObject.AddComponent<MobileInput>();        
#endif
        }
    }
