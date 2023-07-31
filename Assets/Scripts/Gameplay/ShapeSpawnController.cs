using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Gameplay
{
    public class ShapeSpawnController : MonoBehaviour
    {
        [SerializeField] private GameplayController GameplayController;
        [SerializeField] private RectTransform Canvas;
        [SerializeField] private List<Shape> Shapes;

        private const float SpawnInterval = 3f;
        private bool GameOver;

        private GraphicRaycaster GraphicRaycaster;
        private EventSystem EventSystem;

        private void Start()
        {
            StartCoroutine(Spawn());
        }

        private IEnumerator Spawn()
        {
            while (!GameOver)
            {
                var randomShape = Shapes[Random.Range(0, Shapes.Count)];
                var shapeRect = randomShape.GetComponent<RectTransform>().rect;

                var canvas = Canvas.rect;
                var x = Random.Range(-canvas.width / 2 + shapeRect.width / 2, canvas.width / 2 - shapeRect.width / 2);
                var y = Canvas.rect.height / 2 + shapeRect.height / 2;
                Vector2 randomPosition = new Vector2(x, y);

                var shape = Instantiate(randomShape, transform);
                shape.GetComponent<RectTransform>().anchoredPosition = randomPosition;
                shape.Init(GameplayController.IncreaseScore);

                yield return new WaitForSeconds(SpawnInterval);
            }
        }
    }
}