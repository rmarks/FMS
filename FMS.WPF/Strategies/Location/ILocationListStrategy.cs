namespace FMS.WPF.Strategies
{
    public interface ILocationListStrategy
    {
        string DisplayName { get; }
        int LocationTypeId { get; }
        string ItemsCountCaption { get; }

    }
}
