namespace FMS.WPF.Strategies
{
    public class WarehouseListStrategy : ILocationListStrategy
    {
        public string DisplayName => "Valmiskaubalaod";

        public int LocationTypeId => 1;

        public string ItemsCountCaption => "Valmiskaubaladude arv:";
    }
}
