
public class CollectableTutorial : BaseCollectable
{
    public override void GrabItem()
    {
        Destroy(gameObject);
    }

}
