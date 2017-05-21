using Starcounter;

namespace Yuri.ViewModels
{
    partial class FranchiseOfficeJson : Json
    {
        public string Address => $"{Street} {Number}, {Zip} {City}, {Country}";

        public string GetUrl { get { return $"/Yuri/franchise/{this.Data.GetObjectID()}"; } }

        void Handle(Input.SaveTrigger action)
        {
            Transaction.Commit();
        }
    }
}
