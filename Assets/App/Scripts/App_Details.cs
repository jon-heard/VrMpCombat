
using UnityEngine;

public class App_Details : Common.Singleton<App_Details>
{
  [Tooltip("If true, VR system is started when app begins")]
  public bool IN_VR = true;
  [Tooltip("VR specific - How far apart the hands can be and still start pulling the bow")]
  public float MAX_DISTANCE_TRIGGER_BOWPULL = 0.785f;
  [Tooltip("How far the bow can be pulled back.  Beyond this, hands just keep distance.")]
  public float MAX_DISTANCE_BOWPULL = 1.376f;
  [Tooltip("How little the bow can be pulled back and still shoot on release")]
  public float MIN_DISTANCE_ARROWRELEASE = 0.85f;
  [Tooltip("How fast falling things accelerate")]
  public float GRAVITY = 0.001f;
  [Tooltip("How fast arrow is when shot with minimal force")]
  public float ARROW_SPEED_MIN = 0.1f;
  [Tooltip("How fast arrow is when shot with maximal force")]
  public float ARROW_SPEED_MAX = 0.8f;
  [Tooltip("How far arrow falls before it's considered to be off map edge, and removed")]
  public float ARROW_DESTRUCTION_DEPTH = -10.0f;
  [Tooltip("How far arrow falls before it's considered to be off map edge, and removed")]
  public float ARROW_EMBED_DEPTH = 0.05f;
  [Tooltip("Controls include snap-rotation.  This value is the angle of the snap.")]
  public float CONTROLLER_TURN_AMOUNT = 15.0f;
  [Tooltip("Color of hitpoint visualization when hitpoint is NOT spent")]
  public string COLOR_HITPOINT_DISPLAY = "1e1b14";
  [Tooltip("Color of hitpoint visualization when hitpoint is spent")]
  public string COLOR_HITPOINT_DISPLAY_EMPTY = "260303";
}
