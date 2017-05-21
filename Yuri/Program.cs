using System;
using Starcounter;
using Yuri.Models;
using Yuri.ViewModels;

namespace Yuri
{
    class Program
    {
        static void Main()
        {
            Application.Current.Use(new HtmlFromJsonProvider());
            Application.Current.Use(new PartialToStandaloneHtmlProvider());

            Handle.GET("/Yuri", () =>
            {
                return Db.Scope(() =>
                {
                    var corporations = Db.SQL<Corporation>("SELECT c FROM Yuri.Models.Corporation c");
                    var json = new MainJson()
                    {
                        Corporations = corporations
                    };
                    if (Session.Current == null)
                    {
                        Session.Current = new Session(SessionOptions.PatchVersioning);
                    }

                    json.Session = Session.Current;
                    return json;
                });
            });

            Handle.GET("/Yuri/franchise/{?}", (string ObjectID, Request request) =>
            {
                return Db.Scope(() =>
                {
                    var office = Db.SQL<FranchiseOffice>("SELECT fo FROM Yuri.Models.FranchiseOffice fo WHERE fo.ObjectID = ?", ObjectID).First;
                    var json = new FranchiseOfficeJson()
                    {
                        Data = office
                    };
                    if (Session.Current == null)
                    {
                        Session.Current = new Session(SessionOptions.PatchVersioning);
                    }

                    json.Session = Session.Current;
                    return json;
                });
            });
        }
    }
}