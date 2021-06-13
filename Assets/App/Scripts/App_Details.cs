
public class App_Details : Singleton<App_Details>
{
  public bool IN_VR = true;
  public float MAX_DISTANCE_TRIGGER_BOWPULL = 0.785f;
  public float MAX_DISTANCE_BOWPULL = 1.376f;
  public float MIN_DISTANCE_ARROWRELEASE = 0.85f;
  public float GRAVITY = 0.001f;
  public float ARROW_VELOCITY_MIN = 0.1f;
  public float ARROW_VELOCITY_MAX = 0.8f;
  public float ARROW_DESTRUCTION_DEPTH = -10.0f;
  public float CONTROLLER_TURN_AMOUNT = 15.0f;
  public string COLOR_HITPOINT_DISPLAY = "1e1b14";
  public string COLOR_HITPOINT_DISPLAY_EMPTY = "260303";
}
