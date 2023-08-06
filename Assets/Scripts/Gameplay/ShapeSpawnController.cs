using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay
{
    public class ShapeSpawnController : MonoBehaviour
    {
        [SerializeField] Camera Camera;
        [SerializeField] List<Shape> Shapes;

        const float SpawnInterval = 3f;
        GameplayController GameplayController;

        public void Init(GameplayController gameplayController)
        {
            GameplayController = gameplayController;
            StartCoroutine(Spawn());
        }

        IEnumerator Spawn()
        {
            var cameraHeight = 2f * Camera.orthographicSize;
            var halfCameraWidth = cameraHeight * Camera.aspect / 2;
            var halfCameraHeight = cameraHeight / 2;

            while (!GameplayController.IsGameOver)
            {
                var randomShape = Shapes[Random.Range(0, Shapes.Count)];
                var spriteSize = randomShape.GetComponent<SpriteRenderer>().bounds.size;
                var spriteMargin = spriteSize.x / 2;

                var randomX = Random.Range(-halfCameraWidth + spriteMargin, halfCameraWidth - spriteMargin);
                var spawnPosition = new Vector3(randomX, halfCameraHeight + spriteSize.y / 2);

                var shape = Instantiate(randomShape, spawnPosition, Quaternion.identity, transform);
                shape.Init(GameplayController.IncreaseScore);

                yield return new WaitForSeconds(SpawnInterval);
            }
        }
    }
}