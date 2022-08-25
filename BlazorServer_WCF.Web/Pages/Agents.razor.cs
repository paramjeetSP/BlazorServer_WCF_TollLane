using System.Globalization;
namespace BlazorServer_WCF.Web.Pages
{
    /// <summary>
    /// Agents
    /// </summary>
    public partial class Agents
    {
        #region Classes and Variables

        /// <summary>
        /// Performing Agents
        /// </summary>
        class PerformingAgents
        {
            public string Name { get; set; }

            public string Image { get; set; }

            public int Price { get; set; }
        }

        List<PerformingAgents> ImageSelect;


        List<PerformingAgents> Imagereview;


        List<PerformingAgents> Supervisor;


        List<string> names = new List<string>() { "Noah Smith", "Charlotte Rodriguez", "Liam Johnson", "Emma Jones", "Mason Wilson", "Olivia Miller", "Jacob Taylor", "Isabella Garcia", "Michael Wang", "Ethan Williams", "Alexander Brown", "Sophia Davis" };


        #endregion


        #region Razor Functions        

        /// <summary>
        /// On Initialized
        /// </summary>
        protected override void OnInitialized()
        {
            ImageSelect = new List<PerformingAgents>();
            Imagereview = new List<PerformingAgents>();
            Supervisor = new List<PerformingAgents>();
            SetAgentDetails();
        }


        /// <summary>
        /// Set Agent Details
        /// </summary>
        void SetAgentDetails()
        {
            for (int i = 1; i < 5; i++)
            {
                ImageSelect.Add(new PerformingAgents
                {
                    Name = names[i - 1],
                    Image = $"assets/images/faces-clipart/pic-{Random.Shared.Next(1, 4)}.png",
                    Price = Random.Shared.Next(35000, 50000),
                });
                Imagereview.Add(new PerformingAgents
                {
                    Name = names[i + 3],
                    Image = $"assets/images/faces-clipart/pic-{Random.Shared.Next(1, 4)}.png",
                    Price = Random.Shared.Next(35000, 50000),
                });
                Supervisor.Add(new PerformingAgents
                {
                    Name = names[i + 7],
                    Image = $"assets/images/faces-clipart/pic-{Random.Shared.Next(1, 4)}.png",
                    Price = Random.Shared.Next(35000, 50000),
                });
            }
        }


        /// <summary>
        /// Format As USD
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        string FormatAsUSD(object value)
        {
            return ((int)value).ToString("C0", CultureInfo.CreateSpecificCulture("en-US"));
        }

        #endregion
    }
}
