using System.Globalization;

namespace BlazorServer_WCF.Web.Pages
{
    /// <summary>
    /// Audit
    /// </summary>
    public partial class Audit
    {
        #region Classes and Variables

        /// <summary>
        /// Data Item
        /// </summary>
        class DataItem
        {
            public DateTime Date { get; set; }
            public double Revenue { get; set; }
        }

        List<DataItem> Commited;

        List<DataItem> Uncommited;

        List<DataItem> Realesed;

        bool smooth = true;

        public DateTime LastTwoMonths { get; set; } = DateTime.Now.AddMonths(-2);

        #endregion


        #region Razor Functions

        /// <summary>
        /// On Initialized
        /// </summary>
        protected override void OnInitialized()
        {
            Commited = new List<DataItem>();
            Uncommited = new List<DataItem>();
            Realesed = new List<DataItem>();
            SetChartValue();
        }

        /// <summary>
        /// Format As USD
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        string FormatAsUSD(object value)
        {
            return ((double)value).ToString("C0", CultureInfo.CreateSpecificCulture("en-US"));
        }

        /// <summary>
        /// Set Chart Value
        /// </summary>
        public void SetChartValue()
        {
            for (int i = 1; i < 11; i++)
            {
                LastTwoMonths = LastTwoMonths.AddDays(7);
                Commited.Add(new DataItem
                {
                    Date = LastTwoMonths.Date,
                    Revenue = Random.Shared.Next(0, 200)
                });
                Uncommited.Add(new DataItem
                {
                    Date = LastTwoMonths.Date,
                    Revenue = Random.Shared.Next(0, 250)
                });
                Realesed.Add(new DataItem
                {
                    Date = LastTwoMonths.Date,
                    Revenue = Random.Shared.Next(0, 500)
                });
            }
        }

        #endregion
    }
}

