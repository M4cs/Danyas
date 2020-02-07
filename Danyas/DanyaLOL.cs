using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using CatGame;
using CatGame.Items;

namespace Danyas
{
    public class DanyaLOL : MonoBehaviour
    {
        public void Start()
        {
            _Player = FindObjectOfType<PlayerController>();
            _scoring = FindObjectOfType<ScoringSystem>();
            camera = FindObjectOfType<Camera>();
            originalScene = SceneManager.GetActiveScene();
            Cursor.lockState = CursorLockMode.None;
            if (Cursor.lockState.Equals(CursorLockMode.Locked)) {
                cursorHidden = true;
            } else
            {
                cursorHidden = false;
            }


        }

        public void OnGUI()
        {
            GUI.Box(new Rect(10, 10, Screen.width / 4, Screen.height / 4), "Danyas by Max");
            if (GUI.Button(new Rect(20, 40, 150, 50), "Break All"))
            {
                _Items = FindObjectsOfType<DestructibleItem>();
                _RItems = FindObjectsOfType<ResetableItem>();
                foreach (DestructibleItem item in _Items)
                {
                    item.Break(10000f);
                }
                foreach (ResetableItem item in _RItems)
                {
                    item.Lift(100f);
                    item.transform.position = new Vector3(item.transform.position.x + 2f, item.transform.position.y + 5f);
                }
            }
            if (GUI.Button(new Rect(20, 60, 150, 50), "Reload Danyas"))
            {
                Reload();
            }
        }

        public void Reload()
        {
            _Player = FindObjectOfType<PlayerController>();
            _scoring = FindObjectOfType<ScoringSystem>();
            camera = FindObjectOfType<Camera>();
            originalScene = SceneManager.GetActiveScene();
            Cursor.lockState = CursorLockMode.None;
            if (Cursor.lockState.Equals(CursorLockMode.Locked))
            {
                cursorHidden = true;
            }
            else
            {
                cursorHidden = false;
            }
        }

        public void Update()
        {
            if (Input.GetKey(KeyCode.U))
            {
                if (cursorHidden)
                {
                    Cursor.lockState = CursorLockMode.None;
                }
                else
                {
                    Cursor.lockState = CursorLockMode.Locked;
                }
            }
        }

        private PlayerController _Player;
        private DestructibleItem[] _Items;
        private ResetableItem[] _RItems;
        private ScoringSystem _scoring;
        private Camera camera;
        private Scene originalScene;
        private Scene currentScene;
        private bool cursorHidden;
    }
}
