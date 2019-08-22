using System.Collections.Generic;

namespace FMS.ServiceLayer.Interface.Dtos
{
    public class PriceListDto
    {
        public int PriceListId { get; set; }
        public string PriceListName { get; set; }
        public bool IsVAT { get; set; }
        public string CurrencyCode { get; set; }
        public List<PriceDto> Prices { get; set; }
    }
}
