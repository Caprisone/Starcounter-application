using Starcounter;
using Yuri.Models;

namespace Yuri.ViewModels
{
    partial class CorporationJson : Json
    {
        static CorporationJson()
        {
            DefaultTemplate.Offices.ElementType.InstanceType = typeof(FranchiseOfficeJson);
        }

        void Handle(Input.OfficeCreationTrigger action)
        {
            if (!string.IsNullOrEmpty(action.App.NewOfficeName))
            {
               var office =  new FranchiseOffice()
                {
                    Name = action.App.NewOfficeName,
                    Corporation = this.Data as Corporation
                };
                this.Offices.Add(new FranchiseOfficeJson() { Data = office });
                Transaction.Commit();
            }
        }

        void Handle(Input.SortHomesTrigger action) { }
        void Handle(Input.SortTotalCommissionTrigger action) { }
        void Handle(Input.SortAvgCommissionTrigger action) { }
        void Handle(Input.SortTrendTrigger action) { }
    }
}
