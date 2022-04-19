using AxGrid.Base;

namespace ToolsTest
{
    public class OpenedCoffin : MonoBehaviourExt, IColliderHandler
    {
        public void OnCollide(bool isBone)
        {
            if (isBone) Model.Inc("Score");
            else Model.Dec("Health");
        }
    }
}