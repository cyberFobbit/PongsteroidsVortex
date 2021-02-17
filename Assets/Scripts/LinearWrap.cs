using UnityEngine;

public class LinearWrap : MonoBehaviour
{
    [SerializeField] TrailRenderer disableOnJump; 
    private float pointDistance;
    private Vector3 jumpPoint;

    // Update is called once per frame
    void Update()
    {
        if(disableOnJump != null) disableOnJump.emitting = true;
        var rb = GetComponent<Rigidbody2D>();
        var screenPos = Camera.main.WorldToScreenPoint(transform.position);

        //Wrap along linear trajectory
        if(screenPos.x > Screen.width || screenPos.x < 0 || screenPos.y > Screen.height || screenPos.y < 0){
            pointDistance = 0;
            var slopeOfFlight = rb.velocity.y/rb.velocity.x; 
            //find intercept points
            var rightInt = new Vector3(Screen.width,slopeOfFlight * (Screen.width-screenPos.x) + screenPos.y,-Camera.main.transform.position.z);
            var leftInt = new Vector3(0,slopeOfFlight * (0-screenPos.x) + screenPos.y,-Camera.main.transform.position.z);
            var bottomInt = new Vector3(((0-screenPos.y)/slopeOfFlight) + screenPos.x,0,-Camera.main.transform.position.z);
            var topInt = new Vector3(((Screen.height-screenPos.y)/slopeOfFlight) + screenPos.x,Screen.height,-Camera.main.transform.position.z);
            
            //check intercepts for valid points
            if(rightInt.y > 0 && rightInt.y < Screen.height){
                pointDistance = Vector3.Distance(rightInt,screenPos);
                jumpPoint = rightInt;
            }
            if(topInt.x > 0 && topInt.x < Screen.width && Vector3.Distance(topInt,screenPos) > pointDistance){
                pointDistance = Vector3.Distance(topInt,screenPos);
                jumpPoint = topInt;
            }
            if(leftInt.y > 0 && leftInt.y < Screen.height && Vector3.Distance(leftInt,screenPos) > pointDistance){
                pointDistance = Vector3.Distance(leftInt,screenPos);
                jumpPoint = leftInt;
            }
            if(bottomInt.x > 0 && bottomInt.x < Screen.width && Vector3.Distance(bottomInt,screenPos)> pointDistance){
                pointDistance = Vector3.Distance(bottomInt,screenPos);
                jumpPoint = bottomInt;
                
            }
            //jump to new point
            if(disableOnJump != null) disableOnJump.emitting = false;
            transform.position = Camera.main.ScreenToWorldPoint(jumpPoint);
            
        }
    }
}
