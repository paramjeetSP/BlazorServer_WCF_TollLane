using Microsoft.AspNetCore.Components;
using static BlazorServer_WCF.Web.Pages.AuditDashboard;

namespace BlazorServer_WCF.Web.Pages
{
    /// <summary>
    /// Audit Accuracy
    /// </summary>
    public partial class AuditAccuracy
    {
        #region Parameters

        [Parameter]
        public List<TransactionData> Data { get; set; }

        #endregion


        #region Classes and Variables       

        /// <summary>
        /// Accuracy Bar Model
        /// </summary>
        public class AccuracyBar
        {
            public double Value { get; set; }
        }

        List<AccuracyBar> Accepts;

        List<AccuracyBar> Rejects;

        List<AccuracyBar> RejectCode;

        #endregion


        #region Razor Functions

        /// <summary>
        /// On Initialized
        /// </summary>
        protected override void OnInitialized()
        {
            Accepts = new List<AccuracyBar>();
            Rejects = new List<AccuracyBar>();
            RejectCode = new List<AccuracyBar>();
            SetChartValue();
        }


        /// <summary>
        /// Set Chart Value
        /// </summary>
        public void SetChartValue()
        {
            var acceptData = Data.Where(x => x.ReviewResult == ReviewResult.Accept).OrderBy(a => a.AuditDate).ToList();
            var rejectData = Data.Where(x => x.ReviewResult == ReviewResult.Reject).OrderBy(a => a.AuditDate).ToList();
            var rejectCodData = Data.Where(x => x.AuditResult == AuditResult.WrongCode).OrderBy(a => a.AuditDate).ToList();

            Accepts.Add(new AccuracyBar
            {
                Value = Random.Shared.Next(94, 100)
            });

            Rejects.Add(new AccuracyBar
            {
                Value = Random.Shared.Next(94, 100),
            });

            RejectCode.Add(new AccuracyBar
            {
                Value = Random.Shared.Next(94, 100),
            });

        }

        #endregion
    }
}