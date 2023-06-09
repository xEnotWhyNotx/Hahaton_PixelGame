using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager15 : MonoBehaviour {
  [SerializeField] private Transform gameTransform;
  [SerializeField] private Transform piecePrefab;
    public Winnable win;
    private List<Transform> pieces;
    private int emptyLocation;
    private int size;
    private bool shuffling = false;
    private bool k = false;


  private void CreateGamePieces(float gapThickness) {
    float width = 1 / (float)size;
    for (int row = 0; row < size; row++) {
      for (int col = 0; col < size; col++) {
        Transform piece = Instantiate(piecePrefab, gameTransform);
        pieces.Add(piece);
        piece.localPosition = new Vector3(-1 + (2 * width * col) + width,
                                          +1 - (2 * width * row) - width,
                                          0);
        piece.localScale = ((2 * width) - gapThickness) * Vector3.one;
        piece.name = $"{(row * size) + col}";
        if ((row == size - 1) && (col == size - 1)) {
          emptyLocation = (size * size) - 1;
          piece.gameObject.SetActive(false);
        } else {
          float gap = gapThickness / 2;
          Mesh mesh = piece.GetComponent<MeshFilter>().mesh;
          Vector2[] uv = new Vector2[4];
          uv[0] = new Vector2((width * col) + gap, 1 - ((width * (row + 1)) - gap));
          uv[1] = new Vector2((width * (col + 1)) - gap, 1 - ((width * (row + 1)) - gap));
          uv[2] = new Vector2((width * col) + gap, 1 - ((width * row) + gap));
          uv[3] = new Vector2((width * (col + 1)) - gap, 1 - ((width * row) + gap));
          mesh.uv = uv;
        }
      }
    }
  }

  void Start() {
    pieces = new List<Transform>();
    size = 3;
    CreateGamePieces(0.01f);
  }

  void Update() {
    if (!shuffling && CheckCompletion()) {
            if (k == true)
            {
                win.SetMode();
                FindObjectOfType<ActivePuzzle>().SetPuzzle(false);
                FindObjectOfType<Player>().SetUI();
                FindObjectOfType<Cafedreau>().setComplete();
                SceneManager.UnloadSceneAsync("15Game");
            }
            
      shuffling = true;
      StartCoroutine(WaitShuffle(0.5f));
            k = true;
    }

    Vector2 CurMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    if (Input.GetMouseButtonDown(0)) {
      RaycastHit2D hit = Physics2D.Raycast(CurMousePos, Vector2.zero);
      Debug.Log(hit);
      Debug.Log(hit.transform);
      if (hit) {
        for (int i = 0; i < pieces.Count; i++) {
                    Debug.Log(hit.transform);
                    Debug.Log(pieces[i]);
                    if (pieces[i] == hit.transform) {
            if (SwapIfValid(i, -size, size)) { break; }
            if (SwapIfValid(i, +size, size)) { break; }
            if (SwapIfValid(i, -1, 0)) { break; }
            if (SwapIfValid(i, +1, size - 1)) { break; }
          }
        }
      }
    }
  }

  private bool SwapIfValid(int i, int offset, int colCheck) {
    if (((i % size) != colCheck) && ((i + offset) == emptyLocation)) {
      (pieces[i], pieces[i + offset]) = (pieces[i + offset], pieces[i]);
      (pieces[i].localPosition, pieces[i + offset].localPosition) = ((pieces[i + offset].localPosition, pieces[i].localPosition));
      emptyLocation = i;
      return true;
    }
    return false;
  }

  private bool CheckCompletion() {
    for (int i = 0; i < pieces.Count; i++) {
      if (pieces[i].name != $"{i}") {
        return false;
      }
    }
        
        
        // Момент победы
        return true;
  }

  private IEnumerator WaitShuffle(float duration) {
    yield return new WaitForSeconds(duration);
    Shuffle();
    shuffling = false;
  }

  private void Shuffle() {
    int count = 0;
    int last = 0;
    while (count < (size * size * size)) {
      int rnd = Random.Range(0, size * size);
      if (rnd == last) { continue; }
      last = emptyLocation;
      if (SwapIfValid(rnd, -size, size)) {
        count++;
      } else if (SwapIfValid(rnd, +size, size)) {
        count++;
      } else if (SwapIfValid(rnd, -1, 0)) {
        count++;
      } else if (SwapIfValid(rnd, +1, size - 1)) {
        count++;
      }
    }
  }
  public void Exit()
  {
      FindObjectOfType<ActivePuzzle>().SetPuzzle(false);
      FindObjectOfType<Camera>().enabled = true;
      FindObjectOfType<Player>().SetUI();
      SceneManager.UnloadSceneAsync("15Game");
  }
}
