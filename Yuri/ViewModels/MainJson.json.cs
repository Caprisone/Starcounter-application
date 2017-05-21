using Starcounter;
using Yuri.Models;

namespace Yuri.ViewModels
{
    partial class MainJson : Json
    {
        static MainJson()
        {
            DefaultTemplate.Corporations.ElementType.InstanceType = typeof(CorporationJson);
        }

        void Handle(Input.CreationTrigger action)
        {
            if (!string.IsNullOrEmpty(action.App.CorporationName))
            {
                var corporation = new Corporation()
                {
                    Name = action.App.CorporationName
                };
                this.Corporations.Add(new CorporationJson() { Data = corporation });
                Transaction.Commit();
            }
        }
    }
}
