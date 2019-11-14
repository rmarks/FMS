namespace FMS.WPF.Strategies
{
    public class StoreListStrategy : ILocationListStrategy
    {
        public string DisplayName => "Poed";

        public int LocationTypeId => 4;

        public string ItemsCountCaption => "Poodide arv:";
    }
}
