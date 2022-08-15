
namespace UnityEngine.UI
{
    public class CustomButton : Button
    {
        public bool PublicIsPressed()
        {
            return IsPressed();
        }
    }
}