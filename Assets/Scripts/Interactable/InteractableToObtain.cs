public class InteractableToObtain : Interactable
{
    public override void GetInteract(PlayerMain player)
    {
        base.GetInteract(player);
        player.Inventory.Inventory.Add(gameObject);
        gameObject.SetActive(false);
    }
}