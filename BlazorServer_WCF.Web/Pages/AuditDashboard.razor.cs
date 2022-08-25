using Radzen;

namespace BlazorServer_WCF.Web.Pages
{
    /// <summary>
    /// Audit Dashboard
    /// </summary>
    public partial class AuditDashboard
    {
        /// <summary>
        /// Audit Dashboard Constructor
        /// </summary>
        public AuditDashboard()
        {
            TransactionDatas = new List<TransactionData>();
            Search = new TransactionSearch();
        }


        #region Models

        /// <summary>
        /// Transaction Data Model
        /// </summary>
        public class TransactionData
        {
            public int TxnNo { get; set; } = 1;

            public int TransactionID { get; set; }

            public string TransactionDateTime { get; set; }

            public string Plaza { get; set; }

            public int Lane { get; set; }

            public string ReviewDate { get; set; }

            public ReviewResult ReviewResult { get; set; }

            public AuditStatus AuditStatus { get; set; }

            public string AuditDate { get; set; }

            public AuditResult AuditResult { get; set; }

            public string AuditorName { get; set; }

            public double Percentage { get; set; }
        }


        /// <summary>
        /// Transaction Search Model
        /// </summary>
        public class TransactionSearch
        {
            public DateTime FromDate { get; set; }

            public DateTime ToDate { get; set; }

            public string FromTime => $"12:00 {DateTime.Now.ToString("tt", System.Globalization.CultureInfo.InvariantCulture)}";

            public string ToTime => $"12:00 {DateTime.Now.ToString("tt", System.Globalization.CultureInfo.InvariantCulture)}";

            public string Disposition { get; set; }

            public string Transaction { get; set; }

            public string Reviewer { get; set; }

            public int TransactionId { get; set; }
        }

        #endregion



        #region Enums

        public enum ReviewResult
        {
            Accept = 1,
            Reject
        }

        public enum AuditStatus
        {
            Complete = 1,
            Incomplete
        }

        public enum AuditResult
        {
            Correct = 1,
            Incorrect,

            [System.ComponentModel.DataAnnotations.Display(Name = "Wrong Code")]
            WrongCode
        }

        #endregion


        #region Variable Declarations

        List<TransactionData> TransactionDatas;

        TransactionSearch Search;

        public TransactionData Data { get; set; }

        List<string> names = new List<string>() { "Noah Smith", "Charlotte Rodriguez", "Liam Johnson", "Emma Jones", "Mason Wilson", "Olivia Miller", "Jacob Taylor", "Isabella Garcia", "Michael Wang", "Ethan Williams", "Alexander Brown", "Sophia Davis" };

        List<string> cities = new List<string>() { "Anderson Mill Road", "Barton Springs Road", "Ben White Boulevard", "E.M. Franklin Avenue", "Ed Bluestein Boulevard", "Jollyville Road", "Koenig Lane", "Lorraine", "Newning Avenue", "Robert T. Martinez St.", "Speedway", "Waller Street", "West Lynn" };

        List<string> DispositionType = new List<string> { "All", "Accept", "Reject" };

        List<string> TransactionDDL = new List<string> { "Percentage", "Number" };

        public DateTime LastTwoMonths { get; set; } = DateTime.Now.AddMonths(-2);

        int index = 1;

        public int SliderValue { get; set; } = 50;

        public int TransactionType { get; set; } = 0;

        #endregion


        #region Razor Functions


        /// <summary>
        /// On Initialized
        /// </summary>
        protected override void OnInitialized()
        {
            SetAgentDetails();
        }


        /// <summary>
        /// Set Agent Details
        /// </summary>
        void SetAgentDetails()
        {
            for (int i = 0; i < 12; i++)
            {
                LastTwoMonths = LastTwoMonths.AddDays(5);
                TransactionDatas.Add(new TransactionData
                {
                    TxnNo = index++,
                    TransactionID = Random.Shared.Next(11000000, 99999999),
                    TransactionDateTime = LastTwoMonths.AddDays(Random.Shared.Next(1, 5))
                    .AddHours(Random.Shared.Next(0, 23)).AddMinutes(Random.Shared.Next(1, 60)).ToString("MM/dd/yyyy hh:mm:ss"),
                    AuditDate = LastTwoMonths.AddDays(Random.Shared.Next(1, 5)).ToString("MM/dd/yyyy"),
                    AuditResult = (AuditResult)Random.Shared.Next(1, 4),
                    AuditStatus = i % 2 != 0 ? AuditStatus.Incomplete : AuditStatus.Complete,
                    Lane = Random.Shared.Next(1, 15),
                    Plaza = cities[i],
                    ReviewDate = LastTwoMonths.AddDays(Random.Shared.Next(1, 5)).ToString("MM/dd/yyyy"),
                    ReviewResult = i % 2 == 0 ? ReviewResult.Accept : ReviewResult.Reject,
                    AuditorName = AuditorName(names[i]),
                    Percentage = Random.Shared.Next(95, 100),
                });

            }
        }


        /// <summary>
        /// Get Auditor Name
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        string AuditorName(string value)
        {
            var name = value.Split(" ");
            return (name[0].Substring(0, 1).ToString() + "_" + name[1]).ToLower();
        }


        /// <summary>
        /// On Change Slider
        /// </summary>
        /// <param name="value"></param>
        void OnChangeSlider(dynamic value)
        {
            SliderValue = value;
        }


        /// <summary>
        /// Quit
        /// </summary>
        /// <returns></returns>
        async Task Quit()
        {
            var result = (bool)await (DialogService.Confirm("Are you sure you want to Quit?", "Alert",
          new ConfirmOptions() { OkButtonText = "Yes", CancelButtonText = "No" }));
            if (result)
            {
                UtilsService.NavigateTo("/", false);
            }

        }


        /// <summary>
        /// On Transaction Change
        /// </summary>
        /// <param name="value"></param>
        void OnTransactionChange(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                if (value == TransactionDDL[0])
                    TransactionType = 1;
                else
                    TransactionType = 2;
            }
        }


        /// <summary>
        /// Reset Form
        /// </summary>
        void ResetForm()
        {
            Search = new();
            TransactionType = 0;
        }


        /// <summary>
        /// Submit Search
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        async Task SubmitSearch(TransactionSearch data)
        {
            await ShowAlert("Not Implemented yet!");
        }



        #endregion
    }
}
