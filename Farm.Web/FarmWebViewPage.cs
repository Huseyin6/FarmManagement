using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Farm.Web
{
    public abstract class FarmWebViewPage
    {
        public List<SelectListItem> IncomeGetType()
        {

            return new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "Süt Satışı",
                    Value = "1",
                    Selected = true
                },
                new SelectListItem
                {
                    Text = "Et",
                    Value = "2"
                },
                new SelectListItem
                {
                    Text = "Teşvik",
                    Value = "3",
                }
            };
        }
    }
}