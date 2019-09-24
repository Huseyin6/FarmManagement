using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Farm.Web.ViewModels
{
    public class BaseFinancialViewModel
    {
        public DateTime TransactionDate { get; set; }
        [Required(ErrorMessage ="Boş Olamaz")]
        [AllowHtml]
        public string Description { get; set; }
        public decimal Total { get; set; }
        public int FinancialAssetTypeId { get; set; }
        public SelectList SelectList { get; set; }
    }
}