using UnityEngine;
using System.Collections;
using UnityTuio;
using UnityTracking;

public class TestTuioPlayerManager : ATuioPlayerManager
{
    static private int idx = 0;

    [SerializeField] private GameObject[] _playerPrefabArray;

    override
    public void AddPlayer(TUIO.TuioContainer theTuioContainer)
    {

        //		Vector2 position = UnityTuioManager.GetScreenPositionFromRelativePosition (theTuioContainer.Position);
        Vector2 position = TrackingAdapter.GetScreenPositionFromRelativePosition(theTuioContainer.Position.X, theTuioContainer.Position.Y);

        ATrackingEntity aPlayer = (GameObject.Instantiate(_playerPrefabArray[idx], new Vector3(position.x, position.y, 0), Quaternion.identity) as GameObject).GetComponent<ATrackingEntity>();
        aPlayer.TrackID = theTuioContainer.SessionID;
        aPlayer.RelativePosition = new Vector2(theTuioContainer.Position.X, theTuioContainer.Position.Y);
        
        aPlayer.gameObject.name = string.Format("TuioPlayer_{0}", aPlayer.TrackID);

        _playerList.Add(aPlayer);

        if (idx < _playerPrefabArray.Length - 1)
        {
            idx++;
        }else
        {
            idx = 0;
        }
        
    }

}
