using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Button OpenButton;
	[SerializeField]
	private Button CloseButton;
	[SerializeField]
	private GameObject MainPanel;
	private Animator AnimationStart;


	void Start()
	{
		MainPanel.SetActive(false);
		Button openBtn = OpenButton.GetComponent<Button>();
		openBtn.onClick.AddListener(StartSimulation);

		Button closeBtn = CloseButton.GetComponent<Button>();
		closeBtn.onClick.AddListener(StopSumilation);

		AnimationStart = MainPanel.GetComponent<Animator>();
	}

	void StartSimulation()
	{
		OpenButton.gameObject.SetActive(false);
		MainPanel.SetActive(true);
		AnimationStart.SetBool("Open", true);
	}

	void StopSumilation()
	{
		foreach (var circle in GameObject.FindGameObjectsWithTag("Circle"))
        {
			Destroy(circle);
        }
		MainPanel.SetActive(false);
		OpenButton.gameObject.SetActive(true);
	}

}