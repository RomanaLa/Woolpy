using UnityEngine;
using System.Collections;
using UnityPharus;
using UnityTracking;

public class TestPharusPlayerManager : APharusPlayerManager
{
    public GameObject[] _playerPrefabArray;
    static private int idx = 0;

    override
    public void AddPlayer(PharusTransmission.TrackRecord trackRecord)
    {

        //		Vector2 position = UnityPharusManager.GetScreenPositionFromRelativePosition(trackRecord.relPos);
        Vector2 position = TrackingAdapter.GetScreenPositionFromRelativePosition(trackRecord.relPos.x, trackRecord.relPos.y);
        ATrackingEntity aPlayer = (GameObject.Instantiate(_playerPrefabArray[idx], new Vector3(position.x, position.y, 0), Quaternion.identity) as GameObject).GetComponent<ATrackingEntity>();
        aPlayer.TrackID = trackRecord.trackID;
        aPlayer.AbsolutePosition = new Vector2(trackRecord.currentPos.x, trackRecord.currentPos.y);
        aPlayer.NextExpectedAbsolutePosition = new Vector2(trackRecord.expectPos.x, trackRecord.expectPos.y);
        aPlayer.RelativePosition = new Vector2(trackRecord.relPos.x, trackRecord.relPos.y);
        aPlayer.Orientation = new Vector2(trackRecord.orientation.x, trackRecord.orientation.y);
        aPlayer.Speed = trackRecord.speed;
        aPlayer.Echoes.Clear();
        trackRecord.echoes.AddToVector2List(aPlayer.Echoes);

        aPlayer.gameObject.name = string.Format("PharusPlayer_{0}", aPlayer.TrackID);

        _playerList.Add(aPlayer);

        _playerList.Add(aPlayer);

        if (idx < _playerPrefabArray.Length - 1)
        {
            idx++;
        }
        else
        {
            idx = 0;
        }
    }

    //	void Start()
    //	{
    //		Invoke ("Test", 3f);
    //	}
    //
    //	private void Test()
    //	{
    //		Debug.Log (UnityTracking.TrackingAdapter.TrackingStageX);
    //	}
}
