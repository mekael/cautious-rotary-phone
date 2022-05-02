namespace Paylocity.Web.Logic.Shared
{
    public class IndexQueryBase
    {
        public int NumberOfItemsPerPage { get; set; }
        public int PageNumber { get; set; }

        public void Validate() {

            NumberOfItemsPerPage = NumberOfItemsPerPage > 0 ? NumberOfItemsPerPage : 25;
            PageNumber = PageNumber > 0 ? PageNumber : 1;

        }
    }
}
