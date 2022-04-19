using AxGrid.Base;

namespace ToolsTest
{
    public class ClosedCoffin : MonoBehaviourExt, IColliderHandler
    {
        public void OnCollide(bool isBone)
        {
            if (isBone) Model.Dec("Health");
        }
    }
}