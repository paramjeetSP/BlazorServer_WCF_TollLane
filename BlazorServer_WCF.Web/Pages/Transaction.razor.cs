using Microsoft.AspNetCore.Components;
using static BlazorServer_WCF.Web.Pages.AuditDashboard;

namespace BlazorServer_WCF.Web.Pages
{
    public partial class Transaction
    {
        #region Parameters

        [Parameter]
        public List<TransactionData> TransactionData { get; set; }

        #endregion
    }
}
