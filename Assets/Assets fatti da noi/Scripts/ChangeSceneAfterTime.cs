using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneAfterTime : MonoBehaviour
{	[SerializeField]
	private float timeBeforeLoadScene = 37f;
	
	private float timeElapsed;

	// Update is called once per frame
	void Update()
    {
		timeElapsed += Time.deltaTime;

		if (timeElapsed > timeBeforeLoadScene)
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
    }
}
