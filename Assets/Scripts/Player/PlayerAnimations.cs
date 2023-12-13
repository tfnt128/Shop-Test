using System.Collections;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    public SpriteRenderer playerSpriteRenderer;
    public SpriteRenderer equipSpriteRenderer;
    
    public SpriteDataSO walkSpritesData;
    public SpriteDataSO equipSpriteData;

    public bool isWalking = false;

    [SerializeField] private float walkFrameDuration = 0.2f;

    private int _currentWalkFrame = 0;

    private Coroutine _walkCoroutine;
    private Coroutine _equipCoroutine;


    private void Start()
    {
        UpdateEquip();
    }

    private void UpdateEquip()
    {
        playerSpriteRenderer.sprite = walkSpritesData.standardRenderer;
        equipSpriteRenderer.sprite = equipSpriteData.standardRenderer;
    }

    public void SetupAnimations(Vector2 movementVector)
    {
        isWalking = movementVector.magnitude > 0;

        if (isWalking && _walkCoroutine == null)
        {
            StartWalkAnimation();
        }
        else if (!isWalking && _walkCoroutine != null)
        {
            playerSpriteRenderer.sprite = walkSpritesData.standardRenderer; 
            equipSpriteRenderer.sprite = equipSpriteData.standardRenderer;
            StopWalkAnimation();
        }
    }


    private void StartWalkAnimation()
    {
        if (_walkCoroutine == null)
        {
            _walkCoroutine = StartCoroutine(AnimateWalk());
        }
    }

    private void StopWalkAnimation()
    {
        if (_walkCoroutine != null)
        {
            StopCoroutine(_walkCoroutine);
            _walkCoroutine = null;
        }
    }

    private IEnumerator AnimateWalk()
    {
        while (isWalking)
        {
            equipSpriteRenderer.sprite = equipSpriteData.sprites[_currentWalkFrame];
            playerSpriteRenderer.sprite = walkSpritesData.sprites[_currentWalkFrame];
            _currentWalkFrame = (_currentWalkFrame + 1) % walkSpritesData.sprites.Length;

            yield return new WaitForSeconds(walkFrameDuration);
        }
    }


}
