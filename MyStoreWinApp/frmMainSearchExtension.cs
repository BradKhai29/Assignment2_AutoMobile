namespace MyStoreWinApp
{
    public static class frmMainSearchExtension
    {
        public static readonly string[] SearchProductCriterias =
        {
            "Select to search",
            "By ProductName",
            "By ProductID",
            "By UnitPrice",
            "By UnitsInStock"
        };

        public static readonly string[] SearchCategoryCriterias =
        {
            "Select to search",
            "By CategoryName",
            "By CategoryID",
        };

        public static readonly string[] SearchMemberCriterias =
        {
            "Select to search",
            "By Member Email",
            "By MemberID",
        };

        public static readonly string[] SearchOrderCriterias =
        {
            "Not Implemented",
        };

        public static string[] GetSearchCriterias(this frmMain form, string section)
        {
            return section switch
            {
                "Product" => SearchProductCriterias,
                "Category" => SearchCategoryCriterias,
                "Member" =>  SearchMemberCriterias,
                "Order" => SearchOrderCriterias,
                _ => SearchOrderCriterias
            };
        }
    }
}
