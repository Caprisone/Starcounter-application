using Starcounter;

namespace Yuri.Models
{
    [Database]
    public class Corporation
    {
        public string Name;
        public QueryResultRows<FranchiseOffice> Offices => Db.SQL<FranchiseOffice>("SELECT fo FROM Yuri.Models.FranchiseOffice fo WHERE fo.Corporation = ?", this);
    }
}
