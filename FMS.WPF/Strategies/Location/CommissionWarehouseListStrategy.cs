namespace FMS.WPF.Strategies
{
    public class CommissionWarehouseListStrategy : ILocationListStrategy
    {
        public string DisplayName => "Komisjonilaod";

        public int LocationTypeId => 3;

        public string ItemsCountCaption => "Komisjoniladude arv:";
    }
}
